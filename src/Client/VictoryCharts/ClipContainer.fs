namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type clipContainer =
              
      
        static member inline children (components: ReactElement list) = Interop.mkClipContainerAttr "children" components 

        static member inline clipPadding (value: Padding) = Interop.mkClipContainerAttr "clipPadding" value.toJSObj