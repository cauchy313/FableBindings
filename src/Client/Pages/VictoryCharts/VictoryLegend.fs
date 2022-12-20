module Pages.Victory.Legend

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

[<ReactComponent>]
let VictoryLegendView () = 

     let state, dispatch = React.useElmish(init , update, [|   |])

     Html.div [
        
            Bulma.title "VictoryLegend"

            Victory.chartContainer [
                chartContainer.domain {Low = 0 ; High = 10}
                chartContainer.children [
                    Victory.legend [
                        legend.x 125
                        legend.y 50 
                        legend.title "Legend" 
                        legend.centerTitle true 
                        legend.orientation Orientation.Horizontal 
                        legend.gutter 20 
                        legend.style ( LegendStyle.withBorder [ style.stroke color.black ]
                                        |> LegendStyle.setTitleTo [ labelStyle.fontSize 20])
                        legend.data [
                                      LegendDatum.withName "One"
                                        |> LegendDatum.setSymbolTo [ symbolStyle.fill color.tomato; symbolStyle.symbolType SymbolType.Star] 
                                       
                                      LegendDatum.withName "Two"
                                        |> LegendDatum.setSymbolTo [symbolStyle.fill color.orange]
                                        
                                      LegendDatum.withName "Three"
                                        |> LegendDatum.setSymbolTo [symbolStyle.fill color.gold]
                                       
                                    ]
                    ]
                    Victory.barChart [
                        barChart.data [ 
                              {| x = 2; y = 6; fill = "tomato"|}
                              {| x = 4; y = 4; fill = "orange"|}
                              {| x = 6; y = 2; fill = "gold"|}
                              {| x = 8; y = 4; fill = "tomato"|}      
                        ]
                    ]
                ]
            ]


            Bulma.subtitle "centerTitle"
            Victory.legend [ 
                legend.x 125 
                legend.y 10
                legend.title "Legend"
                legend.centerTitle true
                legend.orientation Orientation.Horizontal
                legend.gutter 20 
                legend.style ( LegendStyle.withBorder [ style.stroke color.black ]
                               |> LegendStyle.setTitleTo [ labelStyle.fontSize 20 ])
                
                legend.data [
                             LegendDatum.withName "One"
                             LegendDatum.withName "Two" 
                             LegendDatum.withName "Three"
                            ]
            ]

            Bulma.subtitle "colorScale"
            Victory.legend [ 
                legend.x 125 
                legend.y 10
                legend.orientation Orientation.Horizontal
                legend.gutter 20 
                legend.style (LegendStyle.withBorder [ style.stroke color.black ])
                legend.colorScale [ color.navy; color.blue; color.cyan ]
                legend.data [
                             LegendDatum.withName "One"
                             LegendDatum.withName "Two" 
                             LegendDatum.withName "Three"
                            ]
            ]

            Bulma.subtitle "data"
            Victory.legend [
                legend.orientation Orientation.Horizontal
                legend.gutter 20 
                legend.style (LegendStyle.withBorder [ style.stroke color.black])
                legend.data [
                              LegendDatum.withName "One"
                                |> LegendDatum.setSymbolTo [ symbolStyle.fill color.tomato; symbolStyle.symbolType SymbolType.Star ]
                              
                              LegendDatum.withName "Two" 
                                |> LegendDatum.setSymbolTo [ symbolStyle.fill color.orange ]
                                |> LegendDatum.setLabelTo [ style.fill color.orange]
                            
                              LegendDatum.withName "Three"
                                |> LegendDatum.setSymbolTo [ symbolStyle.fill color.gold]
                               
                            ]
            ]
            
            // Bulma.subtitle "events" 
            // Html.h3 "Click Me"
            // Victory.legend [
            //     legend.events [
            //                     TargetsData [
            //                                   EventHandler.OnClick [
            //                                                         MutatesDataBy (fun props -> match props.style.fill = "#c43a31" with 
            //                                                                                     | true -> None 
            //                                                                                     | false -> 
            //                                                                                                let newStyle = jsOptions<StyleProps>(fun p -> p.fill <- "#c43a31" )
            //                                                                                                let newProps = jsOptions<DataMutationProps>(fun p -> p.datum <- props.datum 
            //                                                                                                                                                     p.style <- newStyle  )
                                                                                                          
            //                                                                                                Some newProps )

            //                                                         MutatesLabelsBy (fun props -> match props.text = "clicked" with 
            //                                                                                       | true -> None 
            //                                                                                       | false -> let newProps = jsOptions<LabelsMutationProps>(fun p -> p.text <- "clicked")                                                                                                               
            //                                                                                                  Some newProps )
            //                                                     ]
            //                                 ]
            //                   ]
            //     legend.data [ 
            //                     LegendDatum.withName "One"
            //                     LegendDatum.withName "Two"
            //                     LegendDatum.withName "Three"                                
            //                 ]

            // ]
           
            
            Bulma.subtitle "gutter"

            Victory.legend [
                                                                                  
                legend.x 125
                legend.y 50 
                legend.orientation Orientation.Horizontal 
                legend.gutter 50
                legend.style (LegendStyle.withBorder [ style.stroke color.black ])
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"                                
                            ]
                
            ]
            
            
            Bulma.subtitle "itemsPerRow"

            Victory.legend [
                                                                                  
                legend.x 125
                legend.y 50 
                legend.itemsPerRow 3 
                legend.gutter 20
                legend.style (LegendStyle.withBorder [ style.stroke color.black ])
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                                LegendDatum.withName "Four"
                            ]
                
            ]
            
            
            Bulma.subtitle "labelComponent"

            Victory.legend [
                                                                                  
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
                legend.labelComponent [
                                        label.angle 45
                                      ]
            ]
            
            
            Bulma.subtitle "rowGutter"

            Victory.legend [
                legend.x 125 
                legend.y 50  
                legend.orientation Orientation.Vertical                           
                legend.gutter 20 
                legend.rowGutter {| top = 0 ; bottom = 10 |}
                legend.style (LegendStyle.withBorder [ style.stroke color.black ] )

                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
            ]


            Bulma.subtitle "style"

            Victory.legend [
                legend.x 125 
                legend.y 50 
                legend.title "Legend" 
                legend.centerTitle true 
                legend.orientation Orientation.Horizontal              
                legend.gutter 20 
                legend.style {
                                Data = [ style.fill color.blue; style.stroke color.navy; style.strokeWidth 2]
                                Labels = [ labelStyle.fill color.navy ]
                                Border = [ style.stroke color.black ]
                                Title = [ labelStyle.fontSize 20 ]
                                Parent = []
                             }                
                legend.data [ 
                                LegendDatum.withName "One"
                                    |> LegendDatum.setSymbolTo [ symbolStyle.fill color.tomato ]

                                LegendDatum.withName "Two"
                                    |> LegendDatum.setLabelTo [ style.fill color.orange ]
                                                                
                                LegendDatum.withName "Three"
                            ]
            ]

            Bulma.subtitle "symbolSpacer"

            Victory.legend [
                legend.x 125 
                legend.y 50 
                legend.symbolSpacer 5                
                legend.gutter 20 
                legend.orientation Orientation.Horizontal                
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
            ]
            
            Bulma.subtitle "title"

            Victory.legend [
                legend.x 125 
                legend.y 50 
                legend.title  "Legend Title"                 
                legend.gutter 20 
                legend.orientation Orientation.Horizontal
                legend.style (LegendStyle.withBorder [ style.stroke color.black]
                                |> LegendStyle.setTitleTo [  labelStyle.fontSize 20 ])
                                
                
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
            ]

            
            Bulma.subtitle "titleComponent"

            Victory.legend [
                legend.x 125 
                legend.y 50 
                legend.title [ "Legend Title" ; "subtitle" ]                   
                legend.gutter 20 
                legend.orientation Orientation.Horizontal
                legend.style (LegendStyle.withBorder [ style.stroke color.black])
                               
                legend.titleComponent [
                                        label.style [
                                                       [ style.fontSize 20 ]
                                                       [ style.fontSize 12 ] 
                                                    ]
                                      ]
                
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
            ]
            
            
            Bulma.subtitle "titleOrientation"

            Victory.legend [
                legend.x 50 
                legend.y 50 
                legend.title "Legend Title" 
                legend.titleOrientation TitleOrientation.Left  
                legend.gutter 20 
                legend.orientation Orientation.Horizontal

                legend.style (LegendStyle.withBorder [ style.stroke color.black]
                                |> LegendStyle.setTitleTo [ labelStyle.fontSize 20 ])                               
                legend.data [ 
                                LegendDatum.withName "One"
                                LegendDatum.withName "Two"
                                LegendDatum.withName "Three"
                            ]
            ]

      ]