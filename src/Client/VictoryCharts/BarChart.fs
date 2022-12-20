namespace Feliz.VictoryCharts 

open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type barChart =
        
        

        static member inline alignment (value: Alignment) = Interop.mkBarChartAttr "alignment" value 
        
        static member inline animate (value: Animate) = Interop.mkBarChartAttr "animate" (value |> Animate.toJSobj) 

        static member inline barRatio (value: float) = Interop.mkBarChartAttr "barRatio" value 

        static member inline barWidth (value: int) = Interop.mkBarChartAttr "barWidth" value 
        static member inline barWidth (f: Bar -> int) = Interop.mkBarChartAttr "barWidth" f 
        
        static member inline categories (values: list<string>) = Interop.mkBarChartAttr "categories" (values |> List.toArray)
        static member inline categories (input: {| x: list<string> |}) = Interop.mkBarChartAttr "categories" {| x = input.x |> List.toArray |}

        static member inline containerComponent (el: ReactElement) = Interop.mkBarChartAttr "containerComponent" el
        
        static member inline cornerRadius (opts: CornerRadius list) = Interop.mkBarChartAttr "cornerRadius" (opts |> CornerRadius.toJSObj)
        static member inline cornerRadius (value: int) = Interop.mkBarChartAttr "cornerRadius" value
        
        static member inline data (values: seq<'DataPoint>) = Interop.mkBarChartAttr "data" (values |> Seq.toArray)

        static member inline dataComponent (properties: IBarProperty list)  = 
                let el =  Interop.reactApi.createElement(import "Bar" "victory", createObj !!properties)
                Interop.mkBarAttr "dataComponent" el 

        static member inline domain (value: Domain) = Interop.mkBarChartAttr "domain" (value |> Domain.toJSObj)
        static member inline domain (values: {| x : Domain; y: Domain |}) = Interop.mkBarChartAttr "domain" ({| x = values.x |> Domain.toJSObj; y = values.y |> Domain.toJSObj |})

        static member inline domainPadding (value: DomainPadding) = Interop.mkBarChartAttr "domainPadding" (value.toJSObj)
        static member inline domainPadding (values: {| x : DomainPadding; y: DomainPadding |}) = Interop.mkBarChartAttr "domainPadding" ({| x = values.x.toJSObj; y = values.y.toJSObj |})

        
        static member inline events (evs: BarEvent<'ParentProps> list) = Interop.mkBarChartAttr "events" (evs |> List.toArray |> Array.map Event.toJSObj)

        static member inline externalEventMutations (evs: obj array) = Interop.mkBarChartAttr "externalEventMutations" evs
        
        static member inline groupComponent (properties: ISvgAttribute list) = 
                let el =  Svg.svg [
                                    Svg.g properties
                                ] 
                Interop.mkBarChartAttr "groupComponent" el
        
        static member inline height (value: int) = Interop.mkBarChartAttr "height" value
        
        static member inline horizontal (isTrue: bool) = Interop.mkBarChartAttr "horizontal" isTrue
        
        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkBarChartAttr "labelComponent" el 
        
        static member inline labelComponent (props: ITooltipProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryTooltip" "victory", createObj !!props)
            Interop.mkBarChartAttr "labelComponent" el 
        
        static member inline labels (values: list<string>) = Interop.mkBarChartAttr "labels" (values |> List.toArray)
        static member inline labels (f: Label -> string) = Interop.mkBarChartAttr "labels" f 
        static member inline labels (f: Label -> list<string>) = 
                        let g = fun (l : Label) ->  l 
                                                    |> f 
                                                    |> List.toArray 
                        Interop.mkBarChartAttr "labels" g
        
        
        static member inline maxDomain (value: int) = Interop.mkBarChartAttr "maxDomain" value 
        static member inline maxDomain (value: DomainLimit) = Interop.mkBarChartAttr  "maxDomain" value.toJSObj 
                
        static member inline minDomain (value: int) = Interop.mkBarChartAttr "minDomain" value 
        static member inline minDomain (value: DomainLimit) = Interop.mkBarChartAttr  "minDomain" value.toJSObj 
                
        
        static member inline name (value: string) = Interop.mkBarChartAttr "name" value 

        static member inline padding (value: Padding) = Interop.mkBarChartAttr "padding" value.toJSObj 
        
        static member inline polar (isTrue: bool) = Interop.mkBarChartAttr "polar" isTrue

        static member inline samples (value: int) = Interop.mkBarChartAttr "samples" value 

        static member inline scale (value: Scale) = Interop.mkBarChartAttr "scale" value 
        static member inline scale (value: {| x: Scale; y: Scale |}) = Interop.mkBarChartAttr "scale" value
        
       

        static member inline singleQuadrantDomainPadding (isTrue: bool) = Interop.mkBarChartAttr "singleQuadrantDomainPadding" isTrue 
        
        static member inline sortKey (value: int) = Interop.mkBarChartAttr "sortKey" value 
        static member inline sortKey (value: string) = Interop.mkBarChartAttr "sortKey" value 
        static member inline sortKey (values: seq<string>) = Interop.mkBarChartAttr "sortKey" (values |> Seq.toArray)        

        static member inline sortOrder (value: SortOrder) = Interop.mkBarChartAttr "sortOrder" value 

        
        static member inline standalone (isTrue: bool) = Interop.mkBarChartAttr "standalone" isTrue 



        static member inline style (value: Style<Bar> ) = Interop.mkBarChartAttr "style" value.toJSObj

        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkBarChartAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkBarChartAttr "theme" el?grayscale

        static member inline width (value: int) = Interop.mkBarChartAttr "width" value 

        static member inline x (value: string) = Interop.mkBarChartAttr "x" value 
        static member inline x (value: int) = Interop.mkBarChartAttr "x" value 
        static member inline x (values: list<string>) = Interop.mkBarChartAttr "x" (values |> List.toArray)
        static member inline x (f: 'Datum -> X) = Interop.mkBarChartAttr "x" f 

        static member inline y (value: string) = Interop.mkBarChartAttr "y" value 
        static member inline y (value: int) = Interop.mkBarChartAttr "y" value 
        static member inline y (values: list<string>) = Interop.mkBarChartAttr "y" (values |> List.toArray)
        static member inline y (f: 'Datum -> Y) = Interop.mkBarChartAttr "y" f 

        static member inline y0 (value: string) = Interop.mkBarChartAttr "y0" value 
        static member inline y0 (value: int) = Interop.mkBarChartAttr "y0" value 
        static member inline y0 (values: list<string>) = Interop.mkBarChartAttr "y0" (values |> List.toArray)
        static member inline y0 (f: Datum -> Y) = Interop.mkBarChartAttr "y0" f 