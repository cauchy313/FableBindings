namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type stack =
        
       static member inline children (components: ReactElement list) = Interop.mkStackAttr "children" components  
       
       static member inline colorScale (cs: ColorScale) = Interop.mkStackAttr "colorScale" cs
       static member inline colorScale (colors: list<string>) = Interop.mkStackAttr "colorScale" (colors |> List.toArray)

       
    //   static member inline events (evs: Event list) = Interop.mkAreaChartAttr "events" (evs |> List.toArray |> Array.map Event.toJSobj)

        