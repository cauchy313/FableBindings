namespace Feliz.VictoryCharts


open Feliz
open Fable.Core
open Fable.Core.JsInterop





[<Erase>]
type svgStyleBasic<'Props> =

    static member inline border (value: string) = Interop.mkSVGStyleAttr<'Props> "border" value 
    
    static member inline fill (color: string) = Interop.mkSVGStyleAttr<'Props> "fill" color 
   

    static member inline fillOpacity (value: float) = Interop.mkSVGStyleAttr<'Props> "fillOpacity" value 
    
    
    static member inline fontFamily (value: string) = Interop.mkSVGStyleAttr<'Props> "fontFamily" value 


    static member inline fontSize (value: int)  = Interop.mkSVGStyleAttr<'Props> "fontSize" value 
    
    
    static member inline fontWeight (value: FontWeight) = Interop.mkSVGStyleAttr<'Props> "fontWeight" value 
    
    static member inline opacity (value: float) = Interop.mkSVGStyleAttr<'Props> "opacity" value 
    
    static member inline padding (value: int) = Interop.mkSVGStyleAttr<'Props> "padding" value 
    
    static member inline size (value: int) = Interop.mkSVGStyleAttr<'Props> "size" value
    
    static member inline stroke (color: string) = Interop.mkSVGStyleAttr<'Props> "stroke" color 
    

    static member inline strokeWidth (value: int) = Interop.mkSVGStyleAttr<'Props> "strokeWidth" value 
    
    static member inline strokeLineCap (value: StrokeLineCap) = Interop.mkSVGStyleAttr<'Props> "strokeLinecap" value

[<Erase>]
type svgStyle<'Props> =

    inherit svgStyleBasic<'Props>
   
    static member inline border (f: 'Props -> string) = Interop.mkSVGStyleAttr<'Props> "border" f 
   // static member inline fill (color: string) = Interop.mkSVGStyleAttr<'Props> "fill" color 
    static member inline fill (f: 'Props -> string)  = Interop.mkSVGStyleAttr<'Props> "fill" f

   // static member inline fillOpacity (value: float) = Interop.mkSVGStyleAttr<'Props> "fillOpacity" value 
    static member inline fillOpacity (f: 'Props -> int) = Interop.mkSVGStyleAttr<'Props> "fillOpacity" f
    
    
    static member inline fontFamily (f: 'Props -> string) = Interop.mkSVGStyleAttr<'Props> "fontFamily" f
   
   // static member inline fontSize (value: int)  = Interop.mkSVGStyleAttr<'Props> "fontSize" value 
    static member inline fontSize (f: 'Props -> int) = Interop.mkSVGStyleAttr<'Props> "fontSize" f 
    
   // static member inline fontWeight (value: FontWeight) = Interop.mkSVGStyleAttr<'Props> "fontWeight" value 
    static member inline fontWeight (f: 'Props -> FontWeight) = Interop.mkSVGStyleAttr<'Props> "fontWeight" f

    static member inline opacity (f: 'Props -> float) = Interop.mkSVGStyleAttr<'Props> "opacity" f
    
    static member inline padding (f: 'Props -> int) = Interop.mkSVGStyleAttr<'Props> "padding" f 
   
    static member inline size (f: 'Props -> int) = Interop.mkSVGStyleAttr<'Props> "size" f
   // static member inline stroke (color: string) = Interop.mkSVGStyleAttr<'Props> "stroke" color 
    static member inline stroke (f: 'Props -> string) = Interop.mkSVGStyleAttr<'Props> "stroke" f

  //  static member inline strokeWidth (value: int) = Interop.mkSVGStyleAttr<'Props> "strokeWidth" value 
    static member inline strokeWidth (f: 'Props -> int) = Interop.mkSVGStyleAttr<'Props> "strokeWidth" f 

     static member inline strokeLineCap (f: 'Props ->  StrokeLineCap) = Interop.mkSVGStyleAttr<'Props> "strokeLinecap" f



type pieChartStyle = 
    inherit svgStyle<PieSlice>
    static member inline pieChartStyle() = ()



type PieChartStyle = Style<PieSlice> 


type lineStyle = 
    inherit svgStyle<Line> 

    static member inline lineStyle() = ()


type chartStyle = 
    inherit svgStyleBasic<Chart> 
    static member inline victoryChartStyle() = () 

type style = svgStyleBasic<BasicStyle>

type barStyle = 
    inherit svgStyle<Bar> 

    static member inline width (value: int) = Interop.mkSVGStyleAttr<Bar> "width" value



type tickStyle = 
    inherit svgStyle<Tick> 
    static member inline tickStyle() = ()

type symbolStyle = 
    inherit svgStyleBasic<LegendIcon>
   
    static member inline symbolType (value: SymbolType) = Interop.mkSVGStyleAttr<LegendIcon> "type" value


type pointStyle = 
    inherit svgStyle<Point> 

    static member inline pointStyle () =() 




type ScatterChartStyle = Style<Point> 


type labelStyle = 
    inherit svgStyle<Label>

    static member inline angle (value: int) = Interop.mkSVGStyleAttr<Label> "angle" value 
    static member inline verticalAnchor (value: VerticalAnchor) = Interop.mkSVGStyleAttr<Label> "verticalAnchor" value


