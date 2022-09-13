module Fable.DownloadJS


open Browser.Types
open Fable.Core
open Fable.Core.JS



[<Erase; RequireQualifiedAccess>]
type Data = 
    | Blob of Blob
    | TypedArray of Uint8Array
    | Text of string 
    | DataURL of string 

[<RequireQualifiedAccess>]
type MIMEType = 
    | PDF
    | Txt
    | Zip 
    | Unknown of string 
    with member inline this.toJSObj = 
            match this with 
            | PDF -> "application/pdf"
            | Txt -> "text/plain"
            | Zip -> "application/zip"
            | Unknown str -> str

[<ImportDefault("downloadjs")>]
let private downloadRaw(data:Data, filename: string, mimeType: string) : unit  = jsNative

let download (mimeType: MIMEType) (data: Data) (filename: string)  = 
    downloadRaw(data, filename, mimeType.toJSObj)
   



let downloadAsPDF data fileName =
    download MIMEType.PDF data fileName


let downloadAsZip data fileName =
    download MIMEType.Zip data fileName

let downloadAsText data fileName = 
    download MIMEType.Txt data fileName