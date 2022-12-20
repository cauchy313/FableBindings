namespace Feliz.VictoryCharts

open Fable.Core 


[<Erase;RequireQualifiedAccess>]
module Interop =    
   
    let inline mkVictoryAttr (key: string) (value: obj) : ICommonChartProperty = unbox (key, value)
    let inline mkAreaChartAttr (key: string) (value: obj) : IAreaChartProperty = unbox (key, value)
    let inline mkPieChartAttr (key: string) (value: obj) : IPieChartProperty = unbox (key, value)
    let inline mkBarChartAttr (key: string) (value: obj) : IBarChartProperty = unbox (key, value)
    let inline mkLineChartAttr (key: string) (value: obj) : ILineChartProperty = unbox (key, value)
    let inline mkChartContainerAttr (key: string) (value: obj) : IChartContainerProperty = unbox (key, value)
    let inline mkClipContainerAttr (key: string) (value: obj) : IClipContainerProperty = unbox (key, value)
    let inline mkSVGStyleAttr<'Props> (key: string) (value: obj) : ISVGStyleProperty<'Props> = unbox (key, value)
    let inline mkLabelAttr (key: string) (value: obj) : ILabelProperty = unbox (key,value) 
    let inline mkScatterChartAttr (key: string) (value: obj) : IScatterChartProperty = unbox (key,value) 
    let inline mkLegendAttr (key: string) (value: obj) : ILegendProperty = unbox (key,value) 
    let inline mkPointAttr (key: string) (value: obj) : IPointProperty = unbox (key, value) 
    let inline mkBarAttr (key: string) (value: obj) : IBarProperty = unbox (key, value) 
    let inline mkTooltipAttr (key: string) (value: obj) : ITooltipProperty = unbox (key, value) 
    let inline mkFlyoutAttr (key: string) (value: obj) : IFlyoutProperty = unbox (key, value) 
    let inline mkAxisAttr (key: string) (value: obj) : IAxisProperty = unbox (key,value)
    let inline mkPolarAxisAttr (key: string) (value: obj) : IPolarAxisProperty = unbox (key, value)
    let inline mkStackAttr (key: string) (value: obj) : IStackProperty = unbox (key, value)