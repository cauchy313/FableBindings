module Pages.PdfLib

open System
open Feliz
open Feliz.Bulma
open Elmish
open Feliz.UseElmish
open Fable
open Fable.PdfLib 
open Fable.Core
open Fable.Core.JsInterop
open Fable.DownloadJS


type DisplayMetadata = {
    Title: string option
    Author: string option
    Subject: string option
    Creator: string option
    Keywords: string  option
    Producer: string option 
    CreationDate: DateTime option 
    ModificationDate: DateTime option
}


type DisplayPDF = {
        ByteArray: JS.Uint8Array 
        DataUri:  string
        Name: string 
} 

type DisplayData = 
    | PDF of DisplayPDF 
    | Metadata of DisplayMetadata

type State = {
                WorkingOnPDF : bool
                DropDownOpen: bool
                DisplayData: DisplayData option
                }

type Msg = 
    | CreateDocument of AsyncOperationStatus<DisplayPDF>
    | ModifyDocument of AsyncOperationStatus<DisplayPDF>
    | CreateForm of AsyncOperationStatus<DisplayPDF>
    | FillForm of AsyncOperationStatus<DisplayPDF>
    | FlattenForm of AsyncOperationStatus<DisplayPDF>
    | CopyPages of AsyncOperationStatus<DisplayPDF>
    | EmbedImages of AsyncOperationStatus<DisplayPDF>
    | EmbedPdfPages of AsyncOperationStatus<DisplayPDF>
    | HelloWorld of AsyncOperationStatus<DisplayPDF>
    | EmbedFontAndMeasureText of AsyncOperationStatus<DisplayPDF>
    | AddAttachments of AsyncOperationStatus<DisplayPDF>
    | SetDocumentMetadata of AsyncOperationStatus<DisplayPDF>
    | ReadDocumentMetadata of AsyncOperationStatus<DisplayMetadata>
    | DrawSVGPaths of AsyncOperationStatus<DisplayPDF>
    | OpenDropdown


let init () = 
    { 
     WorkingOnPDF = false
     DropDownOpen = false
     DisplayData = None} , Cmd.none 

let fetchArrayBuffer (url: string) = 
    Fetch.fetch url [] 
    |> Promise.bind (fun res -> res.arrayBuffer())


let helloWorld () = 
    promise {
        let! pdfDoc = PDFDocument.create() 

        let page = pdfDoc.addPage(width = 350.0, height = 400.0)
        do page.moveTo(110.0, 200.0) 
        do page.drawText "Hello World!" 

        let! pdfBytes = pdfDoc.save() 
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Hello World"
                }
    }

let createDocument ()  = 
    promise {
                let! pdfDoc = PDFDocument.create() 
                let! timesRomanFont = pdfDoc.embedFont(TimesRoman)

                let page = pdfDoc.addPage()

                let pageSize = page.getSize() 
                let fontSize = 30.0                

                do page.drawText("Creating PDFs in JavaScript is awesome!", 
                                 jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0 
                                                                              opt.y <- pageSize.height - 4.0 * fontSize 
                                                                              opt.font <- timesRomanFont
                                                                              opt.color <- Color.RGB (rgb(0.0,0.53,0.71))))                 
                                
                let! pdfBytes = pdfDoc.save() 
                let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

                return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Create Document"
                        }
    }



let modifyDocument ()  = 
    promise {
             let url = "https://pdf-lib.js.org/assets/with_update_sections.pdf"
             let! existingPdfBytes = fetchArrayBuffer url

             let! pdfDoc = PDFDocument.load  existingPdfBytes
             let! helveticaFont = pdfDoc.embedFont Helvetica
             
             let pages = pdfDoc.getPages() 
             let firstPage = pages.[0]
             let size = firstPage.getSize()       

             do firstPage.drawText("This text was added with JavaScript!", 
                                    jsOptions<PDFPageDrawTextOptions>(fun opts -> opts.x <- 5.0 
                                                                                  opts.y <- (size.height / 2.0) + 300.0
                                                                                  opts.size <- 50.0 
                                                                                  opts.font <- helveticaFont 
                                                                                  opts.color <- Color.RGB (rgb(0.95,0.1,0.1))
                                                                                  opts.rotate <- Rotation.Degrees (degrees(-45.0))))

             let! pdfBytes = pdfDoc.save() 

             let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

             return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Modify Document"
                        }


    }

let createForm () = 
    promise {
            let! pdfDoc = PDFDocument.create() 

            let page = pdfDoc.addPage (width = 555.0, height = 750.0)

            let form = pdfDoc.getForm()      

            do page.drawText("Enter your favorite superhero: ", 
                             jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0
                                                                          opt.y <- 700.0 
                                                                          opt.size <- 20.0))

            let superheroField = form.createTextField "favorite.superhero"
            do superheroField.setText "One Punch Man" 
            do superheroField.addToPage( page ,
                                         jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                      opt.y <- 640.0 ))
            
            do page.drawText("Select your favorite rocket: ", 
                             jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0
                                                                          opt.y <- 600.0 
                                                                          opt.size <- 20.0))
            
            
            do page.drawText("Falcon Heavy",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 120.0 
                                                                             opt.y <- 560.0
                                                                             opt.size <- 18.0 ))
            do page.drawText("Saturn IV",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 120.0 
                                                                             opt.y <- 500.0
                                                                             opt.size <- 18.0 ))
            do page.drawText("Delta IV Heavy",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 340.0 
                                                                             opt.y <- 560.0
                                                                             opt.size <- 18.0 ))                                                                                                                            
            do page.drawText("Space Launch System",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 340.0 
                                                                             opt.y <- 500.0
                                                                             opt.size <- 18.0 ))
             
            let rocketField = form.createRadioGroup "favorite.rocket"

            do rocketField.addOptionToPage("Falcon Heavy",
                                           page,
                                           jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                        opt.y <- 540.0 ))

            do rocketField.addOptionToPage("Saturn IV",
                                           page,
                                           jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                        opt.y <- 480.0 ))
            do rocketField.addOptionToPage("Delta IV Heavy",
                                           page,
                                           jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 275.0 
                                                                                        opt.y <- 540.0 ))
            do rocketField.addOptionToPage("Space Launch System",
                                           page,
                                           jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 275.0 
                                                                                        opt.y <- 480.0 ))
            do rocketField.select "Saturn IV" 

            do page.drawText("Select your favorite gundams: ", 
                             jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0
                                                                          opt.y <- 440.0 
                                                                          opt.size <- 20.0))

            
            do page.drawText("Exia",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 120.0 
                                                                             opt.y <- 400.0
                                                                             opt.size <- 18.0 ))
            do page.drawText("Kyrios",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 120.0 
                                                                             opt.y <- 340.0
                                                                             opt.size <- 18.0 ))
            do page.drawText("Virtue",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 340.0 
                                                                             opt.y <- 400.0
                                                                             opt.size <- 18.0 ))                                                                                                                            
            do page.drawText("Dynames",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 340.0 
                                                                             opt.y <- 340.0
                                                                             opt.size <- 18.0 ))
             
            
            let exiaField = form.createCheckBox "gundam.exia" 
            let kyriosField = form.createCheckBox "gundam.kyrios"
            let virtueField = form.createCheckBox "gundam.virtue"
            let dynamesField = form.createCheckBox "gundam.dynames"
            
            do exiaField.addToPage(page,
                                   jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                opt.y <- 380.0 )) 
            do kyriosField.addToPage(   page,
                                        jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                     opt.y <- 320.0 )) 
            do virtueField.addToPage(page,
                                     jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 275.0 
                                                                                  opt.y <- 380.0 )) 
            do dynamesField.addToPage(page,
                                      jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 275.0 
                                                                                   opt.y <- 320.0 )) 

            do exiaField.check() 
            do dynamesField.check() 

            
            do page.drawText("Select your favorite planet*: ",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0 
                                                                             opt.y <- 280.0
                                                                             opt.size <- 20.0 ))

            let planetsField = form.createDropdown "favorite.planet"
            do planetsField.addOptions [| 
                                        "Venus"
                                        "Earth"
                                        "Mars"
                                        "Pluto"
                                       |]

            do planetsField.select "Pluto"
            do planetsField.addToPage( page, 
                                       jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                    opt.y <- 220.0 )) 


            do page.drawText("Select your favorite person: ",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 50.0 
                                                                             opt.y <- 180.0
                                                                             opt.size <- 18.0 ))

            let personField = form.createOptionList "favorite.person"
            do personField.addOptions [| 
                                        "Julius Caesar"
                                        "Ada Lovelace"
                                        "Cleopatra"
                                        "Aaron Burr"
                                        "Mark Antony"
                                      |] 
            
            do personField.select "Ada Lovelace"
            do personField.addToPage( page, 
                                      jsOptions<FieldAppearanceOptions>(fun opt -> opt.x <- 55.0 
                                                                                   opt.y <- 70.0 ))   
            
            do page.drawText("* Pluto should be a planet too!",
                                jsOptions<PDFPageDrawTextOptions>(fun opt -> opt.x <- 15.0 
                                                                             opt.y <- 15.0
                                                                             opt.size <- 15.0 ))
            
            let! pdfBytes = pdfDoc.save()    

            let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

            return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Create Form"
                        }                                                                                                                                                                                                                                                                                                        
    }


let fillForm () = 
    promise {
        let formUrl = "https://pdf-lib.js.org/assets/dod_character.pdf"
        let! formPdfBytes = fetchArrayBuffer formUrl 

        let marioUrl = "https://pdf-lib.js.org/assets/small_mario.png"
        let! marioImageBytes = fetchArrayBuffer marioUrl 

        let emblemUrl = "https://pdf-lib.js.org/assets/mario_emblem.png"
        let! emblemImageBytes = fetchArrayBuffer emblemUrl 

        let! pdfDoc = PDFDocument.load formPdfBytes 

        let! marioImage = pdfDoc.embedPng marioImageBytes 
        let! emblemImage = pdfDoc.embedPng emblemImageBytes  

        let form = pdfDoc.getForm()

        let nameField = form.getTextField "CharacterName 2"
        let ageField = form.getTextField "Age"
        let heightField = form.getTextField "Height"
        let weightField = form.getTextField "Weight" 
        let eyesField = form.getTextField "Eyes"
        let skinField = form.getTextField "Skin" 
        let hairField = form.getTextField "Hair"

        let alliesField = form.getTextField "Allies" 
        let factionField = form.getTextField "FactionName"
        let backstoryField = form.getTextField "Backstory"
        let traitsField = form.getTextField "Feat+Traits"
        let treasureField = form.getTextField "Treasure"


        let characterImageField = form.getButton "CHARACTER IMAGE"
        let factionImageField = form.getButton "Faction Symbol Image"

        do nameField.setText "Mario"
        do ageField.setText "24 years"
        do heightField.setText  "5' 1\""
        do weightField.setText "196 lbs" 
        do eyesField.setText "blue" 
        do skinField.setText "white" 
        do hairField.setText "brown"

        do characterImageField.setImage marioImage

        do alliesField.setText ([ 
                                "Allies:"
                                "  • Princess Daisy"
                                "  • Princess Peach"
                                "  • Rosalina"
                                "  • Geno"
                                "  • Luigi"
                                "  • Donkey Kong"
                                "  • Yoshi"
                                "  • Diddy Kong"
                                ""
                                "Organizations:"
                                "  • Italian Plumbers Association"
                                ] |> String.concat "\n")
                                  
        do factionField.setText "Mario's Emblem"

        do factionImageField.setImage emblemImage 
        
        do backstoryField.setText ([
                                    "Mario is a fictional character in the Mario video game franchise, "
                                    "owned by Nintendo and created by Japanese video game designer Shigeru "
                                    "Miyamoto. Serving as the company's mascot and the eponymous "
                                    "protagonist of the series, Mario has appeared in over 200 video games "
                                    "since his creation. Depicted as a short, pudgy, Italian plumber who "
                                    "resides in the Mushroom Kingdom, his adventures generally center "
                                    "upon rescuing Princess Peach from the Koopa villain Bowser. His "
                                    "younger brother and sidekick is Luigi."
                                    ] |> String.concat "\n")

        do traitsField.setText ([
                                    "Mario can use three basic three power-ups:"
                                    "  • the Super Mushroom, which causes Mario to grow larger"
                                    "  • the Fire Flower, which allows Mario to throw fireballs"
                                    "  • the Starman, which gives Mario temporary invincibility"
                                ] |> String.concat "\n" )

        
        do treasureField.setText ([
                                    "• Gold coins"
                                    "• Treasure chests"
                                  ] |> String.concat "\n")
        let! pdfBytes = pdfDoc.save()

        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Fill Form"
                        }

    }


let flattenForm () = 
    promise {
        let formUrl = "https://pdf-lib.js.org/assets/form_to_flatten.pdf"
        let! formPdfBytes = fetchArrayBuffer formUrl 

        let! pdfDoc = PDFDocument.load formPdfBytes

        let form = pdfDoc.getForm()   

        do form.getTextField("Text1").setText("Some Text")
        do form.getRadioGroup("Group2").select("Choice1")
        do form.getRadioGroup("Group3").select("Choice3")
        do form.getRadioGroup("Group4").select("Choice1")
        do form.getCheckBox("Check Box3").check() 
        do form.getCheckBox("Check Box4").uncheck() 
        do form.getDropdown("Dropdown7").select("Infinity")
        do form.getOptionList("List Box6").select("Honda")

        do form.flatten()

        let! pdfBytes = pdfDoc.save() 

        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Flatten Document"
                        }
    }



let copyPages () = 
    promise {
        let url1 = "https://pdf-lib.js.org/assets/with_update_sections.pdf"
        let url2 = "https://pdf-lib.js.org/assets/with_large_page_count.pdf"

        let! firstDonorPdfBytes = fetchArrayBuffer url1 
        let! secondDonorPdfBytes = fetchArrayBuffer url2

        let! firstDonorPdfDoc = PDFDocument.load firstDonorPdfBytes
        let! secondDonorPdfDoc = PDFDocument.load secondDonorPdfBytes

        
        let! pdfDoc = PDFDocument.create()

        let! firstDonorPage = pdfDoc.copyPages(firstDonorPdfDoc, [| 0 |])

        let! secondDonorPage = pdfDoc.copyPages(secondDonorPdfDoc, [| 742 |])

        do pdfDoc.addPage firstDonorPage.[0] |> ignore 
        do pdfDoc.insertPage(0, secondDonorPage.[0]) |> ignore

        let! pdfBytes = pdfDoc.save() 

        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Copy Pages"
                        }

    }

let embedImages () = 
    promise {
        let jpgUrl = "https://pdf-lib.js.org/assets/cat_riding_unicorn.jpg"
        let pngUrl = "https://pdf-lib.js.org/assets/minions_banana_alpha.png"

        let! jpgImageBytes = fetchArrayBuffer jpgUrl 
        let! pngImageBytes = fetchArrayBuffer pngUrl 

        let! pdfDoc = PDFDocument.create()
        

        let! jpgImage = pdfDoc.embedJpg jpgImageBytes 
        let! pngImage = pdfDoc.embedPng pngImageBytes

        let jpgDims = jpgImage.scale 0.5 
        let pngDims = pngImage.scale 0.5

        let page = pdfDoc.addPage() 

       

        do page.drawImage(jpgImage, 
                          jsOptions<PDFPageDrawImageOptions>(fun opt -> opt.x <- ((page.getWidth()) / 2.0) - (jpgDims.width / 2.0)
                                                                        opt.y <- ((page.getHeight()) / 2.0) - (jpgDims.height /2.0) + 250.0
                                                                        opt.width <- jpgDims.width 
                                                                        opt.height <- jpgDims.height ))
        
        do page.drawImage(pngImage, 
                          jsOptions<PDFPageDrawImageOptions>(fun opt -> opt.x <- ((page.getWidth()) / 2.0) - (pngDims.width / 2.0) + 75.0
                                                                        opt.y <- ((page.getHeight()) / 2.0) - (pngDims.height / 2.0) + 250.0
                                                                        opt.width <- pngDims.width 
                                                                        opt.height <- pngDims.height ))

        
        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                        ByteArray = pdfBytes 
                        DataUri = pdfUrl 
                        Name = "Embed Images"
                        }


    }

let embedPdfPages () = 
    promise {
        let flagUrl = "https://pdf-lib.js.org/assets/american_flag.pdf"
        let constitutionUrl = "https://pdf-lib.js.org/assets/us_constitution.pdf"

        let! flagPdfBytes = fetchArrayBuffer flagUrl

        let! consitutionPdfBytes = fetchArrayBuffer constitutionUrl

        let! pdfDoc = PDFDocument.create() 

        let! americanFlag = pdfDoc.embedPdf flagPdfBytes 
        let americanFlagPage = americanFlag.[0]
        let! usConstitutionPdf = PDFDocument.load consitutionPdfBytes

        let! preamble = pdfDoc.embedPage(usConstitutionPdf.getPages().[1] , jsOptions<PageBoundingBox>(fun box ->   box.left <- 55.0
                                                                                                                    box.bottom <- 485.0
                                                                                                                    box.right <- 300.0 
                                                                                                                    box.top <- 575.0))

        do Fable.Core.JS.console.log preamble

        let americanFlagDims = americanFlagPage.scale 0.3 
        let preambleDims = preamble.scale 2.25 

        do Fable.Core.JS.console.log preambleDims
        let page = pdfDoc.addPage() 

        do page.drawPage(americanFlagPage, jsOptions<PDFPageDrawPageOptions>(fun opts -> opts.height <- americanFlagDims.height 
                                                                                         opts.width <- americanFlagDims.width 
                                                                                         opts.x <- (page.getWidth() / 2.0) - (americanFlagDims.width / 2.0) 
                                                                                         opts.y <- page.getHeight() - americanFlagDims.height - 150.0))
        
        
        do page.drawPage(preamble,  jsOptions<PDFPageDrawPageOptions>(fun opts ->  opts.height <- preambleDims.height 
                                                                                   opts.width <- preambleDims.width 
                                                                                   opts.x <- ((page.getWidth() / 2.0) - (preambleDims.width / 2.0)) 
                                                                                   opts.y <- (page.getHeight() / 2.0) - (preambleDims.height / 2.0) - 50.0))
        
        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Embed PDF Pages"
                }
    }

let embedFontAndMeasureText () = 
    promise {
        let url = "https://pdf-lib.js.org/assets/ubuntu/Ubuntu-R.ttf"
        let! fontBytes = fetchArrayBuffer url 

        let! pdfDoc = PDFDocument.create() 

        do registerFontKit pdfDoc  

        let! customFont = pdfDoc.embedFont fontBytes

        let page = pdfDoc.addPage()

        let text = "This is text in an embedded font!" 

        let textSize = 35.0 
        let textWidth = customFont.widthOfTextAtSize(text, textSize)
        let textHeight = customFont.heightAtSize(textSize)

        do page.drawText(text, jsOptions<PDFPageDrawTextOptions>(fun opts -> opts.x <- 40.0 
                                                                             opts.y <- 450.0 
                                                                             opts.size <- textSize 
                                                                             opts.font <- customFont 
                                                                             opts.color <- Color.RGB (rgb(0.0, 0.53, 0.71))
                                                                              ))
        
        do page.drawRectangle(jsOptions<PDFPageDrawRectangleOptions>(fun opts -> opts.x <- 40.0 
                                                                                 opts.y <- 450.0 
                                                                                 opts.width <- textWidth 
                                                                                 opts.height <- textHeight 
                                                                                 opts.borderColor <- Color.RGB (rgb(1.0,0.0,0.0))
                                                                                 opts.borderWidth <- 1.5 )) 
        
        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Embed Font And Measure Text"
                }

    }

let addAttachments () = 
    promise {
        let jpgUrl = "https://pdf-lib.js.org/assets/cat_riding_unicorn.jpg"
        let pdfUrl = "https://pdf-lib.js.org/assets/us_constitution.pdf"

        let! jpgAttachmentBytes = fetchArrayBuffer jpgUrl 
        let! pdfAttachmentBytes = fetchArrayBuffer pdfUrl 

        let! pdfDoc = PDFDocument.create()

        do! pdfDoc.attach( jpgAttachmentBytes, 
                           "cat_riding_unicorn.jpg",
                           jsOptions<AttachmentOptions>(fun opts -> opts.mimeType <- "image/jpeg"
                                                                    opts.description <- "Cool cat riding a unicorn! 🦄🐈🕶️"
                                                                    opts.creationDate <- DateTime(2019, 12, 1)
                                                                    opts.modificationDate <- DateTime(2020, 4,19)))
        

        do! pdfDoc.attach( pdfAttachmentBytes, 
                           "us_constitution.pdf",
                           jsOptions<AttachmentOptions>(fun opts -> opts.mimeType <- "application/pdf"
                                                                    opts.description <- "Constitution of the United States 🇺🇸🦅"
                                                                    opts.creationDate <- DateTime(1787, 9, 17)
                                                                    opts.modificationDate <- DateTime(1992, 5,7)))


        let page = pdfDoc.addPage() 

        do page.drawText("This PDF has two attachments", jsOptions<PDFPageDrawTextOptions>(fun opts -> opts.x <- 135.0 
                                                                                                       opts.y <- 415.0 ))


        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Add Attachments"
                }
    }

let setDocumentMetadata () =
    promise {
        let! pdfDoc = PDFDocument.create() 
        let! timesRomanFont = pdfDoc.embedFont TimesRoman 

        let page = pdfDoc.addPage(width = 500.0, height = 600.0)

        do page.setFont timesRomanFont 

        do page.drawText( "The Life of an Egg", jsOptions<PDFPageDrawTextOptions>(fun opts -> opts.x <- 60.0 
                                                                                              opts.y <- 500.0 
                                                                                              opts.size <- 50.0 
                                                                                              ))
        do page.drawText( "An Epic Tale of Woe", jsOptions<PDFPageDrawTextOptions>(fun opts -> opts.x <- 125.0 
                                                                                               opts.y <- 460.0 
                                                                                               opts.size <- 25.0 
                                                                                              ))

        do pdfDoc.setTitle "🥚 The Life of an Egg 🍳"
        do pdfDoc.setAuthor "Humpty Dumpty"
        do pdfDoc.setSubject "📘 An Epic Tale of Woe 📖"
        do pdfDoc.setKeywords [| 
                                "eggs"
                                "wall"
                                "fall"
                                "king"
                                "horses"
                                "men"
                              |]
        do pdfDoc.setProducer "PDF App 9000 🤖"
        do pdfDoc.setCreator "pdf-lib (https://github.com/Hopding/pdf-lib)"
        do pdfDoc.setCreationDate (DateTime(2022,10,1)) //"2018-06-24T01:58:37.228Z"
        do pdfDoc.setModificationDate (DateTime(2022, 11,2)) // 2019-12-21T07:00:11.000Z

        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Set Document Metadata"
                }
    }

let readDocumentMetadata () = 
    promise {

        let url = "https://pdf-lib.js.org/assets/with_cropbox.pdf"
        let! existingPdfBytes = fetchArrayBuffer url 

        let! pdfDoc = PDFDocument.load( existingPdfBytes, jsOptions<LoadOptions> (fun opts -> opts.updateMetadata <- false ))

        return {
                Title = pdfDoc.getTitle() 
                Author = pdfDoc.getAuthor() 
                Subject = pdfDoc.getSubject() 
                Creator = pdfDoc.getCreator() 
                Keywords = pdfDoc.getKeywords() 
                Producer = pdfDoc.getProducer() 
                CreationDate = pdfDoc.getCreationDate() 
                ModificationDate = pdfDoc.getModificationDate()
        }
    }

let drawSVGPaths () = 
    promise {
        let svgPath = "M 0,20 L 100,160 Q 130,200 150,120 C 190,-40 200,200 300,150 L 400,90"
        
        let! pdfDoc = PDFDocument.create() 

        let page = pdfDoc.addPage() 

        do page.moveTo(100.0, page.getHeight() - 5.0)

        do page.moveDown(25.0)
        do page.drawSvgPath svgPath 

        do page.moveDown(200.0) 
        do page.drawSvgPath (svgPath, jsOptions<PDFPageDrawSVGOptions> (fun opts -> opts.borderColor <- Color.RGB (rgb(0.0,1.0,0.0))
                                                                                    opts.borderWidth <- 5.0))

        do page.moveDown(200.0)
        do page.drawSvgPath (svgPath, jsOptions<PDFPageDrawSVGOptions> (fun opts -> opts.color <- Color.RGB (rgb(1.0,0.0,0.0))
                                                                                    ))

        do page.moveDown(200.0) 
        do page.drawSvgPath (svgPath, jsOptions<PDFPageDrawSVGOptions> (fun opts -> opts.scale <- 0.5 ))

        let! pdfBytes = pdfDoc.save() 
        
        
        let! pdfUrl = pdfDoc.saveAsBase64(jsOptions<Base64SaveOptions>(fun opt -> opt.dataUri <- true))

        return {
                ByteArray = pdfBytes 
                DataUri = pdfUrl 
                Name = "Draw SVG Paths"
                }

    }
let Button (props: {| 
                      
                      pdfBytes: JS.Uint8Array 
                      fileName: string   
                        |}) =
  Bulma.button.button [
                prop.text "Download PDF"
                color.isInfo                 
                prop.onClick (fun _ -> downloadAsPDF (Data.TypedArray props.pdfBytes) $"{props.fileName}.pdf")
            ]


let update (msg: Msg) (state: State) : State * Cmd<Msg> = 
    match msg with 
    | OpenDropdown -> {state with DropDownOpen = true}, Cmd.none 
    | HelloWorld Started ->  
                             let newCmd = promise {
                                                        let! pdf = helloWorld()
                                                        return HelloWorld (Finished(pdf))
                                                      }
                                
                             {state with WorkingOnPDF = true
                                         DropDownOpen = false }, Cmd.OfPromise.result newCmd 
    | HelloWorld (Finished(pdf)) -> {state with WorkingOnPDF = false    
                                                DisplayData = pdf |> PDF |> Some
                                                             }, Cmd.none                         
    | CreateDocument Started -> let newCmd = promise {
                                                        let! pdf = createDocument()
                                                        return CreateDocument (Finished(pdf))
                                                      }
                                
                                {state with WorkingOnPDF = true
                                            DropDownOpen = false }, Cmd.OfPromise.result newCmd 

    | CreateDocument (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                     DisplayData = pdf |> PDF |> Some}, Cmd.none 

    | ModifyDocument Started -> let newCmd = promise { 
                                                        let! pdf = modifyDocument() 
                                                        return ModifyDocument (Finished(pdf))
                                                    }  
                                {state with WorkingOnPDF = true
                                            DropDownOpen = false }, Cmd.OfPromise.result newCmd 

    | ModifyDocument (Finished(pdf)) ->   {state with WorkingOnPDF = false    
                                                      DisplayData = pdf |> PDF |> Some}, Cmd.none 


    | CreateForm Started -> let newCmd = promise { 
                                                        let! pdf = createForm() 
                                                        return ModifyDocument (Finished(pdf))
                                                    }  
                            {state with WorkingOnPDF = true
                                        DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | CreateForm (Finished(pdf)) -> {state with WorkingOnPDF = false    
                                                DisplayData = pdf |> PDF |> Some}, Cmd.none

    | FillForm Started -> let newCmd = promise { 
                                                        let! pdf = fillForm() 
                                                        return FillForm (Finished(pdf))
                                                    }  
                          {state with WorkingOnPDF = true
                                      DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | FillForm (Finished(pdf)) -> {state with WorkingOnPDF = false    
                                              DisplayData = pdf |> PDF |> Some }, Cmd.none



    | FlattenForm Started -> let newCmd = promise { 
                                                        let! pdf = flattenForm() 
                                                        return FlattenForm (Finished(pdf))
                                                    }  
                             {state with WorkingOnPDF = true
                                         DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | FlattenForm (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                  DisplayData = pdf |> PDF |> Some }, Cmd.none


    | CopyPages Started ->  let newCmd = promise { 
                                                        let! pdf = copyPages() 
                                                        return CopyPages (Finished(pdf))
                                                    }  
                            {state with WorkingOnPDF = true
                                        DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | CopyPages (Finished(pdf)) -> {state with WorkingOnPDF = false    
                                               DisplayData = pdf |> PDF |> Some }, Cmd.none

    | EmbedImages Started -> let newCmd = promise { 
                                                        let! pdf = embedImages() 
                                                        return EmbedImages (Finished(pdf))
                                                    }  
                             {state with WorkingOnPDF = true
                                         DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | EmbedImages (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                  DisplayData = pdf |> PDF |> Some }, Cmd.none

    | EmbedPdfPages Started ->  let newCmd = promise { 
                                                        let! pdf = embedPdfPages() 
                                                        return EmbedPdfPages (Finished(pdf))
                                                    }  
                                {state with WorkingOnPDF = true
                                            DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | EmbedPdfPages (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                    DisplayData = pdf |> PDF |> Some } , Cmd.none

    | EmbedFontAndMeasureText Started ->    let newCmd = promise { 
                                                            let! pdf = embedFontAndMeasureText() 
                                                            return EmbedFontAndMeasureText (Finished(pdf))
                                                        }  
                                            {state with WorkingOnPDF = true
                                                        DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | EmbedFontAndMeasureText (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                              DisplayData  = pdf |> PDF |> Some }, Cmd.none

    | AddAttachments Started ->     let newCmd = promise { 
                                                            let! pdf = addAttachments() 
                                                            return AddAttachments (Finished(pdf))
                                                        }  
                                    {state with WorkingOnPDF = true
                                                DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | AddAttachments (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                     DisplayData = pdf |> PDF |> Some }, Cmd.none  

    | SetDocumentMetadata Started ->    let newCmd = promise { 
                                                            let! pdf = setDocumentMetadata() 
                                                            return SetDocumentMetadata (Finished(pdf))
                                                        }  
                                        {state with WorkingOnPDF = true
                                                    DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | SetDocumentMetadata (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                          DisplayData = pdf |> PDF |> Some }, Cmd.none                                                   

    | ReadDocumentMetadata Started ->    let newCmd = promise { 
                                                            let! data = readDocumentMetadata() 
                                                            return ReadDocumentMetadata (Finished(data))
                                                        }  
                                         {state with WorkingOnPDF = true
                                                     DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | ReadDocumentMetadata (Finished(data)) ->  {state with WorkingOnPDF = false    
                                                            DisplayData = data |> Metadata |> Some }, Cmd.none   

    | DrawSVGPaths Started ->            let newCmd = promise { 
                                                            let! pdf = drawSVGPaths() 
                                                            return DrawSVGPaths (Finished(pdf))
                                                        }  
                                         {state with WorkingOnPDF = true
                                                     DropDownOpen = false }, Cmd.OfPromise.result newCmd

    | DrawSVGPaths (Finished(pdf)) ->  {state with WorkingOnPDF = false    
                                                   DisplayData = pdf |> PDF |> Some }, Cmd.none                                                             
[<ReactComponent>]
let PdfLibView () = 
    let state, dispatch = React.useElmish(init , update, [| |])


    Bulma.box [
        Bulma.block [
        Bulma.dropdown [
            if state.DropDownOpen then 
                dropdown.isActive 
            
            prop.children [
                Bulma.dropdownTrigger [
                    Bulma.button.button [
                        prop.onClick (fun _ -> OpenDropdown |> dispatch)
                        prop.ariaHasPopup true
                        prop.ariaControls [| "pdflib-dropdown" |]
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
                    prop.id "pdflib-dropdown"
                    prop.children [
                        Bulma.dropdownContent [
                            prop.style[
                                style.maxHeight 400
                                style.custom ("overflow", "auto")
                            ]
                            prop.children [
                                            Bulma.dropdownItem.a [
                                                    prop.text "Hello World"
                                                    prop.onClick (fun _ -> Started |> HelloWorld |> dispatch)
                                            ] 
                                            Bulma.dropdownItem.a [
                                                    prop.text "Create Document"
                                                    prop.onClick (fun _ -> Started |> CreateDocument |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Modify Document"
                                                    prop.onClick (fun _ -> Started |> ModifyDocument |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Create Form" 
                                                    prop.onClick (fun _ -> Started |> CreateForm |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [ 
                                                    prop.text "Fill Form" 
                                                    prop.onClick (fun _ -> Started |> FillForm |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Flatten Form" 
                                                    prop.onClick (fun _ -> Started |> FlattenForm |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Copy Pages"
                                                    prop.onClick (fun _ -> Started |> CopyPages |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Embed Images"
                                                    prop.onClick (fun _ -> Started |> EmbedImages |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Embed Pdf Pages"
                                                    prop.onClick (fun _ -> Started |> EmbedPdfPages |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [ 
                                                    prop.text "Embed Font and Measure Text"
                                                    prop.onClick (fun _ -> Started |> EmbedFontAndMeasureText |> dispatch )
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Add Attachments" 
                                                    prop.onClick (fun _ -> Started |> AddAttachments |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [ 
                                                    prop.text "Set Document Metadata"
                                                    prop.onClick (fun _ -> Started |> SetDocumentMetadata |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Read Document Metadata"
                                                    prop.onClick (fun _ -> Started |> ReadDocumentMetadata |> dispatch)
                                            ]
                                            Bulma.dropdownItem.a [
                                                    prop.text "Draw SVG Paths" 
                                                    prop.onClick (fun _ -> Started |> DrawSVGPaths |> dispatch)
                                            ]
                                           ]
                                          ]
                        ]
                    ]    
                ]
            ]
        ]
        match state.WorkingOnPDF, state.DisplayData with 
        | true, _ ->     Bulma.container [
                            text.hasTextCentered
                            prop.style [ style.marginTop 100]
                            prop.children [
                                Bulma.title [
                                    title.is3
                                    prop.text "Working on PDF"
                                ]
                                Html.i [
                                    prop.classes [ "fas"; "fa-sync"; "fa-spin"; "fa-3x"]
                                ]
                            ]
                        ]
        
        | false, None -> Html.none 
        | false, Some displayData ->  match displayData with 
                                      | PDF displayPDF -> 
                                        Html.div [
                                                
                                                Bulma.block [
                                                    Bulma.title displayPDF.Name
                                                ]
                                                Bulma.block [
                                                    Button {|
                                                            fileName = displayPDF.Name 
                                                            pdfBytes = displayPDF.ByteArray
                                                            |}
                                                ]
                                                Bulma.block [
                                                    Html.iframe [
                                                        prop.src displayPDF.DataUri
                                                        prop.height 475  
                                                    ]
                                                ]
                                              ]  

                                      | Metadata metadata -> Bulma.block  [
                                                                    Bulma.content $"Title: %A{metadata.Title}"
                                                                    Bulma.content $"Author: %A{metadata.Author}"
                                                                    Bulma.content $"Subject: %A{metadata.Subject}"
                                                                    Bulma.content $"Creator: %A{metadata.Creator}"
                                                                    Bulma.content $"Keywords: %A{metadata.Keywords}"
                                                                    Bulma.content $"Producer: %A{metadata.Producer}"
                                                                    Bulma.content $"Creation Date: %A{metadata.CreationDate}"
                                                                    Bulma.content $"Modification Date: %A{metadata.ModificationDate}"
                                                                ]
    ]