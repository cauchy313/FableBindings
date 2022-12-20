namespace Feliz.VictoryCharts 

open System
open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type axis =
        
        
        static member inline axisComponent (comp: ReactElement) = Interop.mkAxisAttr "axisComponent" comp

                
        static member inline axisLabelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkAxisAttr "axisLabelComponent" el 

        static member inline axisValue (value: string) = Interop.mkAxisAttr "axisValue" value 
        
        static member inline containerComponent (comp: ReactElement) = Interop.mkAxisAttr "containerComponent" comp
        
        
        static member inline crossAxis (isTrue: bool) = Interop.mkAxisAttr "crossAxis" isTrue  
        
        static member inline dependentAxis (isTrue: bool) = Interop.mkAxisAttr "dependentAxis" isTrue
        
        static member inline domain (value: Domain) = Interop.mkAxisAttr "domain" (value |> Domain.toJSObj)
        static member inline domain (value: {| x : Domain |}) = Interop.mkAxisAttr "domain" {| x = (value.x |> Domain.toJSObj)|}
        static member inline domain (value: {| y : Domain |}) = Interop.mkAxisAttr "domain"  {| y = (value.y |> Domain.toJSObj)|}
        static member inline domain (value: {| x : Domain ; y: Domain |}) = Interop.mkAxisAttr "domain" {| x = (value.x |> Domain.toJSObj); y = (value.y |> Domain.toJSObj) |}
        
        static member inline height (value: int) = Interop.mkAxisAttr "height" value 
        
        static member inline invertAxis (isTrue: bool) = Interop.mkAxisAttr "invertAxis" isTrue 
        
        static member inline key (value: int) = Interop.mkAxisAttr "key" value 
        
        static member inline label (value: string) = Interop.mkAxisAttr "label" value 

        static member inline maxDomain (value: int) = Interop.mkAxisAttr "maxDomain" value 
        static member inline maxDomain (value: float) = Interop.mkAxisAttr "maxDomain" value 
        
        static member inline maxDomain (value: {| x : int |}) = Interop.mkAxisAttr "maxDomain" value
        static member inline maxDomain (value: {| y : int |}) = Interop.mkAxisAttr "maxDomain" value
        
        static member inline minDomain (value: int) = Interop.mkAxisAttr "minDomain" value 
        static member inline minDomain (value: float) = Interop.mkAxisAttr "minDomain" value 
        
        static member inline minDomain (value: {| x : int |}) = Interop.mkAxisAttr "minDomain" value
        static member inline minDomain (value: {| y : int |}) = Interop.mkAxisAttr "minDomain" value

        static member inline offsetX (value: int) = Interop.mkAxisAttr "offsetX" value 
        static member inline offsetX (value: float) = Interop.mkAxisAttr "offsetX" value
        
        static member inline offsetY (value: int) = Interop.mkAxisAttr "offsetY" value 
        static member inline offsetY (value: float) = Interop.mkAxisAttr "offsetY" value
        
        static member inline orientation (value: AxisOrientation) = Interop.mkAxisAttr "orientation" value
        
        static member inline standalone (isTrue: bool) = Interop.mkAxisAttr "standalone" isTrue
        
        static member inline style (value: AxisStyle) = Interop.mkAxisAttr "style" value.toJSObj
        
        static member inline theme (value: Theme) = 
                 let el = import "VictoryTheme" "victory"     
                        
                 match value with 
                        | Theme.Material -> Interop.mkAxisAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkAxisAttr "theme" el?grayscale

        static member inline tickComponent (comp: ReactElement) = Interop.mkAxisAttr "tickComponent" comp
        
        static member inline tickCount (value: int) = Interop.mkAxisAttr "tickCount" value
        

        static member inline tickFormat (values: int list) = Interop.mkAxisAttr "tickFormat" (values |> List.toArray) 
        static member inline tickFormat (values: string list) = Interop.mkAxisAttr "tickFormat" (values |> List.toArray) 
        static member inline tickFormat (values: float list) = Interop.mkAxisAttr "tickFormat" (values |> List.toArray) 
        static member inline tickFormat (f: TickValue -> string) = Interop.mkAxisAttr "tickFormat" f
        
        static member inline tickLabelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkAxisAttr "tickLabelComponent" el 
        
        static member inline tickValues (values: int list) = Interop.mkAxisAttr "tickValues"  (values |> List.toArray)
        static member inline tickValues (values: float list) = Interop.mkAxisAttr "tickValues" (values |> List.toArray) 
        static member inline tickValues (values: string list) = Interop.mkAxisAttr "tickValues" (values |> List.toArray) 
        static member inline tickValues (values: DateTime list) = Interop.mkAxisAttr "tickValues" (values |> List.toArray)

        
        
        
        static member inline width (value: int) = Interop.mkAxisAttr "width" value 





        