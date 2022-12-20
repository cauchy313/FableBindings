namespace Feliz.VictoryCharts 

open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type areaChart =
        
        
        static member inline data (values: seq<'DataPoint>) = Interop.mkAreaChartAttr "data" (values |> Seq.toArray)

        static member inline domain (value: Domain) = Interop.mkAreaChartAttr "domain" (value |> Domain.toJSObj)
        static member inline domain (values: {| x : Domain; y: Domain |}) = Interop.mkAreaChartAttr "domain" ({| x = values.x |> Domain.toJSObj; y = values.y |> Domain.toJSObj |})

        static member inline domainPadding (value: DomainPadding) = Interop.mkAreaChartAttr "domainPadding" (value.toJSObj)
        static member inline domainPadding (values: {| x : DomainPadding; y: DomainPadding |}) = Interop.mkAreaChartAttr "domainPadding" ({| x = values.x.toJSObj; y = values.y.toJSObj |})

       // static member inline events (evs: Event list) = Interop.mkAreaChartAttr "events" (evs |> List.toArray |> Array.map Event.toJSobj)

        
        static member inline groupComponent (props: IClipContainerProperty list) = 
             let el =  Interop.reactApi.createElement(import "VictoryClipContainer" "victory", createObj !!props)
             Interop.mkAreaChartAttr "groupComponent" el 
        
        static member inline height (value: int) = Interop.mkAreaChartAttr "height" value
        
        static member inline horizontal (isTrue: bool) = Interop.mkAreaChartAttr "horizontal" isTrue
        
        static member inline interpolation (value: CartesianAreaInterpolation) = Interop.mkAreaChartAttr "interpolation" value 
        static member inline interpolation (value: PolarInterpolation) = Interop.mkAreaChartAttr "interpolation" value 
        
        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkAreaChartAttr "labelComponent" el 
        
        static member inline labelComponent (props: ITooltipProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryTooltip" "victory", createObj !!props)
            Interop.mkAreaChartAttr "labelComponent" el
        
        static member inline labels (values: list<string>) = Interop.mkAreaChartAttr "labels" (values |> List.toArray)
        static member inline labels (f: Label -> string) = Interop.mkAreaChartAttr "labels" f 
        static member inline labels (f: Label -> list<string>) = 
                        let g = fun (l : Label) ->  l 
                                                    |> f 
                                                    |> List.toArray 
                        Interop.mkAreaChartAttr "labels" g
        
        
        static member inline name (value: string) = Interop.mkAreaChartAttr "name" value 
        
        static member inline padding (value: Padding) = Interop.mkAreaChartAttr "padding" value.toJSObj 

        static member inline samples (value: int) = Interop.mkAreaChartAttr "samples" value
        
        static member inline standalone (isTrue: bool) = Interop.mkAreaChartAttr "standalone" isTrue
        
        static member inline style (values: AreaStyle) = Interop.mkAreaChartAttr "style" values.toJSObj
        
        static member inline width (value: int) = Interop.mkAreaChartAttr "width" value 

        static member inline x (value: string) = Interop.mkAreaChartAttr "x" value 
        static member inline x (value: int) = Interop.mkAreaChartAttr "x" value 
        static member inline x (values: list<string>) = Interop.mkAreaChartAttr "x" (values |> List.toArray)
        static member inline x (f: Datum -> X) = Interop.mkAreaChartAttr "x" f 

        static member inline y (value: string) = Interop.mkAreaChartAttr "y" value 
        static member inline y (value: int) = Interop.mkAreaChartAttr "y" value 
        static member inline y (values: list<string>) = Interop.mkAreaChartAttr "y" (values |> List.toArray)
        static member inline y (f: Datum -> Y) = Interop.mkAreaChartAttr "y" f 

        
        static member inline y0 (value: string) = Interop.mkAreaChartAttr "y0" value 
        static member inline y0 (value: int) = Interop.mkAreaChartAttr "y0" value 
        static member inline y0 (values: list<string>) = Interop.mkAreaChartAttr "y0" (values |> List.toArray)
        static member inline y0 (f: Datum -> Y) = Interop.mkAreaChartAttr "y0" f 