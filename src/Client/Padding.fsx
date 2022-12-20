


 //0.0 .. (2.0*System.Math.PI), 0.1
let x = Seq.initInfinite (fun i -> 0.0 + (float i) * (0.1))
        |> Seq.takeWhile (fun i -> i <= 2.0 * System.Math.PI)
        |> Seq.toList



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
        {|
           top = this.top 
           bottom = this.bottom 
           right = this.right 
           left = this.left
        |}

end 


let p = Padding(top = 10) 

