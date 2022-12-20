namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type bar =
        
        
      //  static member inline events (values: BasicEvent list) = Interop.mkBarAttr "events" (values |> BasicEvent.toJSobj)

        static member inline style (values: ISVGStyleProperty<BasicStyle> List) = Interop.mkBarAttr "style" (createObj !!values)