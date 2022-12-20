module Pages.Victory.Axis 

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

[<ReactComponent>]
let VictoryAxisView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [

        Bulma.title "VictoryAxis" 
        
        Svg.svg [
                 svg.width 400 
                 svg.height 400 
                 svg.children [
                    Victory.axis [
                        axis.crossAxis true 
                        axis.width 400 
                        axis.height 400 
                        axis.domain { Low = -10; High = 10}
                        axis.theme Theme.Material
                        axis.offsetY 200
                        axis.standalone false                  
                    ]
                    Victory.axis [
                        axis.dependentAxis true 
                        axis.crossAxis true 
                        axis.width 400 
                        axis.height 400 
                        axis.domain {Low = -10; High = 10}
                        axis.theme Theme.Material 
                        axis.offsetX 200 
                        axis.standalone false
                    ]
                 ]
        ]
        
        
        Bulma.subtitle "axisValue"
        Victory.chartContainer [
                chartContainer.children [
                    Victory.barChart [
                        barChart.style (Style.withData [
                                                        barStyle.fill color.tomato 
                                                        barStyle.width 25    
                                                        ] )
                                        
                        barChart.data  [
                                        {| x = "cat"; y = 10|}
                                        {| x = "dog"; y = 25|}
                                        {| x = "bird"; y = 40|}
                                        {| x = "frog"; y = 50|}
                                        {| x = "fish" ; y = 50 |}
                                    ]
                    ]
                    Victory.axis []
                    [ 
                    "cat"
                    "dog"
                    "bird"
                    "dog"
                    "frog"
                    "fish"
                    ] |> List.mapi (fun i d ->  Victory.axis [
                                                        axis.dependentAxis true
                                                        axis.key i
                                                        axis.label d
                                                        axis.style (AxisStyle.withTickLabels [ labelStyle.fill "none" ] )                                                                   
                                                        axis.axisValue d
                                                    ])
                    |> React.fragment
                ]
        ]
        
        Bulma.subtitle "dependentAxis"
        Victory.axis [
            axis.dependentAxis true           
        ] |> graphBox

        Bulma.subtitle "label"
        Victory.axis [
            axis.label "Time (ms)"
        ] |> graphBox

        Bulma.subtitle "maxDomain" 
        Victory.axis [
            axis.tickValues [ 2 ; 3 ; 4 ; 5]
            axis.maxDomain {| x = 3 |}
        ] |> graphBox

        Bulma.subtitle "minDomain" 
        Victory.axis [
            axis.tickValues [2 ; 3; 4 ;5 ]
            axis.minDomain {| x = 0 |}
        ] |> graphBox

        Bulma.subtitle "offsetX" 
        Victory.axis [
            axis.offsetX 225
        ] |> graphBox

        Bulma.subtitle "offsetY"
        Victory.axis [
            axis.offsetY 150
        ] |> graphBox
        
        Bulma.subtitle "orientation" 
        Victory.axis [
            axis.orientation AxisOrientation.Top
        ] |> graphBox 

        Bulma.subtitle "style"
        Victory.axis [
            axis.label "Label"            
            axis.style  {
                            Axis = [
                                     style.stroke "#756f6a"
                                   ] 
                            AxisLabel = [
                                          style.fontSize 20 
                                          style.padding 30
                                        ] 
                            Grid =  [
                                      tickStyle.stroke ( fun tickValue -> match tickValue.tick.toFloat > 0.5 with 
                                                                          | true -> color.red 
                                                                          | false -> color.gray )  
                                    ] 
                            Parent = [] 
                            Ticks = [
                                      tickStyle.stroke color.gray
                                      tickStyle.size 5                                        
                                    ]
                            TickLabels = [
                                          labelStyle.fontSize 15 
                                          labelStyle.padding 5
                                        ]
                        }
        ] |> graphBox
        
        Bulma.subtitle "tickFormat"
        Victory.axis [
            axis.tickValues [2.11; 3.9; 6.1; 8.05]
            axis.tickFormat (fun tick ->  $"{tick.toFloat |> System.Math.Round}k" )
        ] |> graphBox
        
        Bulma.subtitle "tickValues"
        Victory.axis [
            axis.tickValues [ 2 ; 4 ;6 ; 8]
        ] |> graphBox
      ]

    
