module Pages.Victory.BarChart

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


[<ReactComponent>]
let VictoryBarChartView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

        
        Bulma.title "VictoryBar" 

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            chartContainer.domainPadding {| x = Some(10); y = None |}

            chartContainer.children [
                Victory.barChart [
                    
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"])
                    barChart.data sampleData
                ]
            ]
        ]
        
        
        Bulma.subtitle "alignment" 

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            
            chartContainer.children [
                Victory.barChart [
                    
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"])
                    barChart.alignment Alignment.Start
                    barChart.data sampleData
                ]
            ]
        ]


        Bulma.subtitle "barRatio" 

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            chartContainer.domainPadding {| x = Some(15); y = None |}
            chartContainer.children [
                Victory.barChart [
                    barChart.barRatio 0.8
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"])
                    barChart.data sampleData
                ]
            ]
        ]
        
        
        Bulma.subtitle "barWidth" 

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            chartContainer.domainPadding {| x = Some(20); y = None |}
            chartContainer.children [
                Victory.barChart [
                    barChart.barWidth (fun bar -> bar.index * 2 + 8)
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"])
                    barChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "cornerRadius"

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            chartContainer.domainPadding {| x = Some(15); y = None|}
            chartContainer.children [
                Victory.barChart [
                    barChart.cornerRadius [
                                            CornerRadius.TopLeftFunction (fun bar -> bar.datum.x.toInt * 4)
                                          ]
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"; barStyle.width 25 ])
                    barChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "data"

        Victory.barChart [
            barChart.data [
                            {| x = 1; y = 2; y0 = 1|}
                            {| x = 2; y = 3; y0 = 2|}
                            {| x = 3; y = 5; y0 = 2|}
                            {| x = 4; y = 4; y0 = 3|}
                            {| x = 5; y = 6; y0 = 3|}
                         ]
        ]
        
        
        Bulma.subtitle "events" 

        Html.div [
            Html.h3 "Click Me"
            Victory.barChart [
                barChart.style (Style.withData [barStyle.fill "#c43a31" ])
                barChart.events [
                                TargetsData [
                                              EventHandler.OnClick [
                                                                    MutatesDataBy (fun bar -> match bar.props.style.fill = color.black with 
                                                                                                | true -> None 
                                                                                                | false -> 
                                                                                                           let newStyle = jsOptions<BasicStyleProps>(fun p -> p.fill <- color.black )
                                                                                                           let newProps = jsOptions<BarProps>(fun p -> p.datum <- bar.props.datum
                                                                                                                                                       p.index <- bar.props.index     
                                                                                                                                                       p.style <- newStyle  )
                                                                                                          
                                                                                                           Some newProps )                                                                    
                                                                  ]
                                            ]
                                ]
                barChart.data sampleData
            ]
        ]
        
        Bulma.subtitle "horizontal"

        Victory.chartContainer [
            chartContainer.theme Theme.Material 
            chartContainer.domainPadding {| x = Some(10); y = None |}
            chartContainer.children [
                Victory.barChart [
                    barChart.horizontal true 
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"])
                    barChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "labelComponent"

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"{bar.datum.y.toInt}")
            barChart.style (Style.withLabels [ barStyle.fill color.white ])
            barChart.labelComponent [
                                      label.dy 30
                                    ]
        ] 
        
        Bulma.subtitle "labels"

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
        ]
        
        Bulma.subtitle "maxDomain"

        Victory.chartContainer [
            chartContainer.maxDomain { X = Some(X.Int 3); Y = None}
            chartContainer.children [
                Victory.barChart [
                    barChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "minDomain"

        Victory.chartContainer [
            chartContainer.minDomain { X = Some(X.Int 2); Y = None}
            chartContainer.children [
                Victory.barChart [
                    barChart.data sampleData
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
                Victory.barChart [
                    barChart.data sampleData 
                    barChart.style (Style.withData [ barStyle.fill "#c43a31"; barStyle.stroke color.black; barStyle.strokeWidth 2 ])

                ]
            ]
        ]

        Bulma.subtitle "standalone"

        Svg.svg [
            svg.width 300 
            svg.height 300 
            svg.children [
                Svg.circle [
                    svg.cx 150 
                    svg.cy 150 
                    svg.r 150 
                    svg.fill "#c43a31"
                ]
                Victory.barChart [
                    barChart.standalone false 
                    barChart.width 300 
                    barChart.height 300 
                    barChart.padding (Padding(left = 10, right = 10))
                    barChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "style"

        Victory.barChart [
            barChart.style ( Style.withData [
                                                barStyle.fill (fun bar -> match bar.datum.x.toInt = 3 with 
                                                                            | true -> "#000000"
                                                                            | false -> "#c43a31" )
                                                barStyle.stroke (fun bar -> match (bar.index % 2) = 0 with 
                                                                            | true -> "#000000"
                                                                            | false -> "#c43a31")
                                                barStyle.fillOpacity 0.7 
                                                barStyle.strokeWidth 3
                                            ]
                                |> Style.setLabels
                                            [
                                                barStyle.fontSize 15 
                                                barStyle.fill (fun bar -> match bar.datum.x.toInt = 3 with 
                                                                            | true -> "#000000" 
                                                                            | false -> "#c43a31")
                                            ]
                            ) 
            barChart.data sampleData 
            barChart.labels (fun props -> props.datum.x.toInt |> string)
        ]

        
        Bulma.subtitle "y0"

        Victory.chartContainer [
            chartContainer.domainPadding 30
            chartContainer.children [
                Victory.barChart [
                    barChart.data sampleData
                    barChart.y0 (fun datum -> Y.Int(datum.y.toInt - 1))
                ]
            ]
        ]
    ]