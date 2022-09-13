module Fable.DownloadJS.Tests 


open Browser
open Fable.DownloadJS 
open Fable.Core.JS



let plainText() = downloadAsText (Data.Text "hello world") "dlText.txt"

let dataURLText() = downloadAsText (Data.DataURL "data:text/plain,hello%20world") "dlDataUrlText.txt"

let blobText() = downloadAsText (Data.Blob (Blob.Create([| box "hello world"|]))) "dlTextBlob.txt"


let arrayText() = 
     
     let str  = "hello world" 
     let arr = Constructors.Uint8Array.Create(str.Length)
     do str.ToCharArray() 
          |> FSharp.Collections.Array.iteri (fun i c -> arr.[i] <- byte c)
     

     downloadAsText (Data.TypedArray arr) "dlTypedArray.txt"


     