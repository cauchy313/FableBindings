module Pages.Victory.PieChart

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
let VictoryPieChartView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

        Bulma.title "VictoryPie" 

        Victory.pieChart [
            pieChart.data [ {| x = "Cats" ; y = 35|}
                            {| x = "Dogs"; y = 40 |}
                            {| x = "Birds"; y = 55|}
                          ]
        ]
        
        
        Bulma.subtitle "colorScale" 

        Victory.pieChart [
            pieChart.colorScale [ "tomato"; "orange"; "gold"; "cyan"; "navy"]
            pieChart.data sampleData
        ]

        Bulma.subtitle "cornerRadius" 

        Victory.pieChart [
            pieChart.cornerRadius (fun slice -> slice.datum.y.toInt * 5)
            pieChart.data sampleData
        ]

        Bulma.subtitle "data"

        Victory.pieChart [
            pieChart.data [ 
                            {| x = 1; y = 2; label = "one"|}
                            {| x = 2; y = 3; label = "two"|}
                            {| x = 3; y = 5; label = "three" |}
                        ]
        ]
        
        Bulma.subtitle "endAngle"

        Html.div [
            Victory.pieChart [
                pieChart.startAngle 90
                pieChart.endAngle 450
                pieChart.data sampleData
            ]
            Victory.pieChart [
                pieChart.startAngle 90 
                pieChart.endAngle -90
                pieChart.data sampleData
            ]
        ]
        
        // Bulma.subtitle "events"

        // Html.div [
        //     Html.h3 "Click Me"
        //     Victory.pieChart [
        //         pieChart.data sampleData 
        //         pieChart.events [
        //                         TargetsData [
        //                                       EventHandler.OnClick [
        //                                                             MutatesDataBy (fun props -> match props.style.fill = "#c43a31"  with 
        //                                                                                         | true -> None 
        //                                                                                         | false -> 
        //                                                                                                    let newStyle = jsOptions<StyleProps>(fun p -> p.fill <- "#c43a31"  )
        //                                                                                                    let newProps = jsOptions<DataMutationProps>(fun p -> p.datum <- props.datum 
        //                                                                                                                                                         p.style <- newStyle  )
                                                                                                          
        //                                                                                                    Some newProps )                                                                    
                                                                  
        //                                                             MutatesLabelsBy (fun props -> match props.text = "clicked" with 
        //                                                                                           | true -> None 
        //                                                                                           | false -> let newProps = jsOptions<LabelsMutationProps>(fun p -> p.text <- "clicked")                                                                                                               
        //                                                                                                      Some newProps )
        //                                                           ]
        //                                     ]
        //                         ]
        //     ]
        // ]
        
        
        Bulma.subtitle "innerRadius"

        Victory.pieChart [            
            pieChart.data sampleData
            pieChart.innerRadius (fun slice -> slice.datum.y.toInt * 20)
        ]
        
        
        Bulma.subtitle "labelComponent"

        Victory.pieChart [            
            pieChart.data sampleData
            pieChart.labels (fun slice -> $"{slice.datum.y.toInt}")
            pieChart.labelComponent [
                                      label.angle 45
                                    ]
        ]
        
        
        Bulma.subtitle "labelPlacement"

        Victory.pieChart [            
            pieChart.data sampleData
            pieChart.labels (fun slice -> $"y: {slice.datum.y.toInt}")
            pieChart.labelPosition (fun slice -> match slice.index with 
                                                 | 0 -> LabelPosition.StartAngle 
                                                 | otherwise -> LabelPosition.Centroid)
            pieChart.labelPlacement (fun slice -> match slice.index with 
                                                  | 0 -> LabelPlacement.Vertical 
                                                  | otherwise -> LabelPlacement.Parallel)
        ]
        
        Bulma.subtitle "labelPosition"

        Victory.pieChart [            
            pieChart.data sampleData
            pieChart.labels (fun slice -> $"{slice.datum.y.toInt}")
            pieChart.labelPosition (fun slice -> match slice.index with 
                                                 | 0 -> LabelPosition.StartAngle 
                                                 | otherwise -> LabelPosition.Centroid)
        ]
        


        Bulma.subtitle "labelRadius"

        Victory.pieChart [
           
            pieChart.data sampleData
            pieChart.labelRadius (fun slice -> slice.innerRadius + 5 )
            pieChart.radius (fun slice -> 50 + (slice.datum.y.toInt * 20))
            pieChart.innerRadius 50 
            pieChart.style (Style.withLabels [pieChartStyle.fill color.white ; pieChartStyle.fontSize 20 ; pieChartStyle.fontWeight FontWeight.Bold ])
        ]


        Bulma.subtitle "labels"

        Victory.pieChart [
            pieChart.labels (fun slice -> $"y: {slice.datum.y.toInt}")
            pieChart.data sampleData
        ]
        
        Bulma.subtitle "origin"

        Victory.pieChart [
            pieChart.origin (y = 250)
            pieChart.padding (Padding(100))
            pieChart.data sampleData
        ]
        
        Bulma.subtitle "padAngle"

        Victory.pieChart [
            pieChart.padAngle (fun slice -> slice.datum.y.toInt)
            pieChart.innerRadius 100
            pieChart.data sampleData
        ]
        
        
        Bulma.subtitle "radius"

        Victory.pieChart [
            pieChart.radius (fun slice -> 20 + (slice.datum.y.toInt * 20))
            pieChart.data sampleData
        ]
        
        Bulma.subtitle "standalone"

        Svg.svg [
            svg.width 300 
            svg.height 300 
            svg.children [
                Svg.circle [
                    svg.cx 150 
                    svg.cy 150 
                    svg.r 50
                    svg.fill "#c43a31"
                ]
                Victory.pieChart [
                    pieChart.standalone false 
                    pieChart.width 300 
                    pieChart.height 300 
                    pieChart.innerRadius 75 
                    pieChart.data sampleData
                ]
            ]
        ]
        
        
        Bulma.subtitle "startAngle"

        Html.div [
            Victory.pieChart [
                pieChart.startAngle 90
                pieChart.endAngle 450
                pieChart.data sampleData
            ]
            Victory.pieChart [
                pieChart.startAngle 90 
                pieChart.endAngle -90
                pieChart.data sampleData
            ]
        ]
        
        Bulma.subtitle "style"

        Victory.pieChart [
            pieChart.style (Style.withData [ pieChartStyle.fillOpacity 0.9 ; pieChartStyle.stroke "#c43a31"; pieChartStyle.strokeWidth 3]
                                |> Style.setLabels [ pieChartStyle.fontSize 25; pieChartStyle.fill  "#c43a31"])
            
            pieChart.data sampleData
        ]




    ]