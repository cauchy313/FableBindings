namespace Feliz.VictoryCharts 

open System
open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type polarAxis =
        
        
        static member inline dependentAxis (isTrue: bool) = Interop.mkPolarAxisAttr "dependentAxis" isTrue

        static member inline style (value: AxisStyle) = Interop.mkPolarAxisAttr "style" value.toJSObj 

        static member inline tickFormat (values: string list) = Interop.mkPolarAxisAttr "tickFormat" (values |> List.toArray)
        static member inline tickFormat (f: Tick -> string) = Interop.mkPolarAxisAttr "tickFormat" f 
        