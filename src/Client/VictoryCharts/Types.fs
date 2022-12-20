namespace Feliz.VictoryCharts 


open Fable.Core 
open Fable.Core.JsInterop
open Browser.Types



module Props2 = 

    let clone (props: 'Props) = 
            let e = createEmpty<'Props>
            let o = Fable.Core.JS.Constructors.Object.assign(e, props)
            unbox<'Props> o 
            


[<Erase; RequireQualifiedAccess>]
type Theme = 
    | Material 
    | Grayscale 



[<Erase; RequireQualifiedAccess>]
type X = 
    | String of string 
    | Int of int 
    | Float of float
     with member this.toInt =
            match this with 
            | Int i -> i 
            | otherwise -> failwith "X is not an integer"
          member this.toFloat = 
            match this with 
            | Float f -> f 
            | otherwise -> failwith "X is not a float"


[<Erase; RequireQualifiedAccess>]
type Index = 
    | Int of int 
    | Str of string 
    with member this.toInt = 
            match this with 
            | Int i -> i 
            | Str s -> s |> int

[<Erase; RequireQualifiedAccess>]
type Y = 
    | Int of int 
    | Float of float 
    with member this.toInt =
            match this with 
            | Int i -> i 
            | otherwise -> failwith "Y is not an integer"
         member this.toFloat = 
            match this with 
            | Float f -> f 
            | otherwise -> failwith "Y is not a float"

type Scalar =
        abstract x : X -> float 
        abstract y : Y -> float 

type ScalarProps = 
        abstract scale : Scalar
        abstract x : X with get, set 
        abstract y: Y with get, set




[<Erase; RequireQualifiedAccess>]
type TickValue = 
    | Int of int 
    | Float of float
    with member this.toInt =
            match this with 
            | Int i -> i 
            | otherwise -> failwith "TickValue is not an integer"
         member this.toFloat = 
            match this with 
            | Float f -> f 
            | otherwise -> failwith "TickValue is not a float"   

type Tick = 
    abstract tick : TickValue 
    abstract index : int 
    abstract ticks : TickValue array 
    


type Datum = 
    abstract y : Y 
    abstract x : X
    abstract _x : X 
    abstract _y : Y

type Datum<'Props> =    
    abstract props: 'Props


// VictoryScatter supplies the following props to its dataComponent: data, datum, index, origin, polar,scale, size, style, symbol, x, y
type ScatterProps = 
    abstract datum : Datum 
    abstract index : int 
    abstract x : float 
    abstract y : float 

[<StringEnum; RequireQualifiedAccess>]
type ColorScale =
    | Grayscale 
    | Qualitative 
    | Heatmap 
    | Warm 
    | Cool 
    | Red 
    | Blue 
    | Green 



[<StringEnum; RequireQualifiedAccess>]
type CartesianAreaInterpolation =
    | Basis 
    | Cardinal 
    | CatmullRom 
    | Linear 
    | MonotoneX 
    | MonotoneY 
    | Natural 
    | Step 
    | StepAfter 
    | StepBefore 

[<StringEnum; RequireQualifiedAccess>]
type CartesianLinearInterpolation =
    | Basis 
    | Bundle
    | Cardinal 
    | CatmullRom 
    | Linear 
    | MonotoneX 
    | MonotoneY 
    | Natural 
    | Step 
    | StepAfter 
    | StepBefore 


[<StringEnum; RequireQualifiedAccess>]
type PolarInterpolation =
    | Basis 
    | Cardinal 
    | CatmullRom 
    | Linear 
    

[<StringEnum; RequireQualifiedAccess>]
type SortOrder =
    | Ascending 
    | Descending
    


[<StringEnum; RequireQualifiedAccess>]
type LabelPlacement = 
    | Parallel 
    | Perpendicular 
    | Vertical 

[<StringEnum; RequireQualifiedAccess>]
type LabelPosition = 
    | StartAngle
    | EndAngle
    | Centroid    


[<StringEnum; RequireQualifiedAccess>]
type EventTarget = 
    | Data 
    | Labels



[<StringEnum; RequireQualifiedAccess>]
type FontWeight = 
    | Bold

[<Erase>]
type ISVGStyleProperty<'Props> = interface end

type BasicStyle = interface end
type Chart = interface end

type Style<'Props> = {
              Data: ISVGStyleProperty<'Props> list 
              Labels: ISVGStyleProperty<'Props> list 
              Parent: ISVGStyleProperty<'Props> list 
            }
    with member this.toJSObj = 

                createObj [
                        "parent" ==> (createObj !!this.Parent)                        
                        "data" ==> (createObj !!this.Data) 
                        "labels" ==> (createObj !!this.Labels)                        
                        ]

module Style = 

    let withData (props: ISVGStyleProperty<'Props> list  ) = 
                {
                    Data = props 
                    Labels = [] 
                    Parent = []
                }

    let withLabels (props: ISVGStyleProperty<'Props> list  ) = 
                {
                    Data = []
                    Labels = props
                    Parent = []
                }

    let setLabels (props: ISVGStyleProperty<'Props> list) (style: Style<'Props>) = 
            {style with Labels = props}

    let setData (props: ISVGStyleProperty<'Props> list) (style: Style<'Props>) = 
            {style with Data = props}


type ChartStyle = {
                    Parent: ISVGStyleProperty<Chart> list 
                    Background: ISVGStyleProperty<Chart> list
                  }

        with member this.toJSObj = 

                createObj [
                        "parent" ==> (createObj !!this.Parent)                        
                        "background" ==> (createObj !!this.Background)                                                
                        ]


// type StyleProps = 
//     abstract fill : string  with get, set

// /// The name of the component the event should be attached to. When events are specified in VictorySharedEvents or on a component that renders several Victory components as children (i.e. VictoryChart, VictoryGroup, VictoryStack), it is necessary to specify which child events should apply to. The given childName should match the name prop of a child component. This identifier can be given as a string, an array of strings, or as "all".   
// [<RequireQualifiedAccess>]
// type ChildName =
//     | Name of string 
//     | Names of string list 
//     | All 
//     with member this.toJSObj = 
//             match this with 
//             | Name str -> box str 
//             | Names strList -> strList 
//                                 |> List.toArray 
//                                 |> box 
//             | All -> box "all"

// /// The type of element the event should be attached to. Valid targets for most Victory components will be "parent", "data", and "labels". Events with the "parent" target will be attached to to the top level svg. Events with "data" and "labels" targets will be attached to dataComponent and labelComponent elements respectively. Some components, like VictoryAxis use non-standard targets like "grid". Refer to individual API docs for additional caveats.
// [<StringEnum; RequireQualifiedAccess>]
// type TargetType = 
//     | Parent 
//     | Data 
//     | Labels 
//     | Grid 


// [<RequireQualifiedAccess>]
// type EventKey = 
//     | Str of string 
//     | StrList of string list 
//     | Number of int 
//     | NumberList of int list 
//     | All  
//      with member this.toJSObj = 
//             match this with 
//             | Str str -> box str 
//             | StrList strList -> strList 
//                                 |> List.toArray 
//                                 |> box 
//             | All -> box "all"
//             | Number i -> box i 
//             | NumberList i -> i 
//                               |> List.toArray 
//                               |> box  





// type DataMutationProps = 
//     abstract datum : Datum with get, set
//     abstract style : StyleProps with get, set 

// module DataMutationProps = 
    

//     let clone (props: DataMutationProps) = 
//           Props.clone props 


// type Mutator<'Props> = 
//         {
//           condition: 'Props -> bool 
//           mutator: 'Props -> 'Props
//         }
       
       
// type DataMutation = 
//     DataMutationProps -> DataMutationProps option 

// type LabelsMutationProps = 
//     abstract text : string with get,set 

// type LabelsMutation = 
//     LabelsMutationProps -> LabelsMutationProps option 

//  module LabelsMutationProps = 

//     let clone (props: LabelsMutationProps) = 
//             Props.clone props   

// type EventMutation = 
//     | MutatesDataBy of DataMutation
//     | MutatesChildDataBy of childName: string * mutation: DataMutation
//     | MutatesAllDataBy of DataMutation
//     | MutatesLabelsBy of LabelsMutation
//     with static member inline toJSobj (m : EventMutation) = 
//             match m with 
            
//             | MutatesChildDataBy (childName, mutation) -> 
//                         createObj [
//                                 "childName" ==> childName
//                                 "target" ==> EventTarget.Data  
//                                 "mutation" ==> mutation
//                           ]
//             | MutatesDataBy d ->   
//                         createObj [
//                                 "target" ==> EventTarget.Data  
//                                 "mutation" ==> d
//                           ]
//             | MutatesAllDataBy d -> 
//                         createObj [
//                                 "eventKey" ==> "all"
//                                 "target" ==> EventTarget.Data
//                                 "mutation" ==> d
//                         ]
            
//             | MutatesLabelsBy l -> 
//                         createObj  [
//                                 "target" ==> EventTarget.Labels 
//                                 "mutation" ==> l
//                                 ]


// type EventHandler = 
//     | OnClick of EventMutation list
//     with static member inline toJSobj (evs: EventHandler list) = 
//             let map (ev: EventHandler) = 
//                 match ev with 
//                 | OnClick ms -> "onClick" ==> fun () -> (ms |> List.toArray |> Array.map EventMutation.toJSobj)
                                   
//             evs
//             |> List.map map 
//             |> createObj


// type Event = 
//     | TargetsData of handlers: EventHandler list 
//     | TargetsLabels of handlers: EventHandler list
//     with static member inline toJSobj (ev: Event) = 
            
//             match ev with 
//             | TargetsData handlers ->     
//                                     createObj [
//                                         "target" ==> EventTarget.Data
//                                         "eventHandlers" ==> (handlers |> EventHandler.toJSobj)
//                                     ]
//             | TargetsLabels handlers -> 
//                                     createObj [
//                                         "target" ==> EventTarget.Labels
//                                         "eventHandlers" ==> (handlers |> EventHandler.toJSobj)
//                                     ]

// type BasicEvent =
//     | OnClick of handler: (MouseEvent -> unit)
//        with static member inline toJSobj (evts : BasicEvent list) =
//              keyValueList CaseRules.LowerFirst evts


type Duration = 
    {
        duration: int 
    }
    with member this.toJSObj = 
            createObj [
                "duration"  ==> this.duration
            ]

type Animate = 
    {
        duration : int 
        onLoad : Duration
    }
    with static member toJSobj (a: Animate) = 
                createObj [
                        "duration" ==> a.duration
                        "onLoad"   ==> a.onLoad.toJSObj

                ]


[<Erase>]
type PieSlice = 
    abstract datum : Datum
    abstract index : int
    abstract innerRadius : int 

[<Erase>]
type Tooltip = 
    abstract active : bool 
    abstract cornerRadius : int 
    abstract datum : Datum 
    abstract dx : int 
    abstract dy : int 
    abstract height : int 
    abstract id : string 
    abstract index : int 
    abstract text : string array
    abstract width : int 
    abstract x : float 
    abstract y : float 

[<Erase>]
type Label = 
    abstract index : Index
    abstract datum : Datum
    abstract text : string 
    abstract data : Datum array

[<Erase>]
type LabelArray = 
    abstract index : int 
    abstract textArray : string array 
    

[<Erase>]
type Text = 
    abstract data : {| datum : Datum |}


[<Erase>]
type IAreaChartProperty = interface end

[<Erase>]
type IAxisProperty = interface end 

[<Erase>]
type IPolarAxisProperty = interface end

[<Erase>]
type IPieChartProperty = interface end

[<Erase>]
type IBarChartProperty = interface end

[<Erase>]
type ILineChartProperty = interface end

[<Erase>]
type IChartContainerProperty = interface end

[<Erase>]
type IClipContainerProperty = interface end 

[<Erase>]
type IFlyoutProperty = interface end 

[<Erase>]
type IScatterChartProperty = interface end

[<Erase>]
type IStackProperty = interface end 

[<Erase>]
type ILabelProperty = interface end

[<Erase>]
type ILegendProperty = interface end

[<Erase>]
type IPointProperty = interface end

[<Erase>]
type IBarProperty = interface end

[<Erase>]
type ITooltipProperty = interface end

[<Erase>]
type ICommonChartProperty = inherit IPieChartProperty inherit IBarChartProperty inherit IChartContainerProperty





    

type Domain =
 { 
    Low: int 
    High: int
 }
 with  static member toJSObj (d: Domain) = 


               Fable.Core.JS.Constructors.Array.from( [| d.Low ; d.High |])


type DomainPadding = 
    {
      Left: int 
      Right: int 
    }
  with  member this.toJSObj  = 
         [| this.Left ; this.Right |] 

type DomainLimit = 
    {
     X: X option 
     Y: Y option
    }
     with member this.toJSObj = 
            createObj [
                        yield! this.X 
                                |> Option.map (fun x -> [ "x" ==> x])
                                |> Option.defaultValue []

                        yield! this.Y 
                                |> Option.map (fun y -> [ "y" ==> y ] )
                                |> Option.defaultValue []
                        
                                
                      ]


[<StringEnum; RequireQualifiedAccess>]
type TextAnchor = 
    | Start 
    | Middle 
    | End 
    | Inherit 

[<StringEnum; RequireQualifiedAccess>]
type TextDirection = 
    | Rtl
    | Ltr    
    | Inherit 


[<StringEnum; RequireQualifiedAccess>]
type VerticalAnchor = 
    | Start
    | Middle   
    | End 

[<StringEnum; RequireQualifiedAccess>]
type Scale = 
    | Linear 
    | Time 
    | Log 
    | Sqrt 

[<StringEnum; RequireQualifiedAccess>]
type SymbolType = 
    | Circle 
    | Diamond 
    | Plus 
    | Minus 
    | Square 
    | Star 
    | TriangleDown 
    | TriangleUp

type LegendIcon = interface end

type LegendDatum = {
    Name : string 
    Symbol : ISVGStyleProperty<LegendIcon> list 
    Label : ISVGStyleProperty<BasicStyle> list 
}
     with static member toJSobj (d: LegendDatum) = 
                createObj [
                        "name" ==> d.Name 
                        "symbol" ==> (createObj !!d.Symbol)
                        "labels" ==> (createObj !!d.Label) 
                ]

          static member withName (name: string) = 
                {Name = name; Symbol = []; Label = []}

          static member setSymbolTo (symbolStyle: ISVGStyleProperty<LegendIcon> list ) (datum: LegendDatum) = 
                {datum with Symbol = symbolStyle}

          static member setLabelTo (labelStyle: ISVGStyleProperty<BasicStyle> list ) (datum: LegendDatum) = 
                {datum with Label = labelStyle}


type AreaStyle = 
        {
            Data: ISVGStyleProperty<BasicStyle> list
            Labels: ISVGStyleProperty<Label> list
        }

        member this.toJSObj = 

                        createObj [
                                "data" ==> (createObj !!this.Data) 
                                "labels" ==> (createObj !!this.Labels)
                               
                        ]

[<Erase>]
type Line = 
    abstract data : Datum array


type LineStyle = 
        {
            Data: ISVGStyleProperty<Line> list
            Labels: ISVGStyleProperty<Label> list
            Parent : ISVGStyleProperty<BasicStyle> list
        }

        member this.toJSObj = 

                        createObj [
                                "data" ==> (createObj !!this.Data) 
                                "labels" ==> (createObj !!this.Labels)
                                "parents" ==> (createObj !!this.Parent)
                               
                        ]

type AxisStyle = 
        {
            Axis: ISVGStyleProperty<BasicStyle> list 
            AxisLabel: ISVGStyleProperty<BasicStyle> list 
            Grid : ISVGStyleProperty<Tick> list // tick 
            Ticks : ISVGStyleProperty<Tick> list // index
            Parent : ISVGStyleProperty<BasicStyle> list 
            TickLabels: ISVGStyleProperty<Label> list // text 
        }
        with static member blank () = 
                {
                  Axis = [] 
                  AxisLabel = [] 
                  Grid = [] 
                  Parent = [] 
                  Ticks = []
                  TickLabels = []
                }

              static member withAxis (style: ISVGStyleProperty<BasicStyle> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with Axis = style })
              
              static member setAxis (style: ISVGStyleProperty<BasicStyle> list ) (a: AxisStyle) = 
                      { a with Axis = style }
              
              static member withAxisLabel (style: ISVGStyleProperty<BasicStyle> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with AxisLabel = style })  

              static member setAxisLabel (style: ISVGStyleProperty<BasicStyle> list ) (a: AxisStyle) = 
                      { a with AxisLabel = style }

              static member withGrid (style: ISVGStyleProperty<Tick> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with Grid = style }) 
              
              static member setGrid (style: ISVGStyleProperty<Tick> list ) (a: AxisStyle) = 
                      { a with Grid = style }

              static member withTicks (style: ISVGStyleProperty<Tick> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with Ticks = style }) 

              static member setTicks (style: ISVGStyleProperty<Tick> list ) (a: AxisStyle) = 
                      { a with Ticks = style }
              
              static member withTickLabels (style: ISVGStyleProperty<Label> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with TickLabels = style }) 

              static member setTickLabels (style: ISVGStyleProperty<Label> list ) (a: AxisStyle) = 
                      { a with TickLabels = style }         
              
              static member withParent (style: ISVGStyleProperty<BasicStyle> list )  = 
                       AxisStyle.blank() 
                       |> (fun a -> { a with Parent = style }) 

              static member setParent (style: ISVGStyleProperty<BasicStyle> list ) (a: AxisStyle) = 
                      { a with Parent = style }             

              member this.toJSObj = 

                        createObj [
                                "parent" ==> (createObj !!this.Parent) 
                                "axis" ==> (createObj !!this.Axis)
                                "axisLabel" ==> (createObj !!this.AxisLabel) 
                                "grid" ==> (createObj !!this.Grid)
                                "ticks" ==> (createObj !!this.Ticks)
                                "tickLabels" ==> (createObj !!this.TickLabels)
                        ]


type LegendStyle = {
    Parent: ISVGStyleProperty<BasicStyle> list 
    Data : ISVGStyleProperty<BasicStyle> list 
    Border: ISVGStyleProperty<BasicStyle> list
    Labels: ISVGStyleProperty<Label> list 
    Title: ISVGStyleProperty<Label> list 
}
    with static member blank () = 
                {
                  Parent = [] 
                  Data = [] 
                  Border = [] 
                  Labels = [] 
                  Title = []
                }

         static member setDataTo (dataStyle: ISVGStyleProperty<BasicStyle> list ) (legendStyle: LegendStyle) = 
                       { legendStyle with Data = dataStyle }

         static member withData (dataStyle: ISVGStyleProperty<BasicStyle> list )  = 
                       LegendStyle.blank() 
                       |> (fun ls -> { ls with Data = dataStyle })
         
         static member setBorderTo (borderStyle: ISVGStyleProperty<BasicStyle> list ) (legendStyle: LegendStyle) = 
                       { legendStyle with Border = borderStyle }

         static member withBorder (borderStyle: ISVGStyleProperty<BasicStyle> list )  = 
                       LegendStyle.blank()
                       |> (fun ls -> { ls with Border = borderStyle })

         static member setLabelsTo (labelsStyle: ISVGStyleProperty<Label> list ) (legendStyle: LegendStyle) = 
                       { legendStyle with Labels = labelsStyle } 

         static member withLabels (labelsStyle: ISVGStyleProperty<Label> list )  = 
                       LegendStyle.blank() 
                       |> (fun ls -> { ls with Labels = labelsStyle })

         static member setTitleTo  (titleStyle: ISVGStyleProperty<Label> list ) (legendStyle: LegendStyle) = 
                       { legendStyle with Title = titleStyle } 

         static member withTitle  (titleStyle: ISVGStyleProperty<Label> list )  = 
                      LegendStyle.blank()
                      |> (fun ls -> { ls with Title = titleStyle }  )                                        
         
         member this.toJSObj = 

                createObj [
                        "parent" ==> (createObj !!this.Parent) 
                        "border" ==> (createObj !!this.Border)
                        "data" ==> (createObj !!this.Data) 
                        "labels" ==> (createObj !!this.Labels)
                        "title" ==> (createObj !!this.Title)
                ]





[<Erase>]
type Point = 
    abstract symbol : SymbolType
    abstract datum : Datum


[<StringEnum; RequireQualifiedAccess>]
type Orientation = 
    | Vertical 
    | Horizontal 


[<StringEnum; RequireQualifiedAccess>]
type AxisOrientation = 
    | Top
    | Bottom 
    | Left 
    | Right 

[<StringEnum; RequireQualifiedAccess>]
type TitleOrientation = 
    | Top
    | Bottom 
    | Left 
    | Right 
    
 
[<StringEnum; RequireQualifiedAccess>]
type Alignment = 
    | Start
    | Middle
    | End 

type Bar = 
    abstract index : int 
    abstract datum : Datum

[<RequireQualifiedAccess>]
type CornerRadius = 
    
    |  Top of  int 
    |  Bottom of  int 
    |  TopLeft of int 
    |  TopRight of int 
    |  BottomLeft of int 
    |  BottomRight of int 
    |  [<CompiledName("top")>] TopFunction of (Bar -> int)
    |  [<CompiledName("bottom")>] BottomFunction of (Bar -> int)
    |  [<CompiledName("topLeft")>] TopLeftFunction of (Bar -> int)
    |  [<CompiledName("topRight")>] TopRightFunction of (Bar -> int) 
    |  [<CompiledName("bottomLeft")>] BottomLeftFunction of (Bar -> int) 
    |  [<CompiledName("bottomRight")>] BottomRightFunction of (Bar -> int)
    
    with static member toJSObj (props: CornerRadius list) = 
            keyValueList CaseRules.LowerFirst props
            


[<StringEnum; RequireQualifiedAccess>]
type PointerOrientation = 
    | Top
    | Bottom
    | Left 
    | Right 

[<StringEnum; RequireQualifiedAccess>]
type TooltipOrientation = 
    | Top
    | Bottom 
    | Left 
    | Right      

[<RequireQualifiedAccess>]
type CenterOffset = 
    | X of int 
    | Y of int 
    | XFunction of (Tooltip -> int) 
    | YFunction of (Tooltip -> int)

    with static member toJSObj (props: CenterOffset list) = 
            keyValueList CaseRules.LowerFirst props

type ScatterDataProps = 
    abstract datum : Datum 
    abstract x : float 
    abstract y : float 
    




[<StringEnum; RequireQualifiedAccess>]
type StrokeLineCap =
    | Butt
    | Round
    | Square


type BasicStyleProps = 
        abstract border : string with get, set 
        abstract fill : string with get, set 
        abstract fillOpacity: float with get, set  
        abstract fontFamily : string with get, set 
        abstract fontSize : int with get, set 
        abstract fontWeight : FontWeight with get, set 
        abstract opacity : float with get, set 
        abstract padding : int with get, set 
        abstract size : int with get,set 
        abstract stroke : string with get, set 
        abstract strokeWidth: int with get, set 
        abstract strokeLineCap: StrokeLineCap with get, set 

type LabelStyleProps =
    inherit BasicStyleProps
    abstract angle : int with get, set 
    abstract verticalAnchor : VerticalAnchor with get, set 




type BarProps = 
    abstract index : int with get, set  
    abstract datum : Datum with get, set  
    abstract style : BasicStyleProps with get, set  
    


type LabelProps = 
    abstract index : Index with get, set 
    abstract datum : Datum with get, set
    abstract text : string with get, set  
    abstract data : Datum array  with get, set    


type Props<'Event,'Props,'EventKey> = 
    abstract event: 'Event
    abstract props: 'Props 
    abstract eventKey: 'EventKey list 





type Mutation<'Event, 'DataProps> =    
    | MutatesLabelsBy of (Props<'Event,LabelProps, string> -> LabelProps option)
    | MutatesDataBy of (Props<'Event,'DataProps, string> -> 'DataProps option)

module Mutation = 

    let toJSObj (mutation: Mutation<'Event, 'DataProps>) = 
            match mutation with             
            | MutatesLabelsBy m ->    createObj [
                                                        "target" ==> "labels"
                                                        "mutation" ==> (createObj !!m)                                                     
                                                ]

            | MutatesDataBy m ->      createObj [
                                                        "target" ==> "data"
                                                        "mutation" ==> (createObj !!m)                                                     
                                                ]                                

type EventHandler<'DataProps> = 
    | OnClick of Mutation<Browser.Types.MouseEvent,'DataProps> list 


module EventHandler = 

    let toJSObj (eh: EventHandler<'DataProps>) = 
            match eh with 
            | OnClick m ->      createObj  [
                                             "onClick" ==>  (m |> List.toArray 
                                                               |> Array.map Mutation.toJSObj)
                                           ]

type Event<'DataProps, 'ParentProps> = 
    | TargetsLabels of EventHandler<'DataProps> list 
    | TargetsData of EventHandler<'DataProps> list
    | TargetsParent of EventHandler<'DataProps> list 


module Event = 

    let toJSObj (e: Event<'DataProps,'ParentProps>) = 
            match e with 
            | TargetsLabels l -> createObj  [
                                             "target" ==> "labels"
                                             "eventHandlers" ==>  (l |> List.toArray 
                                                                     |> Array.map EventHandler.toJSObj)
                                           ]
            | TargetsData l ->  createObj  [
                                             "target" ==> "data"
                                             "eventHandlers" ==>  (l |> List.toArray 
                                                                     |> Array.map EventHandler.toJSObj)
                                           ]

            | TargetsParent l ->  createObj  [
                                             "target" ==> "parent"
                                             "eventHandlers" ==>  (l |> List.toArray 
                                                                     |> Array.map EventHandler.toJSObj)
                                           ]                              


type BarEvent<'ParentProps> = Event<BarProps, 'ParentProps>     
