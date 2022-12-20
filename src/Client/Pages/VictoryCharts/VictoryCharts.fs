module Pages.VictoryCharts

open Feliz
open Feliz.Bulma
open Elmish
open Feliz.UseElmish
open Feliz.VictoryCharts

type State = { 
                DropDownOpen : bool
                Charts : ReactElement option }


type Msg = 
    | ShowAxis
    | ShowLabel
    | ShowLegend
    | ShowBarChart
    | ShowPieChart
    | ShowScatterChart
    | ShowAreaChart
    | ShowTooltip
    | OpenDropdown

let init () = 

        {
         DropDownOpen = false 
         Charts = None }, Cmd.none 


let update (msg: Msg) (state: State) : State * Cmd<Msg> = 
    match msg with 
    | ShowAxis -> {state with Charts = Victory.Axis.VictoryAxisView() |> Some
                              DropDownOpen = false }, Cmd.none
    
    | ShowLabel -> {state with Charts = Victory.Label.VictoryLabelView() |> Some
                               DropDownOpen = false }, Cmd.none

    | ShowLegend -> {state with Charts = Victory.Legend.VictoryLegendView() |> Some
                                DropDownOpen = false }, Cmd.none                           
    
    | ShowTooltip -> {state with Charts = Victory.Tooltip.VictoryTooltipView() |> Some
                                 DropDownOpen = false }, Cmd.none 
    | ShowBarChart -> {state with Charts = Victory.BarChart.VictoryBarChartView() |> Some
                                  DropDownOpen = false }, Cmd.none  
    | ShowPieChart -> {state with Charts = Victory.PieChart.VictoryPieChartView() |> Some
                                  DropDownOpen = false }, Cmd.none  
    | ShowScatterChart -> {state with Charts = Victory.ScatterChart.VictoryScatterChartView() |> Some
                                      DropDownOpen = false }, Cmd.none 
    | ShowAreaChart -> {state with Charts = Victory.AreaChart.VictoryAreaChartView() |> Some
                                   DropDownOpen = false }, Cmd.none                                                                                                  
    | OpenDropdown -> {state with DropDownOpen = true}, Cmd.none 


[<ReactComponent>]
let VictoryChartsView () = 

    let state, dispatch = React.useElmish(init , update, [|   |])

    Html.div [
        Bulma.dropdown [
            if state.DropDownOpen then 
                dropdown.isActive 
            
            prop.children [
                Bulma.dropdownTrigger [
                    Bulma.button.button [
                        prop.onClick (fun _ -> OpenDropdown |> dispatch)
                        prop.ariaHasPopup true
                        prop.ariaControls [| "victory-dropdown" |]
                        prop.children [
                            Html.span "Select An Example"
                            Bulma.icon [
                                    icon.isSmall
                                    prop.children [
                                        Html.i [
                                            prop.classes["fa"; "fa-angle-down"]
                                            prop.ariaHidden true
                                        ]
                                    ]
                                ]

                        ]
                    ]
                ]
                Bulma.dropdownMenu [
                    prop.role [|"menu"|]
                    prop.id "victory-dropdown"
                    prop.children [
                        Bulma.dropdownContent [
                            prop.style[
                                style.maxHeight 400
                                style.custom ("overflow", "auto")
                            ]
                            prop.children [
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryAxis Examples"
                                                    prop.onClick (fun _ -> ShowAxis |> dispatch)
                                            ] 
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryLabel Examples"
                                                    prop.onClick (fun _ -> ShowLabel |> dispatch)
                                            ] 
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryLegend Examples"
                                                    prop.onClick (fun _ -> ShowLegend |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryTooltip Examples"
                                                    prop.onClick (fun _ -> ShowTooltip |> dispatch)
                                            ]  
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryBar Examples"
                                                    prop.onClick (fun _ -> ShowBarChart |> dispatch)
                                            ]  
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryPie Examples"
                                                    prop.onClick (fun _ -> ShowPieChart |> dispatch)
                                            ] 
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryScatter Examples"
                                                    prop.onClick (fun _ -> ShowScatterChart |> dispatch)
                                            ] 
                                            Bulma.dropdownItem.a [
                                                    prop.text "VictoryArea Examples"
                                                    prop.onClick (fun _ -> ShowAreaChart |> dispatch)
                                            ] 
                                           ]
                            ]
                    ]
                ]    
            ]
        ]
            
        match state.Charts with 
            | None -> Html.none 
            | Some chart -> chart
        ]
    