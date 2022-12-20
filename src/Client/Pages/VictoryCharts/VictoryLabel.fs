module Pages.Victory.Label

open Feliz
open Feliz.Bulma
open Elmish
open Feliz.UseElmish
open Feliz.VictoryCharts

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


let DataLabel (props: ScalarProps) = 
        let x = props.scale.x(props.x) 
        let y = props.scale.y(props.y)

        Victory.label [
            label.x x 
            label.y y 
            label.dy 10
            label.text "a custom data coordinate label"

        ]




[<ReactComponent>]
let VictoryLabelView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])


    Html.div [

        Bulma.title "VictoryLabel"
        
        Bulma.subtitle "angle"
        Victory.scatterChart [
            scatterChart.domain {Low = -10 ; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}]    
            scatterChart.labels "This is a label"            
            scatterChart.labelComponent [
                                     label.angle -45 
                                     label.textAnchor TextAnchor.End 
                                   ]
        ]    |> graphBox

        Bulma.subtitle "backgroundPadding" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                            "This is a"
                                            "multi-line"
                                            "label"
                                        ])

            scatterChart.labelComponent [
                                     label.dy -20 
                                     label.textAnchor TextAnchor.Start 
                                     label.backgroundPadding  [
                                                                Padding(3)
                                                                Padding(left = 20, right = 20)                                                                     
                                                                Padding(left = 20)                                                               
                                                              ]                                                              
                                     label.backgroundStyle [
                                                             [ style.fill color.red ; style.opacity 0.2]
                                                             [ style.fill color.green ; style.opacity 0.2 ]
                                                             [ style.fill color.blue ; style.opacity 0.2 ]
                                                           ]
                                   ]
        ]

        Bulma.subtitle "backgroundStyle" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                        "This is a"
                                        "multi-line"
                                        "label"
                                      ])
            scatterChart.labelComponent [
                label.backgroundStyle [
                                        style.fill color.pink
                                      ]
                label.backgroundPadding (Padding(3))
            ]
        ]

        Bulma.subtitle "dx" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                        "This is a"
                                        "multi-line"
                                        "label"
                                      ])
            scatterChart.style  (Style.withLabels [ pointStyle.padding 0] )
                            
            scatterChart.labelComponent [
                label.dx 20 
                label.textAnchor TextAnchor.Start 
                label.verticalAnchor VerticalAnchor.Middle
            ]
        ]

        Bulma.subtitle "dy" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                            "This is a"
                                            "multi-line"
                                            "label"
                                        ])
            scatterChart.style  (Style.withLabels [ pointStyle.padding 0] )
                           
            scatterChart.labelComponent [
                label.dy 20 
                label.textAnchor TextAnchor.End
                label.verticalAnchor VerticalAnchor.Start
            ]
        ]

        Bulma.subtitle "inline" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                            "This is a"
                                            "multi-line"
                                            "label"
                                        ])            

            scatterChart.labelComponent [
                label.isInline true
                label.style [
                              [ style.fill color.red ]
                              [ style.fill color.green ]
                              [ style.fill color.blue ]
                            ]
            ]
        ]

        Bulma.subtitle "lineHeight" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                                "This is a"
                                                "multi-line"
                                                "label"
                                            ])            

            scatterChart.labelComponent [
                label.lineHeight [ 1; 1; 3]
                label.style [
                              [ style.fill color.red ]
                              [ style.fill color.green ]
                              [ style.fill color.blue ]
                            ]
            ]
        ]

        Bulma.subtitle "style" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [ {| x = 0; y = 0 |}] 
            scatterChart.labels (fun _ ->  [ 
                                        "This is a"
                                        "multi-line"
                                        "label"
                                      ])            

            scatterChart.labelComponent [                
                label.style [
                              [ style.fill color.red ; style.fontSize 25 ]
                              [ style.fill color.green ; style.fontFamily "monospace" ]                             
                            ]
            ]
        ]

        Bulma.subtitle "text" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [{| x = 0 ; y = 0 |}]
            scatterChart.labels true 

            scatterChart.labelComponent [
                                     label.text (fun props -> Fable.Core.JS.console.log props
                                                              let datum = props.datum 
                                                              [ 
                                                                $"x: {datum.x.toInt}"
                                                                $"y: {datum.y.toInt}"
                                                              ]  ) 
                                   ]
        ]

        Bulma.subtitle "textAnchor" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [{| x = 0 ; y = 0 |}]
            scatterChart.labels (fun _ -> [
                                       "This is a"
                                       "multi-line"
                                       "label"
                                     ])
            scatterChart.labelComponent [
                                     label.textAnchor (fun props -> match props.text.Length > 1 with 
                                                                    | true -> TextAnchor.Start 
                                                                    | false -> TextAnchor.Middle ) 
                                   ]
        ]

        Bulma.subtitle "transform" 
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [{| x = 0 ; y = 0 |}]
            scatterChart.labels (fun _ -> [
                                       "This is a"
                                       "multi-line"
                                       "label"
                                     ])
            scatterChart.labelComponent [
                                     label.transform "skewX(30)"
                                   ]
        ]
        
        Bulma.subtitle "verticalAnchor"
        Victory.scatterChart [
            scatterChart.domain {Low = -10; High = 10}
            scatterChart.data [{| x = 0 ; y = 0 |}]
            scatterChart.labels (fun _ -> [
                                       "This is a"
                                       "multi-line"
                                       "label"
                                     ])
            scatterChart.labelComponent [
                                     label.verticalAnchor (fun props -> match props.text.Length > 1 with 
                                                                        | true -> VerticalAnchor.Start 
                                                                        | false -> VerticalAnchor.Middle)
                                   ]                         
        ]

        Bulma.subtitle "x" 
        Victory.chartContainer [
            chartContainer.domain {Low = 0 ; High = 10}
            chartContainer.children [
                        Victory.scatterChart [ 
                            scatterChart.data [ {| x = 5; y = 5|}]
                        ]
                        Victory.lineChart [] 
                        Victory.compElement DataLabel {| x = X.Int(5); y = Y.Int(5) |}                       
                        Victory.label [
                            label.x 55 
                            label.y 50
                            label.text "an svg coordinate label"
                        ]
            ]
           
            
        ]
    ]