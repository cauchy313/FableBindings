namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop




[<Erase>]
type commonVictoryProps =
        
        static member inline height (value: int) = Interop.mkVictoryAttr "height" value
        
        static member inline width (value: int) = Interop.mkVictoryAttr "width" value 

        static member inline standalone (isTrue: bool) = Interop.mkVictoryAttr "standalone" isTrue
        
        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkVictoryAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkVictoryAttr "theme" el?grayscale