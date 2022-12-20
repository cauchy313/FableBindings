namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type scatterChart =
        
        static member inline bubbleProperty (value: string) = Interop.mkScatterChartAttr "bubbleProperty" value 
        
        static member inline data (values: seq<'DataPoint>) = Interop.mkScatterChartAttr "data" (values |> Seq.toArray)


        static member inline dataComponent (el: ReactElement) = Interop.mkScatterChartAttr "dataComponent" el
        
        static member inline domain (value: Domain) = Interop.mkScatterChartAttr "domain" (value |> Domain.toJSObj)
        static member inline domain (values: {| x : Domain; y: Domain |}) = Interop.mkScatterChartAttr "domain" ({| x = values.x |> Domain.toJSObj ; y = values.y |> Domain.toJSObj  |})

        static member inline domainPadding (value: DomainPadding) = Interop.mkScatterChartAttr "domainPadding" (value.toJSObj)
        static member inline domainPadding (values: {| x : DomainPadding; y: DomainPadding |}) = Interop.mkScatterChartAttr "domainPadding" ({| x = values.x.toJSObj; y = values.y.toJSObj |})

        
     //   static member inline events (evs: Event list) = Interop.mkScatterChartAttr "events" (evs |> List.toArray |> Array.map Event.toJSobj)

        static member inline groupComponent (props: IClipContainerProperty list) = 
             let el =  Interop.reactApi.createElement(import "VictoryClipContainer" "victory", createObj !!props)
             Interop.mkScatterChartAttr "groupComponent" el 

        static member inline height (value: int) = Interop.mkScatterChartAttr "height" value 

        static member inline horizontal (isTrue: bool) = Interop.mkScatterChartAttr "horizontal" isTrue
        
        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkScatterChartAttr "labelComponent" el 
        
        static member inline labelComponent (props: ITooltipProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryTooltip" "victory", createObj !!props)
            Interop.mkScatterChartAttr "labelComponent" el 


        static member inline labels (isTrue: bool) = Interop.mkScatterChartAttr "labels" isTrue 
        
        static member inline labels (value: string) = Interop.mkScatterChartAttr "labels" value
        static member inline labels (values: list<string>) = Interop.mkScatterChartAttr "labels" (values |> List.toArray)
        static member inline labels (f: Point -> string) = Interop.mkScatterChartAttr "labels" f 
        static member inline labels (f: Point -> list<string>) = 
                        let g = fun (l : Point) ->  l 
                                                    |> f 
                                                    |> List.toArray 
                        Interop.mkScatterChartAttr "labels" g

       

        static member inline maxBubbleSize (value: int) = Interop.mkScatterChartAttr "maxBubbleSize" value

        static member inline minBubbleSize (value: int) = Interop.mkScatterChartAttr "minBubbleSize" value 
        
        static member inline name (value: string) = Interop.mkScatterChartAttr "name" value
        
        static member inline padding (value: Padding) = Interop.mkScatterChartAttr "padding" value.toJSObj

        static member inline range (value: Domain) = Interop.mkScatterChartAttr "range" (value |> Domain.toJSObj)
        
        static member inline samples (value: int) = Interop.mkScatterChartAttr "samples" value
        
        static member inline standalone (isTrue: bool) = Interop.mkScatterChartAttr "standalone" isTrue

        static member inline size (value: int) = Interop.mkScatterChartAttr "size" value 
        static member inline size (f: Point -> int) = Interop.mkScatterChartAttr "size" f 

        static member inline style (value: ScatterChartStyle) =  Interop.mkScatterChartAttr "style" value.toJSObj

        static member inline symbol (value: SymbolType) = Interop.mkScatterChartAttr "symbol" value
        static member inline symbol (f: Point -> SymbolType) = Interop.mkScatterChartAttr "symbol" f

        static member inline width (value: int) = Interop.mkScatterChartAttr "width" value 

        static member inline y (value: string) = Interop.mkScatterChartAttr "y" value 
        static member inline y (value: int) = Interop.mkScatterChartAttr "y" value 
        static member inline y (values: list<string>) = Interop.mkScatterChartAttr "y" (values |> List.toArray)
        static member inline y (f: Datum -> Y) = Interop.mkScatterChartAttr "y" f 