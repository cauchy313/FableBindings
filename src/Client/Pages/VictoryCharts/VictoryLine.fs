module Pages.Victory.Line

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
let VictoryLineView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

        
        Bulma.subtitle "groupComponent"

        Victory.chartContainer [
            Victory.lineChart [
                lineChart.groupComponent [
                    clipContainer.clipPadding  (Padding(top = 5, right = 10))
                ]
                lineChart.style {
                                  Data = [lineStyle.stroke "#c43a31"; lineStyle.strokeWidth 15; lineStyle.strokeLineCap StrokeLineCap.Round ]
                                  Labels = [] 
                                  Parent = []
                                 }
                lineChart.data sampleData
            ]
        ]
        
        Bulma.subtitle "horizontal"

        Victory.lineChart [
            lineChart.data sampleData 
            lineChart.horizontal true
        ]

        Bulma.subtitle "interpolation"

        Victory.lineChart [
            lineChart.data sampleData 
            lineChart.interpolation CartesianLinearInterpolation.Natural   
        ]

        
        Bulma.subtitle "labelComponent"

        Victory.lineChart [
            lineChart.data sampleData 
            lineChart.labels (fun label -> $"{label.datum.y.toInt}")
            lineChart.labelComponent [
                    label.renderInPortal true 
                    label.dy -20
            ]
        ]
        
        Bulma.subtitle "labels" 

        Victory.lineChart [
            lineChart.data sampleData 
            lineChart.labels (fun label -> $"{label.datum.y.toInt}")
        ]
        
        Bulma.subtitle "maxDomain" 


        Victory.chartContainer [
            chartContainer.maxDomain { X = None; Y = Some(Y.Float 4.5)}
            chartContainer.children [
                Victory.lineChart [
                    lineChart.data sampleData
                ]
            ]
        ]
        
        
        
        Bulma.subtitle "minDomain" 


        Victory.chartContainer [
            chartContainer.minDomain { X = None; Y = Some(Y.Int 0)}
            chartContainer.children [
                Victory.lineChart [
                    lineChart.data sampleData
                ]
            ]
        ]
        
        Bulma.subtitle "polar" 

        Victory.chartContainer [
            chartContainer.polar true 
            chartContainer.domain {| y = {Low = 0; High = 7}|}
            chartContainer.theme Theme.Material 

            chartContainer.children [
                Victory.polarAxis [
                    polarAxis.dependentAxis true  
                    polarAxis.style (AxisStyle.withAxis [style.stroke "none"])
                    polarAxis.tickFormat (fun _ -> null)
                ]
                Victory.lineChart [
                    lineChart.data sampleData 
                    lineChart.style {
                                      Data = [lineStyle.stroke "#c43a31" ]
                                      Labels = [] 
                                      Parent = []
                                    }
                ]
            ]
        ]
        
        Bulma.subtitle "samples"

        Victory.chartContainer [
            Victory.lineChart [
                lineChart.samples 25
                lineChart.y' (fun (d: {| x : float|}) -> System.Math.Sin(5.0 * System.Math.PI * d.x) |> Y.Float)
                
            ]

            Victory.lineChart [
                lineChart.samples 100
                lineChart.style  { Data =  [lineStyle.stroke "red"] ; Labels = [] ; Parent = [] }
                lineChart.y' (fun (d: {| x : float |}) -> System.Math.Cos(5.0 * System.Math.PI * d.x) |> Y.Float)
            ]
        ]
        
        
        Bulma.subtitle "sortKey"

        Victory.lineChart [
            lineChart.data ( Seq.initInfinite (fun i -> 0.0 + (float i) * (0.01))
                                |> Seq.takeWhile (fun i -> i <= 2.0 * System.Math.PI)
                                |> Seq.map (fun i -> {| t = i |}))

            lineChart.sortKey "t" 

            lineChart.x' (fun (d: {| t : float |}) ->  System.Math.Sin( 3.0 * d.t + (2.0 * System.Math.PI) ) |> X.Float ) 

            lineChart.y' (fun (d: {| t : float |}) ->  System.Math.Sin(2.0 * d.t) |> Y.Float)
            

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
                Victory.lineChart [
                    lineChart.standalone false 
                    lineChart.width 300 
                    lineChart.height 300 
                    lineChart.padding (Padding(0))
                    lineChart.data sampleData

                ]
            ]
        ]
        // Victory.lineChart [
        //     lineChart.style {
        //                       Data = [ lineStyle.stroke "#c43a31"; lineStyle.strokeWidth (fun line -> line.data.Length) ]
        //                       Labels = [ labelStyle.fontSize 15 ; labelStyle.fill (fun label -> match label.datum.x.toInt = 3 with 
        //                                                                                         | true -> "#000000" 
        //                                                                                         | false -> "#c43a31")]
        //                       Parent = []
        //                     }
        //     lineChart.data sampleData 
        //     lineChart.labels (fun label -> $"{label.datum.x.toInt}")
        // ]

        
        
        Bulma.subtitle "style"

        Victory.lineChart [
            lineChart.style {
                              Data = [ lineStyle.stroke "#c43a31"; lineStyle.strokeWidth (fun line -> line.data.Length) ]
                              Labels = [ labelStyle.fontSize 15 ; labelStyle.fill (fun label -> match label.datum.x.toInt = 3 with 
                                                                                                | true -> "#000000" 
                                                                                                | false -> "#c43a31")]
                              Parent = []
                            }

            lineChart.data sampleData 
            lineChart.labels (fun label -> $"{label.datum.x.toInt}")
        ]

        

    ]
