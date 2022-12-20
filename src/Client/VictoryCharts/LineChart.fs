namespace Feliz.VictoryCharts 

open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type lineChart =      
        
       
        static member inline data (values: seq<'DataPoint>) = Interop.mkLineChartAttr "data" (values |> Seq.toArray)

        
        static member inline groupComponent (props: IClipContainerProperty list) = 
             let el =  Interop.reactApi.createElement(import "VictoryClipContainer" "victory", createObj !!props)
             Interop.mkLineChartAttr "groupComponent" el 
        
        static member inline height (value: int) = Interop.mkLineChartAttr "height" value
        
        static member inline horizontal (isTrue: bool) = Interop.mkLineChartAttr "horizontal" isTrue
        
        static member inline interpolation (value: CartesianLinearInterpolation) = Interop.mkLineChartAttr "interpolation" value 
        static member inline interpolation (value: PolarInterpolation) = Interop.mkLineChartAttr "interpolation" value 
        
        
        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkLineChartAttr "labelComponent" el 
        
        static member inline labels (values: list<string>) = Interop.mkLineChartAttr "labels" (values |> List.toArray)
        static member inline labels (f: Label -> string) = Interop.mkLineChartAttr "labels" f 
        static member inline labels (f: Label -> list<string>) = 
                        let g = fun (l : Label) ->  l 
                                                    |> f 
                                                    |> List.toArray 
                        Interop.mkLineChartAttr "labels" g
        
        
        
        static member inline maxDomain (value: int) = Interop.mkLineChartAttr "maxDomain" value 
        static member inline maxDomain (value: DomainLimit) = Interop.mkLineChartAttr  "maxDomain" value.toJSObj 
                
        static member inline minDomain (value: int) = Interop.mkLineChartAttr "minDomain" value 
        static member inline minDomain (value: DomainLimit) = Interop.mkLineChartAttr  "minDomain" value.toJSObj 
        
        
        static member inline name (value: string) = Interop.mkLineChartAttr "name" value 
        
        static member inline padding (value: Padding) = Interop.mkLineChartAttr "padding" value.toJSObj 
        
        static member inline samples (value: int) = Interop.mkLineChartAttr "samples" value 

        static member inline sortKey (value: string) = Interop.mkLineChartAttr "sortKey" value
        
        static member inline standalone (isTrue: bool) = Interop.mkLineChartAttr "standalone" isTrue 
        
        static member inline style (value: LineStyle) = Interop.mkLineChartAttr "style" value.toJSObj
        
        
        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkLineChartAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkLineChartAttr "theme" el?grayscale

        
        static member inline width (value: int) = Interop.mkLineChartAttr "width" value 
        
        static member inline x (value: string) = Interop.mkLineChartAttr "x" value 
        static member inline x (value: int) = Interop.mkLineChartAttr "x" value 
        static member inline x (values: list<string>) = Interop.mkLineChartAttr "x" (values |> List.toArray)
        static member inline x (f: Datum -> X) = Interop.mkLineChartAttr "x" f 
        static member inline x' (f:'Datum -> X) = Interop.mkLineChartAttr "x" f 

        static member inline y (value: string) = Interop.mkLineChartAttr "y" value 
        static member inline y (value: int) = Interop.mkLineChartAttr "y" value 
        static member inline y (values: list<string>) = Interop.mkLineChartAttr "y" (values |> List.toArray)
        static member inline y (f: Datum -> Y) = Interop.mkLineChartAttr "y" f 
        static member inline y' (f: 'Datum -> Y) = Interop.mkLineChartAttr "y" f 