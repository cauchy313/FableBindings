namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type flyout =
        
        
     //   static member inline events (values: BasicEvent list) = Interop.mkFlyoutAttr "events" (values |> BasicEvent.toJSobj)

        static member inline style (values: ISVGStyleProperty<BasicStyle> List) = Interop.mkFlyoutAttr "style" (createObj !!values)