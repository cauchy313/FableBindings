namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type pieChart =
       
        inherit commonVictoryProps
        static member inline animate (isTrue: bool) = Interop.mkPieChartAttr "animate" isTrue 
        static member inline animate (value: Animate) = Interop.mkPieChartAttr "animate" (value |> Animate.toJSobj)
        
        static member inline categories (values: seq<string>) = Interop.mkPieChartAttr "categories" (values |> Seq.toArray)
        static member inline categories (input: {| x: array<string> |}) = Interop.mkPieChartAttr "categories" input

        static member inline colorScale (cs: ColorScale) = Interop.mkPieChartAttr "colorScale" cs
        static member inline colorScale (colors: list<string>) = Interop.mkPieChartAttr "colorScale" (colors |> List.toArray)
        
        static member inline containerComponent (comp: ReactElement) = Interop.mkPieChartAttr "containerComponent" comp
        
        static member inline cornerRadius (value: int) = Interop.mkPieChartAttr "cornerRadius" value 
        static member inline cornerRadius (f: PieSlice -> int) = Interop.mkPieChartAttr "cornerRadius" f
        

        static member inline data (values: seq<'DataPoint>) = Interop.mkPieChartAttr "data" (values |> Seq.toArray)
        
        static member inline dataComponent (comp: ReactElement) = Interop.mkPieChartAttr "dataComponent" comp 

        static member inline endAngle (value: int) = Interop.mkPieChartAttr "endAngle" value

     //   static member inline events (evs: Event list) = Interop.mkPieChartAttr "events" (evs |> List.toArray |> Array.map Event.toJSobj)
        
        static member inline externalEventMutations (evs: obj array) = Interop.mkPieChartAttr "externalEventMutations" evs

        static member inline groupComponent (el: ReactElement) = Interop.mkPieChartAttr "groupComponent" el 

       // static member inline height (value: int) = Interop.mkPieChartAttr "height" value 

        static member inline innerRadius (value: int) = Interop.mkPieChartAttr "innerRadius" value 
        static member inline innerRadius (f: PieSlice -> int) = Interop.mkPieChartAttr "innerRadius" f 

        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkPieChartAttr "labelComponent" el 
        
        static member inline labelComponent (props: ITooltipProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryTooltip" "victory", createObj !!props)
            Interop.mkPieChartAttr "labelComponent" el 
        
        static member inline labelPlacement (value: LabelPlacement) = Interop.mkPieChartAttr "labelPlacement" value  
        static member inline labelPlacement (f: PieSlice -> LabelPlacement) = Interop.mkPieChartAttr "labelPlacement" f        
 
        static member inline labelPosition (value: LabelPosition) = Interop.mkPieChartAttr "labelPosition" value 
        static member inline labelPosition (f: PieSlice -> LabelPosition) = Interop.mkPieChartAttr "labelPosition" f 

        static member inline labelRadius (value: int) = Interop.mkPieChartAttr "labelRadius" value 
        static member inline labelRadius (f: PieSlice -> int) = Interop.mkPieChartAttr "labelRadius" f 
                
        static member inline labels (values: seq<string>) = Interop.mkPieChartAttr "labels" (values |> Seq.toArray)
        static member inline labels (f: Label -> string) = Interop.mkPieChartAttr "labels" f 

        static member inline name (value: string) = Interop.mkPieChartAttr "name" value 

        static member inline origin(?x: int, ?y: int) = 
                let o = createObj [
                                yield! x 
                                        |> Option.map (fun x0 -> ["x" ==> x0])
                                        |> Option.defaultValue [] 
                                yield! y
                                        |> Option.map (fun y0 -> [ "y" ==> y0] )
                                        |> Option.defaultValue []
                        ]
                Interop.mkPieChartAttr "origin" o

        
        static member inline padAngle (value: int) = Interop.mkPieChartAttr "padAngle" value 
        static member inline padAngle (f: PieSlice -> int) = Interop.mkPieChartAttr "padAngle" f

        static member inline padding (value: Padding) = Interop.mkPieChartAttr "padding" value.toJSObj       

               
        
        static member inline radius (value: int) = Interop.mkPieChartAttr "radius" value 
        static member inline radius (f: PieSlice -> int) = Interop.mkPieChartAttr "radius" f
        
        static member inline sortKey (value: int) = Interop.mkPieChartAttr "sortKey" value 
        static member inline sortKey (value: string) = Interop.mkPieChartAttr "sortKey" value 
        static member inline sortKey (values: seq<string>) = Interop.mkPieChartAttr "sortKey" (values |> Seq.toArray)
        
        static member inline sortOrder (value: SortOrder) = Interop.mkPieChartAttr "sortOrder" value 
        
        static member inline standalone (isTrue: bool) = Interop.mkPieChartAttr "standalone" isTrue
        
        static member inline startAngle (value: int) = Interop.mkPieChartAttr "startAngle" value 


        static member inline style (value: PieChartStyle) =  Interop.mkPieChartAttr "style" value.toJSObj


        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkPieChartAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkPieChartAttr "theme" el?grayscale


      //  static member inline width (value: int) = Interop.mkPieChartAttr "width" value  

        static member inline x (value: string) = Interop.mkPieChartAttr "x" value 
        static member inline x (value: int) = Interop.mkPieChartAttr "x" value 
        static member inline x (values: list<string>) = Interop.mkPieChartAttr "x" (values |> List.toArray)
        static member inline x (f: 'Datum -> X) = Interop.mkPieChartAttr "x" f 

        static member inline y (value: string) = Interop.mkPieChartAttr "y" value 
        static member inline y (value: int) = Interop.mkPieChartAttr "y" value 
        static member inline y (values: list<string>) = Interop.mkPieChartAttr "y" (values |> List.toArray)
        static member inline y (f: 'Datum -> Y) = Interop.mkPieChartAttr "y" f 

