module Pages.Victory.AreaChart

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
let VictoryAreaChartView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

            Bulma.title "VictoryArea" 

            Victory.chartContainer [
                chartContainer.theme Theme.Material 
                chartContainer.children [
                    Victory.areaChart [
                        areaChart.style {
                                         Data = [ style.fill "#c43a31" ]
                                         Labels =[]
                                        }
                        areaChart.data sampleData
                    ]
                ]

            ]
            
            Bulma.subtitle "data" 

            Victory.chartContainer [
                Victory.areaChart [
                    areaChart.data  [
                                     {| x = 1; y = 2; y0 = 0 |}
                                     {| x = 2; y = 3; y0 = 1 |}
                                     {| x = 3; y = 5; y0 = 1 |}
                                     {| x = 4; y = 4; y0 = 2 |}
                                     {| x = 5; y = 6; y0 = 2 |}
                                    ]
                ]
            ]
            
            // Bulma.subtitle "events" 

            // Html.div [
            //     prop.style [ style.margin 50 ]
            //     prop.children [
            //         Html.h3 "Click Me" 
            //         Victory.areaChart [
            //             areaChart.style {
            //                               Data = [ style.fill "#c43a31" ]
            //                               Labels = []
            //                             }
            //             areaChart.events [
            //                     TargetsData [
            //                                   EventHandler.OnClick [
            //                                                         MutatesAllDataBy (fun props -> match props.style.fill = color.black with 
            //                                                                                         | true -> None 
            //                                                                                         | false -> 
            //                                                                                                 let newStyle = jsOptions<StyleProps>(fun p -> p.fill <- color.black )
            //                                                                                                 let newProps = jsOptions<DataMutationProps>(fun p -> p.datum <- props.datum 
            //                                                                                                                                                      p.style <- newStyle  )
                                                                                                            
            //                                                                                                 Some newProps )                                                                    
            //                                                       ]
            //                                 ]
            //                     ]
            //             areaChart.data sampleData
            //         ]
            //     ]
            // ]
            
            Bulma.subtitle "groupComponent" 

            Victory.chartContainer [
                Victory.areaChart [
                    areaChart.groupComponent [ 
                                                clipContainer.clipPadding (Padding(top = 5, right = 10))

                                             ]
                    areaChart.style {
                                     Data = [ style.stroke "#c43a31" ; style.strokeWidth 15; style.strokeLineCap StrokeLineCap.Round]
                                     Labels = []
                                     }
                    areaChart.data sampleData
                ]
            ]
            
            Bulma.subtitle "horizontal" 

            Victory.areaChart [
                areaChart.horizontal true 
                areaChart.data sampleData
            ]


            Bulma.subtitle "interpolation" 

            Victory.areaChart [
                areaChart.interpolation CartesianAreaInterpolation.Natural 
                areaChart.data sampleData 
            ]

            Bulma.subtitle "labelComponent" 

            Victory.areaChart [
                areaChart.data sampleData 
                areaChart.labels (fun label -> $"{label.datum.y.toInt}")
                areaChart.labelComponent [
                                            label.renderInPortal true 
                                            label.dy -20
                                         ]
            ]
            
            Bulma.subtitle "labels" 

            Victory.areaChart [ 
                areaChart.data sampleData 
                areaChart.labels (fun label ->  match label.index.toInt = (label.data.Length - 1) with 
                                                | true -> "last label" 
                                                | false -> $"{label.index}")
            ]
            
            Bulma.subtitle "maxDomain" 

            Victory.chartContainer [
                chartContainer.maxDomain { X = Some(X.Int 3); Y = None}
                chartContainer.children [
                    Victory.areaChart [
                        areaChart.data sampleData
                    ]
                ]
            ]
            
            Bulma.subtitle "minDomain" 

            Victory.chartContainer [
                chartContainer.minDomain { X = Some(X.Int 2); Y = None}
                chartContainer.children [
                    Victory.areaChart [
                        areaChart.data sampleData
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
                        polarAxis.tickFormat (fun _ -> null)                        
                    ]
                    Victory.areaChart [
                        areaChart.data sampleData 
                        areaChart.style {
                                         Data = [ style.fill "#c43a31"]
                                         Labels = []
                                        }
                        
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
                    Victory.areaChart [
                        areaChart.standalone false 
                        areaChart.width 300 
                        areaChart.height 300 
                        areaChart.padding (Padding(0))
                        areaChart.data sampleData
                    ]
                ]
            ]
            
            Bulma.subtitle "style" 

            Victory.areaChart [
                areaChart.style {
                                 Data = [ style.fill "#c43a31" ; style.fillOpacity 0.7 ; style.stroke "#c43a31"; style.strokeWidth 3]
                                 Labels = [ labelStyle.fontSize 15 
                                            labelStyle.fill (fun label -> match label.datum.x.toInt = 3 with 
                                                                          | true -> "#000000"
                                                                          | false -> "#c43a31")]
                                }
                areaChart.data sampleData 
                areaChart.labels (fun label -> $"{label.datum.x.toInt}")
            ]
            
            Bulma.subtitle "y0"

            Victory.chartContainer [
               Victory.areaChart [
                    areaChart.data sampleData 
                    areaChart.y0 (fun datum -> datum.y.toInt - 1
                                                |> Y.Int )
               ]
            ]
    ]  