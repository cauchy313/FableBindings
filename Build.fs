open Fake.Core
open Fake.IO

open Farmer
open Farmer.Builders
open System
open System.IO

open Helpers

initializeContext()


module DotEnv =
    
    let private parseLine(line : string) =
        Console.WriteLine (sprintf "Parsing: %s" line)
        match line.Split('=', 2, StringSplitOptions.RemoveEmptyEntries) with
        | args when args.Length = 2 ->
            Environment.SetEnvironmentVariable(
                args.[0],
                args.[1])
        | _ -> ()

    let private load() =
        lazy (
            Console.WriteLine "Trying to load .env file..."
            let dir = Directory.GetCurrentDirectory()
            let filePath = Path.Combine(dir, ".env")
            filePath
            |> File.Exists
            |> function
                | false -> Console.WriteLine "No .env file found."
                | true  ->
                    filePath
                    |> File.ReadAllLines
                    |> Seq.iter parseLine
        )

    let init = load().Value



let sharedPath = Path.getFullName "src/Shared"
let serverPath = Path.getFullName "src/Server"
let clientPath = Path.getFullName "src/Client"
let deployPath = Path.getFullName "deploy"
let sharedTestsPath = Path.getFullName "tests/Shared"
let serverTestsPath = Path.getFullName "tests/Server"
let clientTestsPath = Path.getFullName "tests/Client"


let getEnvFromAllOrNone (s: string) =
    let envOpt (envVar: string) =
        if String.IsNullOrEmpty envVar then None
        else Some(envVar)

    let procVar = Environment.GetEnvironmentVariable(s) |> envOpt
    let userVar = Environment.GetEnvironmentVariable(s, EnvironmentVariableTarget.User) |> envOpt
    let machVar = Environment.GetEnvironmentVariable(s, EnvironmentVariableTarget.Machine) |> envOpt

    match procVar,userVar,machVar with
    | Some(v), _, _
    | _, Some(v), _
    | _, _, Some(v)
        -> Some(v)
    | _ -> None


let publish projectPath = 
        [ Path.Combine [| projectPath ; "bin" |]
          Path.Combine [| projectPath ; "obj" |] ]  |> Shell.cleanDirs
        run dotnet "restore --no-cache" projectPath
        run dotnet "pack -c Release" projectPath       
        //run dotnet "pack -c Release" projectPath
        let nugetKey =
                        match getEnvFromAllOrNone "nuget-key" with
                        | Some nugetKey -> nugetKey
                        | _ -> failwith "The Nuget API key must be set in a nuget-key environmental variable"
        let nupkg =
                    Directory.GetFiles(Path.Combine [| projectPath ; "bin" ; "Release" |])
                    |> Seq.head
                    |> Path.GetFullPath

        let pushCmd = sprintf "nuget push %s -s nuget.org -k %s" nupkg nugetKey
        run dotnet pushCmd projectPath

Target.create "PublishDownloadJS" (fun _ -> 
                        publish (Path.getFullName "fable/Fable.DownloadJS/") )


Target.create "Clean" (fun _ ->
    Shell.cleanDir deployPath
    run dotnet "fable clean --yes" clientPath // Delete *.fs.js files created by Fable
)

Target.create "InstallClient" (fun _ -> run npm "install" ".")

Target.create "Bundle" (fun _ ->
    [ "server", dotnet $"publish -c Release -o \"{deployPath}\"" serverPath
      "client", dotnet "fable -o output -s --run npm run build" clientPath ]
    |> runParallel
)

Target.create "Azure" (fun _ ->
    let web = webApp {
        name "FableBindings"
        zip_deploy "deploy"
    }
    let deployment = arm {
        location Location.WestEurope
        add_resource web
    }

    deployment
    |> Deploy.execute "FableBindings" Deploy.NoParameters
    |> ignore
)

Target.create "Run" (fun _ ->
    run dotnet "build" sharedPath
    [ "server", dotnet "watch run" serverPath
      "client", dotnet "fable watch -o output -s --run npm run start" clientPath ]
    |> runParallel
)

Target.create "RunTests" (fun _ ->
    run dotnet "build" sharedTestsPath
    [ "server", dotnet "watch run" serverTestsPath
      "client", dotnet "fable watch -o output -s --run npm run test:live" clientTestsPath ]
    |> runParallel
)

Target.create "Format" (fun _ ->
    run dotnet "fantomas . -r" "src"
)

open Fake.Core.TargetOperators

let dependencies = [
    "Clean"
        ==> "InstallClient"
        ==> "Bundle"
        ==> "Azure"

    "Clean"
        ==> "InstallClient"
        ==> "Run"

    "InstallClient"
        ==> "RunTests"
]

[<EntryPoint>]
let main args = runOrDefault args