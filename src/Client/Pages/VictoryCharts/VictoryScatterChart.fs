module Pages.Victory.ScatterChart

open Feliz
open Feliz.Bulma
open Elmish
open Feliz.UseElmish
open Feliz.VictoryCharts
open Fable.Core.JsInterop

type State = { Stuff : string}


type Msg = 
    | DoNothing

let init () = {Stuff = ""}, Cmd.none 


let update (msg: Msg) (state: State) : State * Cmd<Msg> = 
    match msg with 
    | DoNothing -> state, Cmd.none 

let graphBox (chart: ReactElement) = 
    Html.div [
        
        prop.height 400
        prop.width 400
        prop.custom ("min-height", 400)
        prop.children [
           chart
        ]
    ]

let sampleData = 
        [
          {| x = 1; y = 2|}
          {| x = 2; y = 3 |}
          {| x = 3; y = 5 |}
          {| x = 4; y = 4 |}
          {| x = 5; y = 7 |}
        ]


let CatPoint (props: ScatterProps) = 
        
        let cat = match props.datum._y.toFloat >= 0.0 with 
                  | true -> "😻"
                  | false -> "😹" 

        Svg.text [
            svg.x props.x 
            svg.y props.y 
            svg.fontSize 30 
            svg.text cat
        ]


[<ReactComponent>]
let VictoryScatterChartView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

            
            Bulma.title "VictoryScatter" 


            Victory.chartContainer [
                chartContainer.theme Theme.Material 
                chartContainer.domain {| x = {Low = 0; High = 5}; y = {Low = 0; High = 7}|}
                chartContainer.children [
                    Victory.scatterChart [
                        scatterChart.style (Style.withData [ pointStyle.fill "#c43a31"])
                        scatterChart.size 7 
                        scatterChart.data [ 
                                            {| x = 1; y = 2 |}
                                            {| x = 2; y = 3 |}
                                            {| x = 3; y = 5 |}
                                            {| x = 4; y = 4 |}
                                            {| x = 5; y = 7 |}
                                          ]
                    ]
                ]
            ]
            
            Bulma.subtitle "bubbleProperty"

            Victory.scatterChart [
                scatterChart.style (Style.withData [ pointStyle.fill "#c43a31"])
                scatterChart.bubbleProperty "amount"
                scatterChart.maxBubbleSize 25
                scatterChart.minBubbleSize 5 
                scatterChart.data [
                                    {| x = 1; y = 2; amount = 30|}
                                    {| x = 2; y = 3 ; amount = 40|}
                                    {| x = 3; y = 5; amount = 25|}
                                    {| x = 4 ; y = 4; amount = 10|}
                                    {| x = 5; y = 7; amount = 45 |}
                ]
            ]
            
            
            Bulma.subtitle "data" 

            Victory.scatterChart [
                scatterChart.data [
                    {| x = 1 ; y = 2; symbol = SymbolType.Star; size = 5|}
                    {| x = 2 ; y = 3; symbol = SymbolType.Square; size =  7|}
                    {| x = 3 ; y = 5; symbol = SymbolType.Diamond; size = 3|}
                    {| x = 4 ; y = 4; symbol = SymbolType.Circle ; size = 8 |}
                    {| x = 5;  y = 6 ; symbol = SymbolType.TriangleUp; size = 4|}
                ]
            ]
            
            Bulma.subtitle "dataComponent" 

            Victory.chartContainer [
                chartContainer.children [
                    Victory.scatterChart [
                        scatterChart.dataComponent (Victory.compElement CatPoint None)
                        scatterChart.y (fun datum -> Fable.Core.JS.console.log datum
                                                     System.Math.Sin( 2.0 * System.Math.PI * datum.x.toFloat)
                                                     |> Y.Float )
                        scatterChart.samples 15
                    ]
                ]
            ]
            
            // Bulma.subtitle "events" 

            // Html.div [
            //     Html.h3 "Click Me"
            //     Victory.scatterChart [
            //         scatterChart.style (Style.withData [ pointStyle.fill  "#c43a31"])
            //         scatterChart.size 9 
            //         scatterChart.labels (fun _ -> null)
            //         scatterChart.events [
            //                     TargetsData [
            //                                   EventHandler.OnClick [
            //                                                         MutatesDataBy (fun props -> match props.style.fill = color.black  with 
            //                                                                                     | true -> None 
            //                                                                                     | false -> 
            //                                                                                                let newStyle = jsOptions<StyleProps>(fun p -> p.fill <- color.black  )
            //                                                                                                let newProps = jsOptions<DataMutationProps>(fun p -> p.datum <- props.datum 
            //                                                                                                                                                     p.style <- newStyle  )
                                                                                                          
            //                                                                                                Some newProps )                                                                    
                                                                  
            //                                                         MutatesLabelsBy (fun props -> match props.text = "clicked" with 
            //                                                                                       | true -> None 
            //                                                                                       | false -> let newProps = jsOptions<LabelsMutationProps>(fun p -> p.text <- "clicked")                                                                                                               
            //                                                                                                  Some newProps )
            //                                                       ]
            //                                 ]
            //                     ]
            //         scatterChart.data sampleData
            //     ]
            // ]


            Bulma.subtitle "groupComponent" 

            Victory.chartContainer [
                chartContainer.children [
                    Victory.scatterChart [
                        scatterChart.groupComponent []
                        scatterChart.data sampleData 
                        scatterChart.size 20
                    ]
                ]
            ]
            
            Bulma.subtitle "labelComponent"

            Victory.scatterChart [
                scatterChart.data sampleData 
                scatterChart.size 20 
                scatterChart.style (Style.withLabels [ pointStyle.fill color.white; pointStyle.fontSize 18])
                scatterChart.labels (fun point -> $"{point.datum.y.toInt}")
                scatterChart.labelComponent [
                                                label.dy 8
                                            ]
            ]
            
            Bulma.subtitle "labels"

            Victory.scatterChart [
                scatterChart.data sampleData 
                scatterChart.labels (fun point -> $"y: {point.datum.y.toInt}")
            ]


            Bulma.subtitle "maxDomain"

            Victory.chartContainer [
                chartContainer.maxDomain 8
                chartContainer.children [
                    Victory.scatterChart [
                        scatterChart.data sampleData
                    ]
                ]
            ]

            Bulma.subtitle "minDomain"

            Victory.chartContainer [
                chartContainer.minDomain 0
                chartContainer.children [
                    Victory.scatterChart [
                        scatterChart.data sampleData
                    ]
                ]
            ]

            Bulma.subtitle "polar"

            Victory.chartContainer [
                chartContainer.polar true 
                chartContainer.theme Theme.Material 
                chartContainer.children [
                    Victory.polarAxis [
                        polarAxis.dependentAxis true  
                        polarAxis.style (AxisStyle.withAxis [ style.stroke "none"])
                        polarAxis.tickFormat (fun _ -> System.String.Empty)

                    ]
                    Victory.scatterChart [
                        scatterChart.data sampleData 
                        scatterChart.style (Style.withData [ pointStyle.fill "#c43a31" ])
                        scatterChart.size 5
                    ]
                ]
            ]
            
            Bulma.subtitle "size"

            Victory.scatterChart [
                scatterChart.size (fun point ->  point.datum.y.toInt + 2)
                scatterChart.data sampleData
            ]


            Bulma.subtitle "standalone"

            Svg.svg [
                svg.width 350 
                svg.height 350 
                svg.children [
                    Svg.circle [
                        svg.cx 150 
                        svg.cy 150 
                        svg.r 150 
                        svg.fill "#c43a31"
                    ]
                    Victory.scatterChart [
                        scatterChart.standalone false 
                        scatterChart.width 300 
                        scatterChart.height 300 
                        scatterChart.padding (Padding(10))
                        scatterChart.data sampleData 
                        scatterChart.size 7
                    ]
                ]
            ]
            
            
            Bulma.subtitle "style" 

            Victory.scatterChart [
                scatterChart.style { 
                                     Data = [   pointStyle.fill (fun point -> match  point.datum.x.toInt = 3 with 
                                                                                    | true -> "#000000" 
                                                                                    | false -> "#c43a31")
                                                pointStyle.stroke (fun point -> match point.datum.x.toInt = 3 with 
                                                                                | true -> "#000000" 
                                                                                | false -> "#c43a31"  )
                                                pointStyle.fillOpacity 0.7 
                                                pointStyle.strokeWidth 3
                                            ]
                                     Labels = [ 
                                                pointStyle.fontSize 15 
                                                pointStyle.fill (fun point -> match point.datum.x.toInt = 3 with 
                                                                                | true -> "#000000" 
                                                                                | false -> "#c43a31"  ) 
                                              ]
                                     Parent = [] 
                                    }
                scatterChart.size 9 
                scatterChart.data sampleData 
                scatterChart.labels (fun label -> $"{label.datum.x.toInt}" )
                                  
            ]
            
            Bulma.subtitle "symbol"

            Victory.scatterChart [
                scatterChart.symbol (fun point -> match point.datum.y.toInt > 3 with 
                                                    | true -> SymbolType.TriangleUp 
                                                    | false -> SymbolType.TriangleDown)
                scatterChart.size 7 
                scatterChart.data sampleData
            ]
    ]
