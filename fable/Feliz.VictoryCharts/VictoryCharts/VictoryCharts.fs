namespace Feliz.VictoryCharts 


open Feliz
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Victory =
       
    static member inline pieChart (properties: #IPieChartProperty list) =
        Interop.reactApi.createElement(import "VictoryPie" "victory", createObj !!properties)        

    static member inline areaChart (properties: IAreaChartProperty list) = 
        Interop.reactApi.createElement(import "VictoryArea" "victory", createObj !!properties)
    static member inline barChart (properties: #IBarChartProperty list) = 
        Interop.reactApi.createElement(import "VictoryBar" "victory", createObj !!properties)

    static member inline chartContainer (properties: #IChartContainerProperty list) = 
        Interop.reactApi.createElement(import "VictoryChart" "victory", createObj !!properties) 

    static member inline chartContainer (els: ReactElement list) = 
         Interop.reactApi.createElement(import "VictoryChart" "victory", createObj [ "children" ==>  !!els ])

    static member inline clipContainer (properties: IClipContainerProperty list) = 
        Interop.reactApi.createElement(import "VictoryClipContainer" "victory", createObj !!properties) 

    static member inline label (properties: ILabelProperty list) = 
        Interop.reactApi.createElement(import "VictoryLabel" "victory", createObj !!properties)

    static member inline lineChart (properties: ILineChartProperty list) = 
        Interop.reactApi.createElement(import "VictoryLine" "victory", createObj !!properties)
    
    static member inline scatterChart (properties: IScatterChartProperty list) = 
        Interop.reactApi.createElement(import "VictoryScatter" "victory", createObj !!properties)

    static member inline stack (properties: IStackProperty list) = 
        Interop.reactApi.createElement(import "VictoryStack" "victory", createObj !!properties)
    
    static member inline stack (els: ReactElement list) = 
         Interop.reactApi.createElement(import "VictoryStack" "victory", createObj [ "children" ==>  !!els ])

    static member inline legend (properties: ILegendProperty list) = 
        Interop.reactApi.createElement(import "VictoryLegend" "victory", createObj !!properties)

    static member inline tooltip (properties: ITooltipProperty list) = 
        Interop.reactApi.createElement(import "VictoryTooltip" "victory", createObj !!properties)
       
    static member inline axis (properties: IAxisProperty list) = 
        Interop.reactApi.createElement(import "VictoryAxis" "victory", createObj !!properties) 
        
    static member inline polarAxis (properties: IPolarAxisProperty list) = 
        Interop.reactApi.createElement(import "VictoryPolarAxis" "victory", createObj !!properties)
    
    static member inline  compElement (comp: 'ParentProps -> ReactElement) (props: 'SuppliedProps) = 
            Interop.reactApi.createElement (box comp, !!props) 
        