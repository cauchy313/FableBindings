module Index

open Elmish
open Fable.Remoting.Client
open Shared

type Model = { Stuff: string }

type Msg =
    | DoNothing


let init () : Model * Cmd<Msg> =
    let model = {Stuff = ""}

    let cmd = Cmd.none

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | DoNothing -> model, Cmd.none 

open Feliz
open Feliz.Bulma
open Fable.Core 
open Fable.Core.JS


module DownloadJS = 

    open Fable.DownloadJS.Tests
    
    let Testing () =
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



let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        DownloadJS.Testing()
    ]