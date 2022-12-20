module Index

open Elmish
open Feliz
open Feliz.Bulma
open Fable.Core 
open Fable.Core.JsInterop



type Model = { Stuff : string }

type Msg =
    | DoNothing


let init () : Model * Cmd<Msg> =
    let model = {Stuff = ""}

    let cmd = Cmd.none

    model, cmd


let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | DoNothing -> model, Cmd.none






let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        Pages.PdfLib.PdfLibView()
    ]