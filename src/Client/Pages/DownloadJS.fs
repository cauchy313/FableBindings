module Pages.DownloadJS

open Feliz
open Feliz.Bulma
open Elmish
open Feliz.UseElmish
open Fable.DownloadJS.Tests

type State = { Stuff : string}


type Msg = 
    | DoNothing

let init () = {Stuff = ""}, Cmd.none 


let update (msg: Msg) (state: State) : State * Cmd<Msg> = 
    match msg with 
    | DoNothing -> state, Cmd.none 



[<ReactComponent>]
let DownloadJSView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [


       Bulma.buttons [
                Bulma.button.button [
                     prop.text "Download Test from String"
                     color.isInfo
                     prop.onClick (fun _ -> plainText())           
                ]
                Bulma.button.button [
                     prop.text "Download Test From Data URL"
                     color.isInfo
                     prop.onClick (fun _ -> dataURLText())           
                ]
                Bulma.button.button [
                     prop.text "Download Test from Blob"
                     color.isInfo
                     prop.onClick (fun _ -> blobText() ) 
                ]
                Bulma.button.button [
                     prop.text "Download Test from Typed Array" 
                     color.isInfo
                     prop.onClick (fun _ -> arrayText())
                ]
            ]    
      ]

    
