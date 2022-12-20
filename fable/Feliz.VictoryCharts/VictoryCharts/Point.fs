namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type point =
        
        
     //   static member inline events (values: BasicEvent list) = Interop.mkPointAttr "events" (values |> BasicEvent.toJSobj)

        static member inline style (values: ISVGStyleProperty<BasicStyle> List) = Interop.mkPointAttr "style" (createObj !!values)
