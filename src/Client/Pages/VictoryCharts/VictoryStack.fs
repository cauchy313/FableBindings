module Pages.Victory.Stack

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
let VictoryStackView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [ 

            Bulma.title "VictoryStack" 

            Victory.stack [
                Victory.areaChart [
                    areaChart.data [ 
                                    {| x = "a" ; y = 2|}
                                    {| x = "b" ; y = 3|}
                                    {| x = "c" ; y = 5|}
                    ]
                ]
                Victory.areaChart [
                     areaChart.data [ 
                                    {| x = "a" ; y = 1|}
                                    {| x = "b" ; y = 4|}
                                    {| x = "c" ; y = 5|}
                    ]
                ]
                Victory.areaChart [
                     areaChart.data [ 
                                    {| x = "a" ; y = 3|}
                                    {| x = "b" ; y = 2|}
                                    {| x = "c" ; y = 6|}
                        ]
                ]
            ]

            Bulma.subtitle "colorScale" 

            Victory.stack [
                stack.colorScale ["tomato"; "orange"; "gold"]
                stack.children [
                    Victory.barChart [
                        barChart.data [ 
                                        {| x = "a" ; y = 2|}
                                        {| x = "b" ; y = 3|}
                                        {| x = "c" ; y = 5|}
                        ]
                    ]
                    Victory.barChart [
                        barChart.data [ 
                                        {| x = "a" ; y = 1|}
                                        {| x = "b" ; y = 4|}
                                        {| x = "c" ; y = 5|}
                        ]
                    ]
                    Victory.barChart [
                        barChart.data [ 
                                        {| x = "a" ; y = 3|}
                                        {| x = "b" ; y = 2|}
                                        {| x = "c" ; y = 6|}
                            ]
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
            

    ]  