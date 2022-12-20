namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type label =
        
        
        static member inline angle (value: int) = Interop.mkLabelAttr "angle" value 

        static member inline backgroundComponent (el: ReactElement) = Interop.mkLabelAttr "backgroundComponent" el 

        static member inline backgroundPadding (value: int) = Interop.mkLabelAttr "backgroundPadding" value 

        static member inline backgroundPadding (value: Padding) = Interop.mkLabelAttr "backgroundPadding" value.toJSObj 

        static member inline backgroundPadding (values: seq<Padding>) = Interop.mkLabelAttr "backgroundPadding" (values |> Seq.toArray |> Array.map (fun bp -> bp.toJSObj))


        static member inline backgroundStyle (properties: ISVGStyleProperty<BasicStyle> list) =
                Interop.mkLabelAttr "backgroundStyle" (createObj !!properties)

        static member inline backgroundStyle (values: list<ISVGStyleProperty<BasicStyle> list> ) = Interop.mkLabelAttr "backgroundStyle" (values |> List.toArray |> Array.map (fun p -> createObj !!p))
        
        static member inline capHeight (value: int) = Interop.mkLabelAttr "capHeight" value 
        static member inline capHeight (f: Label -> int) = Interop.mkLabelAttr "capHeight" f
        
        static member inline className (value: string) = Interop.mkLabelAttr "className" value 

        static member inline desc (value: string) = Interop.mkLabelAttr "desc" value

        static member inline direction (value: TextDirection) = Interop.mkLabelAttr "direction" value 


        static member inline dx (value: int) = Interop.mkLabelAttr "dx" value 
        static member inline dx (value: float) = Interop.mkLabelAttr "dx" value
        static member inline dx (f: Label -> int) = Interop.mkLabelAttr "dx" f 
        static member inline dx (f: LabelArray -> float) = Interop.mkLabelAttr "dx" f

        static member inline dy (value: int) = Interop.mkLabelAttr "dy" value 
        static member inline dy (value: float) = Interop.mkLabelAttr "dy" value
        static member inline dy (f: Label -> int) = Interop.mkLabelAttr "dy" f 
        static member inline dy (f: LabelArray -> float) = Interop.mkLabelAttr "dy"

     //   static member inline events (evts: BasicEvent list) = Interop.mkLabelAttr "events" (evts |> BasicEvent.toJSobj)


        static member inline groupComponent (properties: ISvgAttribute list) = 
                let el =  Svg.svg [
                                    Svg.g properties
                                ] 
                Interop.mkLabelAttr "groupComponent" el

        static member inline id (value: int) = Interop.mkLabelAttr "id" value 
        static member inline id (value :string) = Interop.mkLabelAttr "id" value 

        static member inline isInline (isTrue: bool) = Interop.mkLabelAttr "inline" isTrue 

        
        static member inline labelPlacement (value: LabelPlacement) = Interop.mkLabelAttr "labelPlacement" value 
        
        static member inline lineHeight (value: int) = Interop.mkLabelAttr "lineHeight" value 
        static member inline lineHeight (values: int list) = Interop.mkLabelAttr "lineHeight" (values |> List.toArray)
        static member inline lineHeight (f: Label -> int) = Interop.mkLabelAttr "lineHeight" f
        
        static member inline renderInPortal (isTrue: bool) = Interop.mkLabelAttr "renderInPortal" isTrue 
        
        static member inline style (properties: ISVGStyleProperty<BasicStyle> list) =
                Interop.mkLabelAttr "style" (createObj !!properties)

        static member inline style (propertiesList: ISVGStyleProperty<BasicStyle> list list) =
                let newList = propertiesList 
                                |> List.map (fun pl -> createObj !!pl)
                                |> List.toArray 

                Interop.mkLabelAttr "style" newList

        static member inline tabIndex (value: int) = Interop.mkLabelAttr "tabIndex" value 

        static member inline text (value: string) = Interop.mkLabelAttr "text" value 
        static member inline text (values: string list) = Interop.mkLabelAttr "text" (values |> List.toArray)
        static member inline text (f: Label -> string) = Interop.mkLabelAttr "text" f 
        static member inline text (f: Label -> string list) = 
                        let g = (fun (l: Label) ->  l   
                                                                    |> f 
                                                                    |> List.toArray)
                        Interop.mkLabelAttr "text" g
        
        static member inline textAnchor (value: TextAnchor) = Interop.mkLabelAttr "textAnchor" value 
        static member inline textAnchor (f: Label -> TextAnchor) = Interop.mkLabelAttr "textAnchor" f 

        
        static member inline textComponent (el: ReactElement) = Interop.mkLabelAttr "textComponent" el
        
        static member inline transform (value: string) = Interop.mkLabelAttr "transform" value 
        static member inline transform (f: Label -> string) = Interop.mkLabelAttr "transform" f 

        static member inline verticalAnchor (value: VerticalAnchor) = Interop.mkLabelAttr "verticalAnchor" value 
        static member inline verticalAnchor (f: Label -> VerticalAnchor) = Interop.mkLabelAttr "verticalAnchor" f

        static member inline scaledX (value: int) = 
                
               
                Interop.mkLabelAttr "x"  value
                                                                                     
        static member inline scaledX (value: float) = Interop.mkLabelAttr "x" (box($"this.scale.x({value})"))

        static member inline scaledY (value: int) = Interop.mkLabelAttr "y" (box($"this.scale.y({value})"))
        static member inline scaledY (value: float) = Interop.mkLabelAttr "y" (box($"this.scale.y({value})"))

        static member inline x (value: int) = Interop.mkLabelAttr "x" value 
        static member inline x (value: float) = Interop.mkLabelAttr "x" value 

        static member inline y (value: int) = Interop.mkLabelAttr "y" value 
        static member inline y (value: float) = Interop.mkLabelAttr "y" value 