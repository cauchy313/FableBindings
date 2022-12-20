namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type tooltip =
        
        
        static member inline active (isTrue: bool) = Interop.mkTooltipAttr "active" isTrue 

        static member inline activateData (isTrue: bool) = Interop.mkTooltipAttr "activateData" isTrue 

        static member inline angle (value: int) = Interop.mkTooltipAttr "angle" value 

        static member inline center (value: {| x : int ; y : int|}) = Interop.mkTooltipAttr "center" value 

        static member inline centerOffset (values: CenterOffset list) = Interop.mkTooltipAttr "centerOffset" (values |> CenterOffset.toJSObj)
        
        static member inline constrainToVisibleArea (isTrue: bool) = Interop.mkTooltipAttr "constrainToVisibleArea" isTrue 

        static member inline cornerRadius (value: int) = Interop.mkTooltipAttr "cornerRadius" value 
        static member inline cornerRadius (f: Tooltip -> int) = Interop.mkTooltipAttr "cornerRadius" f
        
        static member inline dx (value: int) = Interop.mkTooltipAttr "dx" value 
        static member inline dx (f: Tooltip -> int) = Interop.mkTooltipAttr "dx" f

        static member inline dy (value: int) = Interop.mkTooltipAttr "dy" value 
        static member inline dy (f: Tooltip -> int) = Interop.mkTooltipAttr "dy" f
        
    //    static member inline events (evts: BasicEvent list) = Interop.mkTooltipAttr "events" (evts |> BasicEvent.toJSobj)

        static member inline flyoutComponent (properties: IFlyoutProperty list) = 
                    let el =  Interop.reactApi.createElement(import "Flyout" "victory", createObj !!properties)
                    Interop.mkTooltipAttr "flyoutComponent" el 
        
        static member inline flyoutHeight (value: int) = Interop.mkTooltipAttr "flyoutHeight" value 
        static member inline flyoutHeight (f: Tooltip -> int) = Interop.mkTooltipAttr "flyoutHeight" f
        
        static member inline flyoutPadding (value: Padding) = Interop.mkTooltipAttr "flyoutPadding" value.toJSObj 
        static member inline flyoutPadding (f: Tooltip -> Padding) = 
                            let g = (fun (t: Tooltip) ->  let padding = f t 
                                                          padding.toJSObj)
                            Interop.mkTooltipAttr "flyoutPadding" g
        
        static member inline flyoutStyle (properties: ISVGStyleProperty<BasicStyle> list) = 
                 Interop.mkTooltipAttr "flyoutStyle" (createObj !!properties)
        
        static member inline flyoutWidth (value: int) = Interop.mkTooltipAttr "flyoutWidth" value 
        static member inline flyoutWidth (f: Tooltip -> int) = Interop.mkTooltipAttr "flyoutWidth" f 

        static member inline groupComponent (properties: ISvgAttribute list) = 
                let el =  Svg.svg [
                                    Svg.g properties
                                ] 
                Interop.mkTooltipAttr "groupComponent" el
        
        static member inline horizontal (isTrue: bool) = Interop.mkTooltipAttr "horizontal" isTrue 

        static member inline index (value: int) = Interop.mkTooltipAttr "index" value 
        static member inline index (value: string) = Interop.mkTooltipAttr "index" value
        
        static member inline labelComponent (props: ILabelProperty list) = 
            let el =  Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!props)
            Interop.mkTooltipAttr "labelComponent" el 
        
        static member inline orientation (value: TooltipOrientation) = Interop.mkTooltipAttr "orientation" value 
        static member inline orientation (f: Tooltip -> TooltipOrientation) = Interop.mkTooltipAttr "orientation" f 
        
        static member inline pointerLength (value: int) = Interop.mkTooltipAttr "pointerLength" value 
        static member inline pointerLength (f: Tooltip -> int) = Interop.mkTooltipAttr "pointerLength" f
        
        static member inline pointerOrientation (value: PointerOrientation) = Interop.mkTooltipAttr "pointerOrientation" value 
        static member inline pointerOrientation (f: Tooltip -> PointerOrientation) = Interop.mkTooltipAttr "pointerOrientation" f
        
        static member inline pointerWidth (f: Tooltip -> int) = Interop.mkTooltipAttr "pointerWidth" f
        static member inline pointerWidth (value: int) = Interop.mkTooltipAttr "pointerWidth" value 

        static member inline renderInPortal (isTrue: bool) = Interop.mkTooltipAttr "renderInPortal" isTrue 

        static member inline style (properties: ISVGStyleProperty<BasicStyle> list) = 
                 Interop.mkTooltipAttr "style" (createObj !!properties)

        static member inline text (value: string) = Interop.mkTooltipAttr "text" value 
        static member inline text (values: string list) = Interop.mkTooltipAttr "text" (values |> List.toArray)
        static member inline text (f: Tooltip -> string) = Interop.mkTooltipAttr "text" f 
        static member inline text (f: Tooltip -> string list) = 
                        let g = (fun (l: Tooltip) ->  l   
                                                                    |> f 
                                                                    |> List.toArray)
                        Interop.mkLabelAttr "text" g

        static member inline x (value: int) = Interop.mkTooltipAttr "x" value 
        
        static member inline y (value: int) = Interop.mkTooltipAttr "y" value  