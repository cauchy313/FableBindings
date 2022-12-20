namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop



[<Erase>]
type chartContainer =
              
      
        static member inline children (components: ReactElement list) = Interop.mkChartContainerAttr "children" components        

        static member inline domain (value: Domain) = Interop.mkChartContainerAttr "domain"  ( value |> Domain.toJSObj)
        static member inline domain (values: {| x : Domain; y: Domain |}) = Interop.mkChartContainerAttr "domain" ({| x = values.x |> Domain.toJSObj; y = values.y |> Domain.toJSObj |})
        static member inline domain (value: {| x : Domain |}) = Interop.mkChartContainerAttr "domain" {| x = value.x |> Domain.toJSObj |}
        static member inline domain (value: {| y : Domain |}) = Interop.mkChartContainerAttr "domain" {| y = value.y |> Domain.toJSObj|}

        static member inline domainPadding (value: int) = Interop.mkChartContainerAttr "domainPadding" value 
        static member inline domainPadding (value: DomainPadding) = Interop.mkChartContainerAttr "domainPadding" value.toJSObj 
        static member inline domainPadding (value: {| x : int option; y : int option |}) = Interop.mkChartContainerAttr "domainPadding" value
        static member inline domainPadding (value : {| x : DomainPadding option; y : DomainPadding option |}) = 
                                let o =  createObj [
                                                        yield! value.x
                                                                |> Option.map (fun x -> [ "x" ==> x.toJSObj ])
                                                                |> Option.defaultValue []

                                                        yield! value.y
                                                                |> Option.map (fun y -> [ "y" ==> y.toJSObj ] )
                                                                |> Option.defaultValue []
                                                        
                                                                
                                                ]
                                                
                                Interop.mkChartContainerAttr "domainPadding" o                                                       
        
        static member inline maxDomain (value: int) = Interop.mkChartContainerAttr "maxDomain" value
        static member inline maxDomain (value: DomainLimit) = Interop.mkChartContainerAttr "maxDomain" value.toJSObj
        
        static member inline minDomain (value: int) = Interop.mkChartContainerAttr "minDomain" value
        static member inline minDomain (value: DomainLimit) = Interop.mkChartContainerAttr "minDomain" value.toJSObj
        
        static member inline polar (isTrue: bool) = Interop.mkChartContainerAttr "polar" isTrue 
        
        static member inline scale (value: Scale) = Interop.mkChartContainerAttr "scale" value 
        static member inline scale (value: {| x: Scale; y: Scale |}) = Interop.mkChartContainerAttr "scale" value
        
        static member inline singleQuadrantDomainPadding (isTrue: bool) = Interop.mkChartContainerAttr "singleQuadrantDomainPadding" isTrue 
        
        
        static member inline startAngle (value: int) = Interop.mkChartContainerAttr "startAngle" value 

        static member inline style (value: ChartStyle) =  Interop.mkChartContainerAttr "style" value.toJSObj

        
        static member inline theme (value: Theme) = 
                let el = import "VictoryTheme" "victory"     
                        
                match value with 
                        | Theme.Material -> Interop.mkChartContainerAttr "theme" el?material
                        | Theme.Grayscale -> Interop.mkChartContainerAttr "theme" el?grayscale
