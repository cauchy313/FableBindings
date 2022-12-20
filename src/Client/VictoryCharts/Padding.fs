namespace Feliz.VictoryCharts 

open Browser.Types
open Feliz
open Fable.Core
open Fable.Core.JsInterop


type Padding = class 

    val private top : int option
    val private bottom : int option
    val private right : int option
    val private left : int option
    
    new (?top : int , ?bottom : int , ?right : int, ?left : int ) = {
        top = top
        bottom = bottom 
        right = right 
        left = left 
    }
    new(value: int) = {
        top = Some(value) 
        bottom = Some(value)
        right = Some(value) 
        left = Some(value)
    }

    member this.toJSObj = 
        
                  createObj
                          [ 
                          yield!    this.top 
                                          |> Option.map (fun t -> ["top" ==> t])
                                          |> Option.defaultValue []
                          yield!    this.bottom
                                          |> Option.map (fun b -> ["bottom" ==> b])
                                          |> Option.defaultValue []

                          yield!    this.left 
                                          |> Option.map (fun l -> ["left" ==> l])
                                          |> Option.defaultValue []

                          yield!    this.right 
                                          |> Option.map (fun r -> ["right" ==> r])
                                          |> Option.defaultValue []            

                          ]

end 
