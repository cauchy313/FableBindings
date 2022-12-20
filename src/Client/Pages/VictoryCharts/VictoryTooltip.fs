module Pages.Victory.Tooltip

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

let sampleData = 
        [
          {| x = 1; y = 2|}
          {| x = 2; y = 3 |}
          {| x = 3; y = 5 |}
          {| x = 4; y = 4 |}
          {| x = 5; y = 7 |}
        ]


[<ReactComponent>]
let VictoryTooltipView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

        Bulma.title "VictoryTooltip"
        
        Bulma.subtitle "center" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> "HELLO")
            barChart.labelComponent [
                                        tooltip.center {| x = 225; y = 30 |}
                                        tooltip.pointerOrientation PointerOrientation.Bottom 
                                        tooltip.flyoutWidth 150 
                                        tooltip.flyoutHeight 50 
                                        tooltip.pointerWidth 150 
                                        tooltip.cornerRadius 0
                                    ]
        ]
        
        
        Bulma.subtitle "centerOffset" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"x: {bar.datum.x.toInt}, y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.dy 0 
                                        tooltip.centerOffset [ 
                                                                CenterOffset.X 25
                                                             ]
                                    ]
        ]
        
        Bulma.subtitle "constrainToVisibleArea" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> "These labels just go on, and on, and on...")
            barChart.labelComponent [
                                        tooltip.constrainToVisibleArea true
                                    ]
        ]
        
        
        Bulma.subtitle "cornerRadius" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.cornerRadius (fun tooltip -> tooltip.datum.x.toInt * 2)
                                    ]
        ]
        
        Bulma.subtitle "flyoutHeight" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.flyoutHeight 60
                                    ]
        ]

        Bulma.subtitle "flyoutPadding" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar ->  match (bar.datum.x.toInt % 2) = 0 with 
                                         | true -> [ $"x: {bar.datum.x.toInt}"
                                                     $"y: {bar.datum.y.toInt}"]
                                         | false -> [ $"y: {bar.datum.y.toInt}" ])

            barChart.labelComponent [
                                        tooltip.flyoutPadding (fun tooltip -> match tooltip.text.Length > 1 with 
                                                                              | true -> Padding(top = 0, bottom = 0, left = 7, right = 7)
                                                                              | false -> Padding(7) )
                                    ]
        ]
        
        Bulma.subtitle "flyoutStyle" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.flyoutStyle [ style.stroke color.tomato ; style.strokeWidth 2 ]
                                    ]
        ]
        
        Bulma.subtitle "flyoutWidth" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.flyoutWidth 90
                                    ]
        ]
        
        Bulma.subtitle "pointerLength" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.pointerLength 20
                                    ]
        ]

        Bulma.subtitle "pointerOrientation" 

        Victory.barChart [
            barChart.barWidth 20
            barChart.data sampleData 
            barChart.labels (fun bar -> $"{bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.pointerOrientation PointerOrientation.Right
                                        tooltip.dy 0 
                                        tooltip.dx -12 
                                        tooltip.pointerWidth 25 
                                        tooltip.flyoutHeight 25 
                                        tooltip.flyoutWidth 25
                                        tooltip.cornerRadius 0 
                                        tooltip.centerOffset [CenterOffset.X -50]
                                    ]
        ]
        
        
        Bulma.subtitle "pointerWidth" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.pointerWidth 20
                                    ]
        ]
        
        Bulma.subtitle "style" 

        Victory.barChart [
            barChart.data sampleData 
            barChart.labels (fun bar -> $"y: {bar.datum.y.toInt}")
            barChart.labelComponent [
                                        tooltip.style [ style.fill color.tomato]
                                    ]
        ]

    ]