namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop


[<Erase>]
type legend =
        
        
        static member inline borderComponent (properties: ISVGStyleProperty<BasicStyle> list) = 
             let el =  Interop.reactApi.createElement(import "Border" "victory", createObj !!properties)
             Interop.mkLegendAttr "borderComponent" el 

        static member inline borderPadding (value: Padding) = Interop.mkLegendAttr "borderPadding" value 

        static member inline centerTitle (isTrue: bool) = Interop.mkLegendAttr "centerTitle" isTrue 

        static member inline colorScale (value: ColorScale) = Interop.mkLegendAttr "colorScale" value 

        static member inline colorScale (colors: string list) = Interop.mkLegendAttr "colorScale" (colors |> List.toArray)

        static member inline containerComponent (el: ReactElement) = Interop.mkLegendAttr "containerComponent" el 

        static member inline data (values: LegendDatum list) = Interop.mkLegendAttr "data" (values |> List.map LegendDatum.toJSobj |> List.toArray)

    //    static member inline events (evs: Event list) = Interop.mkLegendAttr "events" (evs |> List.toArray |> Array.map Event.toJSobj)

        static member inline externalEventMutations (evs: obj array) = Interop.mkLegendAttr "externalEventMutations" evs


        static member inline groupComponent (properties: ISvgAttribute list) = 
                let el =  Svg.svg [
                                    Svg.g properties
                                ] 
                Interop.mkLegendAttr "groupComponent" el


        static member inline gutter (value: int) = Interop.mkLegendAttr "gutter" value
        static member inline gutter (value: {| left: int; right: int |}) = Interop.mkLegendAttr "gutter" value 

        static member inline height (value: int) = Interop.mkLegendAttr "height" value 

        static member inline itemsPerRow (value: int) = Interop.mkLegendAttr "itemsPerRow" value 


        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkLegendAttr "labelComponent" el 


        static member inline orientation (value: Orientation) = Interop.mkLegendAttr "orientation" value 

        static member inline padding (value: Padding) = Interop.mkLegendAttr "padding" value.toJSObj


        static member inline rowGutter (value: int) = Interop.mkLegendAttr "rowGutter" value
        static member inline rowGutter (value: {| top: int; bottom: int |}) = Interop.mkLegendAttr "rowGutter" value 

        static member inline standalone (isTrue: bool) = Interop.mkLegendAttr "standalone" isTrue

        static member inline style (value: LegendStyle) = Interop.mkLegendAttr "style" value.toJSObj

        static member inline symbolSpacer (value: int) = Interop.mkLegendAttr "symbolSpacer" value 
        
        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkLegendAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkLegendAttr "theme" el?grayscale
        
        static member inline title (value: string) = Interop.mkLegendAttr "title" value 
        static member inline title (values: string list) = Interop.mkLegendAttr "title" (values |> List.toArray)

        static member inline titleComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkLegendAttr "titleComponent" el 

        static member inline titleOrientation (value: TitleOrientation) = Interop.mkLegendAttr "titleOrientation" value 

        static member inline width (value: int) = Interop.mkLegendAttr "width" value 

        static member inline x (value: int) = Interop.mkLegendAttr "x" value 

        static member inline y (value: int) = Interop.mkLegendAttr "y" value 



        