module rec Fable.PdfLib

open System
open Browser.Types
open Fable.Core
open Fable.Core.JS

[<StringEnum>]
type RotationTypes =
    | Degrees
    | Radians

[<StringEnum>]
type ColorTypes =
    | [<CompiledName("CMYK")>] CMYK
    | [<CompiledName("Grayscale")>] Grayscale
    | [<CompiledName("RGB")>] RGB


type LineCapStyle =
    | Butt = 0
    | Projecting = 2
    | Round = 1

[< RequireQualifiedAccess>]
type ImageAlignment = 
    | Center = 1 
    | Left = 0 
    | Right = 2

[< RequireQualifiedAccess>]
type TextAlignment = 
    | Center = 1 
    | Left = 0 
    | Right = 2

[<StringEnum>]
type StandardFonts =
    | [<CompiledName("Courier")>] Courier
    | [<CompiledName("Courier-Bold")>] CourierBold
    | [<CompiledName("Courier-BoldOblique")>] CourierBoldOblique
    | [<CompiledName("Courier-Oblique")>] CourierOblique
    | [<CompiledName("Helvetica")>] Helvetica
    | [<CompiledName("Helvetica-Bold")>] HelveticaBold
    | [<CompiledName("Helvetica-BoldOblique")>] HelveticaBoldOblique
    | [<CompiledName("Symbol")>] Symbol
    | [<CompiledName("Times-Roman")>] TimesRoman
    | [<CompiledName("Times-Bold")>] TimesRomanBold
    | [<CompiledName("Times-BoldItalic")>] TimesRomanBoldItalic
    | [<CompiledName("Times-Italic")>] TimesRomanItalic
    | [<CompiledName("ZapfDingbats")>] ZapfDingbats


[<StringEnum>]
type BlendMode =
    | [<CompiledName("ColorBurn")>] ColorBurn
    | [<CompiledName("ColorDodge")>] ColorDodge
    | [<CompiledName("Darken")>] Darken
    | [<CompiledName("Difference")>] Difference
    | [<CompiledName("Exclusion")>] Exclusion
    | [<CompiledName("HardLight")>] HardLight
    | [<CompiledName("Lighten")>] Lighten
    | [<CompiledName("Multiply")>] Multiply
    | [<CompiledName("Normal")>] Normal
    | [<CompiledName("Overlay")>] Overlay
    | [<CompiledName("Screen")>] Screen
    | [<CompiledName("SoftLight")>]SoftLight

type PDFPageDrawPageOptions = 
    abstract blendMode: BlendMode with get, set 
    abstract height : float with get, set 
    abstract opacity : float with get, set 
    abstract rotate : Rotation with get, set 
    abstract width : float with get, set 
    abstract x : float with get, set 
    abstract xScale : float with get, set 
    abstract xSkew : float with get, set 
    abstract y : float with get, set 
    abstract yScale : float with get, set 
    abstract ySkew : float with get, set 

    




type Base64SaveOptions = 
    abstract addDefaultPage: bool  with get, set 
    abstract dataUri : bool  with get, set 
    abstract objectsPerTick: int  with get, set 
    abstract updateFieldAppearances: bool  with get, set 
    abstract useObjectStreams: bool with get, set 



type Radians =
    abstract angle: float with get, set
    abstract ``type`` : RotationTypes with get

type Degrees =
    abstract angle: float with get, set
    abstract ``type`` : RotationTypes with get

type Grayscale =
    abstract gray: float with get, set
    abstract ``type`` : ColorTypes with get

type RGB =
    abstract blue: float with get, set
    abstract green: float with get, set
    abstract red: float with get, set
    abstract ``type``: ColorTypes with get


type CMYK =
    abstract cyan: float with get, set
    abstract key: float with get, set
    abstract magenta : float with get, set
    abstract ``type``: ColorTypes with get
    abstract yellow : float with get, set

[<Erase; RequireQualifiedAccess>]
type Color = 
    | Grayscale of Grayscale 
    | RGB of RGB 
    | CMYK of CMYK 


type Size =
    abstract width : float with get
    abstract height : float with get

type Position =
    abstract x : float with get, set
    abstract y : float with get, set

[<Erase; RequireQualifiedAccess>]
type Rotation =
    | Radians of Radians
    | Degrees of Degrees




 
type PDFEmbeddedPage =     

    abstract doc : PDFDocument with get
    abstract height: float with get,set 
    abstract ref: PDFRef with get 
    abstract width: float with get,set
    
   
    /// Get the width and height of this page.
    abstract size : unit -> Size 
    /// Compute the width and height of this page after being scaled by the given factor.
    abstract scale: factor: float -> Size 
    /// Embed this embeddable page in its document.
    abstract embed : unit -> JS.Promise<unit>

type PageBoundingBox = 
    abstract left : float with get,set 
    abstract right : float with get, set 
    abstract bottom : float with get, set 
    abstract top : float with get, set 

type AttachmentOptions = 
    abstract creationDate: DateTime with get,set 
    abstract description: string with get, set
    abstract mimeType: string with get, set  
    abstract modificationDate: DateTime with get,set 


type TransformationMatrix(m1 : float, m2 : float, m3 : float, m4: float, m5: float, m6: float) = class
     member x.M1 = m1 
     member x.M2 = m2 
     member x.M3 = m3
     member x.M4 = m4 
     member x.M5 = m5 
     member x.M6 = m6
   
end

type SetTitleOptions = 
    abstract showInWindowTitleBar: bool with get, set 


type PDFDocument =
    /// Whether or not this document is encrypted.
    abstract isEncrypted: bool with get
    
    /// Add JavaScript to this document. The supplied script is executed when the document is opened. The script can be used to perform some operation when the document is opened (e.g. logging to the console), or it can be used to define a function that can be referenced later in a JavaScript action
    abstract addJavaScript: name: string * script: string -> unit 

    /// Add a page to the end of this document. This method accepts three different value types for the page parameter:
    ///
    /// undefined ->	Create a new page and add it to the end of this document
    /// [number, number]  ->  Create a new page with the given dimensions and add it to the end of this document
    /// PDFPage	   ->         Add the existing page to the end of this document
    ///   
    [<Emit("$0.addPage([$1,$2])")>]
    abstract addPage: width: float * height: float -> PDFPage
    abstract addPage: unit -> PDFPage 
    abstract addPage: PDFPage -> PDFPage 

    abstract attach: attachment: string * name: string * ?options: AttachmentOptions -> JS.Promise<unit>
    abstract attach: attachment: JS.Uint8Array * name: string * ?options: AttachmentOptions -> JS.Promise<unit> 
    abstract attach: attachment: JS.ArrayBuffer * name: string * ?options: AttachmentOptions -> JS.Promise<unit> 
    
    /// Get a copy of this document.
    abstract copy: unit -> PDFDocument
    /// Copy pages from a source document into this document. Allows pages to be copied between different PDFDocument instances.
    [<Emit("$0.copyPages($1, Array.from($2))")>]
    abstract copyPages: srcDoc: PDFDocument * indices: int array -> JS.Promise<PDFPage array>
    /// Embed a font into this document. The input data can be provided in multiple formats:
    ///
    /// StandardFonts->One of the standard 14 fonts/
    /// string->A base64 encoded string (or data URI) containing a font/
    /// Uint8Array-> The raw bytes of a font/
    /// ArrayBuffer-> The raw bytes of a font/   
    abstract embedFont: font: string * ?options: EmbedFontOptions -> JS.Promise<PDFFont>
    abstract embedFont: font: JS.Uint8Array * ?options: EmbedFontOptions -> JS.Promise<PDFFont>
    abstract embedFont: font: JS.ArrayBuffer * ?options: EmbedFontOptions -> JS.Promise<PDFFont>
    abstract embedFont: font: StandardFonts  * ?options: EmbedFontOptions -> JS.Promise<PDFFont>
    /// Embed a JPEG image into this document. The input data can be provided in multiple formats:
    ///
    /// string->A base64 encoded string (or data URI) containing a JPEG image/
    /// Uint8Array->The raw bytes of a JPEG image/
    /// ArrayBuffer->The raw bytes of a JPEG image/
    abstract embedJpg: base64: string -> JS.Promise<PDFImage>
    abstract embedJpg: arr: JS.Uint8Array -> JS.Promise<PDFImage>
    abstract embedJpg: buffer: JS.ArrayBuffer -> JS.Promise<PDFImage>
    
    
   
    abstract embedPage: page: PDFPage * ?boundingBox: PageBoundingBox -> JS.Promise<PDFEmbeddedPage> 

    abstract embedPdf: pdf : string -> JS.Promise<PDFEmbeddedPage array>
    abstract embedPdf: pdf: JS.Uint8Array -> JS.Promise<PDFEmbeddedPage array>
    abstract embedPdf: pdf: JS.ArrayBuffer -> JS.Promise<PDFEmbeddedPage array>
    abstract embedPdf: pdf: PDFDocument * indices: int array -> JS.Promise<PDFEmbeddedPage array>

    /// Embed a PNG image into this document. The input data can be provided in multiple formats:
    ///
    ///
    /// StandardFonts->One of the standard 14 fonts/
    /// string->A base64 encoded string (or data URI) containing a font/
    /// Uint8Array->The raw bytes of a PNG image/
    /// ArrayBuffer->The raw bytes of a PNG image/
    abstract embedPng: base64: string -> JS.Promise<PDFImage>
    abstract embedPng: arr: JS.Uint8Array -> JS.Promise<PDFImage> 
    abstract embedPng: buffer: JS.ArrayBuffer -> JS.Promise<PDFImage>
    
    abstract getAuthor: unit -> string option  
    abstract getCreationDate: unit -> DateTime option 
    abstract getCreator: unit -> string option 

    /// Get the PDFForm containing all interactive fields for this document
    abstract getForm: unit -> PDFForm 

    abstract getKeywords: unit -> string option 
    abstract getModificationDate: unit -> DateTime option 

    /// Get the page rendered at a particular index of the document.
    abstract getPage: index: int -> PDFPage
    /// Get the page rendered at a particular index of the document.
    abstract getPageCount: unit -> int
    
    /// Get an array of indices for all the pages contained in this document. The array will contain a range of integers from 0..pdfDoc.getPageCount() - 1.
    abstract getPageIndices: unit -> int array
    /// Get an array of all the pages contained in this document. The pages are stored in the array in the same order that they are rendered in the document.
    abstract getPages: unit -> PDFPage array
    
    abstract getProducer: unit -> string option 
    abstract getSubject: unit -> string option 
    abstract getTitle: unit -> string option 
        
    /// Insert a page at a given index within this document.
    [<Emit("$0.insertPage($1, [$2,$3])")>]
    abstract insertPage: index: int * width: float * height: float -> PDFPage
    abstract insertPage: index: int -> PDFPage 
    abstract insertPage: index: int * page: PDFPage -> PDFPage 
     
    
    /// Remove the page at a given index from this document.
    abstract removePage: index: int -> unit
    /// Serialize this document to an array of bytes making up a PDF file.
    /// There are a number of things you can do with the serialized document, depending on the JavaScript environment you're running in:
    ///
    ///Write it to a file in Node or React Native//
    ///Download it as a Blob in the browser//
    ///Render it in an iframe//
    abstract save: unit -> JS.Promise<JS.Uint8Array>
    /// Serialize this document to a base64 encoded string or data URI making up a PDF file.
    abstract saveAsBase64: ?options: Base64SaveOptions -> JS.Promise<string>

    abstract setAuthor: author: string -> unit 
    abstract setCreationDate: creationDate: DateTime -> unit 
    abstract setCreator: creator: string -> unit 
    abstract setKeywords: keywords: string array -> unit 
    abstract setLanguage: language: string -> unit 
    abstract setModificationDate: modificationDate : DateTime -> unit 
    abstract setProducer: producer: string -> unit 
    abstract setSubject: subject : string -> unit 
    abstract setTitle: title: string * ?options: SetTitleOptions -> unit 


type LoadOptions = 
    abstract capNumbers: bool with get,set 
    abstract ignoreEncryption: bool with get,set 
    abstract parseSpeed: int with get,set 
    abstract throwOnInvalidObject : bool with get,set 
    abstract updateMetadata: bool with get,set 

type PDFDocumentStatic =
    
    abstract load: pdf: string  * ?options: LoadOptions -> JS.Promise<PDFDocument>
    abstract load: pdf: JS.Uint8Array * ?options: LoadOptions -> JS.Promise<PDFDocument> 
    abstract load: pdf: JS.ArrayBuffer * ?options: LoadOptions -> JS.Promise<PDFDocument>
   
    /// Create a new PDFDocument.
    abstract create: unit -> JS.Promise<PDFDocument>


type EmbedFontOptions =
    abstract customName: string with get, set
    abstract subset: bool with get, set


type HeightAtSizeOptions  =
    // controls whether or not the font's descender is included in the height calculation.
    abstract descender: bool with get, set

type PDFFont =
    /// The document to which this font belongs.
    abstract doc: PDFDocument with get
    /// The name of this font.
    abstract name: string with get
    /// Get the set of unicode code points that can be represented by this font.
    abstract getCharacterSet: unit -> float array
    /// Measure the height of this font at a given size.
    abstract heightAtSize: size: float * ?options: HeightAtSizeOptions -> float
    /// Compute the font size at which this font is a given height.
    abstract sizeAtHeight: height: float -> float
    // Measure the width of a string of text drawn in this font at a given size.
    abstract widthOfTextAtSize: text: string * size: float -> float


type FlattenOptions = 
    abstract updateFieldAppearances: bool with get, set 

type PDFPageDrawLineOptions =
    abstract blendMode: BlendMode with get, set
    abstract color : Color with get, set
    abstract dashArray: float array with get, set
    abstract dashPhase: float with get, set
    abstract ``end``: Position with get,set
    abstract lineCap: LineCapStyle with get,set
    abstract opacity: float with get, set
    abstract start: Position with get,set
    abstract thickness: float with get,set


type PDFPageDrawRectangleOptions =
    abstract blendMode: BlendMode with get, set
    abstract borderColor: Color with get, set
    abstract borderDashArray: float array with get, set
    abstract borderDashPhase: float with get, set
    abstract borderLineCap: LineCapStyle with get, set
    abstract borderOpacity: float with get, set
    abstract borderWidth: float with get, set
    abstract color: Color with get, set
    abstract height: float with get, set
    abstract opacity: float with get, set
    abstract rotate: Rotation with get, set
    abstract width: float with get, set
    abstract x: float with get, set
    abstract xSkew: Rotation with get, set
    abstract y: float with get, set
    abstract ySkew: Rotation with get, set




type PDFPageDrawSVGOptions =
    abstract blendMode: BlendMode with get,set
    abstract borderColor: Color with get, set
    abstract borderDashArray: float array with get,set
    abstract borderDashPhase: float with get, set
    abstract borderLineCap: LineCapStyle with get, set
    abstract borderOpacity: float with get, set
    abstract borderWidth: float with get, set
    abstract color: Color with get, set
    abstract opacity: float  with get, set
    abstract rotate: Rotation with get, set
    abstract scale: float with get, set
    abstract x: float with get, set
    abstract y: float with get, set



type PDFPageDrawImageOptions =
    abstract height: float with get, set
    abstract opacity: float with get, set
    abstract width: float with get, set
    abstract x: float with get, set
    abstract y: float with get, set
    abstract rotate: Rotation with get, set
    abstract xSkew: Rotation with get, set
    abstract ySkew: Rotation with get, set
    abstract blendMode: BlendMode with get, set

[<RequireQualifiedAccess>]
type Text = 
    | BlendMode of BlendMode 
    | Color 

type PDFPageDrawTextOptions =
    abstract blendMode: BlendMode with get, set
    abstract color: Color with get, set    
    abstract font: PDFFont with get, set
    abstract lineHeight: float with get, set
    abstract maxWidth: float with get, set
    abstract opacity: float with get, set
    abstract rotate: Rotation with get,set
    abstract size: float with get,set
    abstract wordBreaks: string array with get, set
    abstract x: float with get,set
    abstract xSkew: Rotation with get,set
    abstract y: float with get,set
    abstract ySkew: Rotation with get,set

type FieldAppearanceOptions = 
    abstract backgroundColor: Color with get, set 
    abstract borderColor: Color with get, set 
    abstract borderWidth: float with get, set
    abstract font : PDFFont with get, set 
    abstract height : float with get, set 
    abstract rotate : Rotation with get, set 
    abstract textColor : Color with get, set 
    abstract width : float with get, set 
    abstract x : float with get, set 
    abstract y: float with get, set 




type PDFImage =
    /// The document to which this image belongs.
    abstract doc: PDFDocument with get
    /// The height of this image in pixels.
    abstract height : float with get
    /// The width of this image in pixels.
    abstract width : float with get
    /// Compute the width and height of this image after being scaled by the given factor.
    abstract scale : factor: float -> Size
    /// Get the width and height of this image after scaling it as large as possible while maintaining its aspect ratio and not exceeding the specified width and height.
    abstract scaleToFit : width: float * height: float -> Size
    // Get the width and height of this image
    abstract size : unit -> Size


type PDFRef = interface end


type PDFField =
    

     /// The document to which this field belongs.
    abstract doc : PDFDocument with get
    /// The unique reference assigned to this field within the document.
    abstract ref : PDFRef with get 
    /// Indicate that this field's value should not be exported when the form is submitted in a PDF reader. 
    abstract disableExporting: unit -> unit 
    /// Allow users to interact with this field and change its value in PDF readers via mouse and keyboard input. 
    abstract disableReadOnly: unit -> unit 
    /// Do not require this field to have a value when the form is submitted. 
    abstract disableRequired: unit -> unit 
    /// Indicate that this field's value should be exported when the form is submitted in a PDF reader. 
    abstract enableExporting: unit -> unit 
    /// Prevent PDF readers from allowing users to interact with this field or change its value. The field will not respond to mouse or keyboard input. 
    abstract enableReadOnly: unit -> unit 
    /// Require this field to have a value when the form is submitted.
    abstract enableRequired: unit -> unit 
    /// Get the fully qualified name of this field. 
    abstract getName : unit -> string 
    /// Returns true if this field's value should be exported when the form is submitted.
    abstract isExported : unit -> bool 
    /// Returns true if this field is read only. This means that PDF readers will not allow users to interact with the field or change its value. 
    abstract isReadOnly : unit -> bool 
    /// Returns true if this field must have a value when the form is submitted.
    abstract isRequired : unit -> bool 


type PDFButton =  
    inherit PDFField 
    /// Show this button on the specified page with the given text. 
    abstract addToPage : text: string * page: PDFPage * ?options: FieldAppearanceOptions -> unit
    /// Update the appearance streams for each of this button's widgets using the default appearance provider for buttons. 
    abstract defaultUpdateAppearances: font: PDFFont -> unit
    /// Returns true if this button has been marked as dirty, or if any of this button's widgets do not have an appearance stream. 
    abstract needsAppearancesUpdate: unit -> bool
    /// Set the font size for this field. Larger font sizes will result in larger text being displayed when PDF readers render this button. Font sizes may be integer or floating point numbers. Supplying a negative font size will cause this method to throw an error.
    abstract setFontSize: fontSize: float -> unit
    /// Display an image inside the bounds of this button's widgets. 
    abstract setImage: image: PDFImage * ?alignment : ImageAlignment -> unit





type PDFCheckBox = 
    inherit PDFField 
    /// Show this check box on the specified page with the given text. 
    abstract addToPage : page: PDFPage * ?options: FieldAppearanceOptions -> unit
    // Mark this check box
    abstract check: unit -> unit 
    /// Update the appearance streams for each of this check box's widgets using the default appearance provider for check boxes. 
    abstract defaultUpdateAppearances: unit -> unit
    /// Returns true if this check box is selected (either by a human user via a PDF reader, or else programmatically via software). 
    abstract isChecked: unit -> bool  
    /// Returns true if any of this check box's widgets do not have an appearance stream for its current state. 
    abstract needsAppearancesUpdate: unit -> bool
    /// Clears this check box. This method will mark this check box as dirty.
    abstract uncheck: unit -> unit 


type PDFDropdown = 
    inherit PDFField 

    
    abstract addOptions: option: string -> unit 
    abstract addOptions: options: string array -> unit 
    
    /// Show this dropdown on the specified page. 
    abstract addToPage: page: PDFPage * ?options: FieldAppearanceOptions -> unit 
    
    abstract clear: unit -> unit 
    
    /// Update the appearance streams for each of this dropdown's widgets using the default appearance provider for dropdowns.
    abstract defaultUpdateAppearances: font: PDFFont -> unit 

    abstract disableEditing: unit -> unit 
    abstract disableMultiselect: unit -> unit 
    abstract disableSelectOnClick: unit -> unit
    abstract disableSorting: unit -> unit 
    abstract disableSpellChecking: unit -> unit 

    abstract enableEditing: unit -> unit 
    abstract enableMultiselect: unit -> unit
    abstract enableSelectOnClick: unit -> unit 
    abstract enableSorting: unit -> unit 
    abstract enableSpellChecking: unit -> unit 

    abstract getOptions: unit -> string array
    abstract getSelected: unit -> string array

    abstract isEditable: unit -> bool
    abstract isMultiselect: unit -> bool
    abstract isSelectOnClick: unit -> bool
    abstract isSorted: unit -> bool
    abstract isSpellChecked: unit -> bool
    
    abstract needsAppearancesUpdate: unit -> bool 
    
    /// Select one or more values for this dropdown. This operation is analogous to a human user opening the dropdown in a PDF reader and clicking on a value to select it. This method will update the underlying state of the dropdown to indicate which values have been selected. PDF libraries and readers will be able to extract these values from the saved document and determine which values were selected.
    abstract select: options: string array * ?merge : bool -> unit 
    abstract select: option: string * ?merge : bool -> unit 

    /// Set the font size for this field. Larger font sizes will result in larger text being displayed when PDF readers render this dropdown. Font sizes may be integer or floating point numbers. Supplying a negative font size will cause this method to throw an error.
    abstract setFontSize: fontSize: float -> unit 
    /// Set the list of options that are available for this dropdown. These are the values that will be available for users to select when they view this dropdown in a PDF reader. Note that preexisting options for this dropdown will be removed. Only the values passed as options will be available to select.
    abstract setOptions: options: string array -> unit

type PDFOptionList = 
    inherit PDFField 

    abstract addOptions: option : string -> unit 
    abstract addOptions: options : string array -> unit 
    
    /// Show this option list on the specified page.
    abstract addToPage: page: PDFPage * ?options: FieldAppearanceOptions -> unit 
    
    /// Clear all selected values for this option list. This operation is equivalent to selecting an empty list. This method will update the underlying state of the option list to indicate that no values have been selected.
    abstract clear: unit -> unit
    
    ///  Update the appearance streams for each of this option list's widgets using the default appearance provider for option lists.   
    abstract defaultUpdateAppearances: font: PDFFont -> unit 
    
    abstract disableMultiselect: unit -> unit 
    abstract disableSelectOnClick: unit -> unit 
    abstract disableSorting: unit -> unit 
    
    abstract enableMultiselect: unit -> unit 
    abstract enableSelectOnClick: unit -> unit
    abstract enableSorting: unit -> unit

    abstract getOptions: unit -> string array
    
    abstract getSelected: unit -> string array
    
    abstract isMultiselect: unit -> bool 

    /// Returns true if the option selected by a user is stored, or "committed", when the user clicks the option. The alternative is that the user's selection is stored when the user leaves this option list field (by clicking outside of it - on another field, for example). 
    abstract isSelectOnClick: unit -> bool
    /// Returns true if the options of this option list are always displayed in alphabetical order, irrespective of the order in which the options were added to the option list
    abstract isSorted : unit -> bool
    /// Returns true if this option list has been marked as dirty, or if any of this option list's widgets do not have an appearance stream.
    abstract needsAppearancesUpdate: unit -> unit 
    /// Select one or more values for this option list. This operation is analogous to a human user opening the option list in a PDF reader and clicking on one or more values to select them. This method will update the underlying state of the option list to indicate which values have been selected. PDF libraries and readers will be able to extract these values from the saved document and determine which values were selected. 
    abstract select : options: string array * ?merge: bool -> unit 
    abstract select : option: string * ?merge : bool -> unit 
    /// Set the font size for this field. Larger font sizes will result in larger text being displayed when PDF readers render this option list. Font sizes may be integer or floating point numbers.
    abstract setFontSize: fontSize: float -> unit 
    /// Set the list of options that are available for this option list. These are the values that will be available for users to select when they view this option list in a PDF reader. Note that preexisting options for this option list will be removed. Only the values passed as options will be available to select.
    abstract setOptions: options: string array -> unit 
type PDFRadioGroup = 
    inherit PDFField

    /// Add a new radio button to this group on the specified page.
    abstract addOptionToPage: option: string * page: PDFPage * ?options : FieldAppearanceOptions -> unit
    
    /// Clear any selected option for this dropdown. This will result in all radio buttons in this group being toggled off. This method will update the underlying state of the dropdown to indicate that no radio buttons have been selected. 
    abstract clear : unit -> unit 
    
    /// Update the appearance streams for each of this group's radio button widgets using the default appearance provider for radio groups.
    abstract defaultUpdateAppearances: unit -> unit

    abstract disableMutualExclusion: unit -> unit
    abstract disableOffToggling: unit -> unit
    
    abstract enableMutualExclusion: unit -> unit
    abstract enableOffToggling: unit -> unit
    /// Get the list of available options for this radio group. Each option is represented by a radio button. These radio buttons are displayed at various locations in the document, potentially on different pages (though typically they are stacked horizontally or vertically on the same page).
    abstract getOptions: unit -> string array
    /// Get the selected option for this radio group. The selected option is represented by the radio button in this group that is turned on. At most one radio button in a group can be selected. If no buttons in this group are selected, undefined is returned.
    abstract getSelected: unit -> string option
    /// Returns true if the radio buttons in this group are mutually exclusive. This means that when the user selects a radio button, only that specific button will be turned on. Even if other radio buttons in the group represent the same value, they will not be enabled. The alternative to this is that clicking a radio button will select that button along with any other radio buttons in the group that share the same value.
    abstract isMutuallyExclusive: unit -> bool
    /// Returns true if users can click on radio buttons in this group to toggle them off. The alternative is that once a user clicks on a radio button to select it, the only way to deselect it is by selecting on another radio button in the group.
    abstract isOffToggleable: unit -> bool 
    /// Returns true if any of this group's radio button widgets do not have an appearance stream for their current state. 
    abstract needsAppearancesUpdate: unit -> bool 
    /// Select an option for this radio group. This operation is analogous to a human user clicking one of the radio buttons in this group via a PDF reader to toggle it on. This method will update the underlying state of the radio group to indicate which option has been selected. PDF libraries and readers will be able to extract this value from the saved document and determine which option was selected.
    abstract select : option: string -> unit 

type PDFSignature = 
    inherit PDFField 

    abstract needsAppearancesUpdate: unit -> bool 


type PDFTextField = 
    inherit PDFField 
    /// Show this text field on the specified page
    abstract addToPage : page: PDFPage * ?options: FieldAppearanceOptions -> unit
    /// Update the appearance streams for each of this text field's widgets using the default appearance provider for text fields.
    abstract defaultUpdateAppearances: font: PDFFont -> unit
    abstract disableCombing: unit -> unit
    abstract disableFileSelection: unit -> unit
    abstract disableMultiline: unit -> unit 
    abstract disablePassword: unit -> unit
    abstract disableRichFormatting: unit -> unit
    abstract disableScrolling: unit -> unit 
    abstract disableSpellChecking: unit -> unit 
    /// Split this field into n equal size cells with one character in each (where n is equal to the max length of the text field). This will cause all characters in the field to be displayed an equal distance apart from one another.
    abstract enableCombing: unit -> unit 
    /// Indicate that this text field is intended to store a file path. The contents of the file stored at that path should be submitted as the value of the field. 
    abstract enableFileSelection: unit -> unit 
    /// Display each line of text on a new line when this field is displayed in a PDF reader.
    abstract enableMultiline: unit -> unit
    /// Indicate that this text field is intended for storing a secure password.
    abstract enablePassword: unit -> unit 
    /// Indicate that this field contains XFA data - or rich text. Note that pdf-lib does not support reading or writing rich text fields. Nor do most PDF readers and writers. Rich text fields are based on XFA (XML Forms Architecture). Relatively few PDFs use rich text fields or XFA. Unlike PDF itself, XFA is not an ISO standard. XFA has been deprecated in PDF 2.0
    abstract enableRichFormatting: unit -> unit 
    
    /// Allow PDF readers to present a scroll bar to the user when the contents of this text field do not fit within its view bounds.
    abstract enableScrolling: unit -> unit 
    
    /// Allow PDF readers to spell check the text entered in this field. 
    abstract enableSpellChecking: unit -> unit 
    
    ///  Get the alignment for this text field. This value represents the justification of the text when it is displayed to the user in PDF readers. 
    abstract getAlignment: unit -> TextAlignment
    
    /// Get the maximum length of this field. This value represents the maximum number of characters that can be typed into this field by the user.
    abstract getMaxLength: unit -> int option
    

    /// Get the text that this field contains. This text is visible to users who view this field in a PDF reader.
    abstract getText: unit -> string option

    /// Returns true if this is a combed text field. This means that the field is split into n equal size cells with one character in each (where n is equal to the max length of the text field). The result is that all characters in this field are displayed an equal distance apart from one another. 
    abstract isCombed: unit -> bool
    
    /// Returns true if the contents of this text field represent a file path. 
    abstract isFileSelector: unit -> bool 
    
    /// Returns true if each line of text is shown on a new line when this field is displayed in a PDF reader. The alternative is that all lines of text are merged onto a single line when displayed. 
    abstract isMultiline: unit -> bool

    /// Returns true if this is a password text field. This means that the field is intended for storing a secure password.
    abstract isPassword: unit -> bool
    
    /// Returns true if this text field contains rich text. 
    abstract isRichFormatted: unit -> bool
    
    /// Returns true if PDF readers should allow the user to scroll the text field when its contents do not fit within the field's view bounds.
    abstract isScrollable: unit -> bool 

    /// Returns true if the text entered in this field should be spell checked by PDF readers.
    abstract isSpellChecked: unit -> bool 

    /// Returns true if this text field has been marked as dirty, or if any of this text field's widgets do not have an appearance stream. 
    abstract needsAppreancesUpdate: unit -> bool 
    
    /// Remove the maximum length for this text field. This allows any number of characters to be typed into this field by the user. 
    abstract removeMaxLength: unit -> unit 

    /// Set the alignment for this text field. This will determine the justification of the text when it is displayed to the user in PDF readers. There are three possible alignments: left, center, and right. 
    abstract setAlignment: alignment: TextAlignment -> unit 
    
    /// Set the font size for this field. Larger font sizes will result in larger text being displayed when PDF readers render this text field. 
    abstract setFontSize: fontSize : float -> unit 

    /// Display an image inside the bounds of this text field's widgets. 
    abstract setImage: image: PDFImage -> unit 

    // [<Emit("$0.setMaxLength(undefined)")>]
    // abstract setNoMaxLength: unit -> unit

    abstract setMaxLength: maxLength : int -> unit 
    /// Set the text for this field. This operation is analogous to a human user clicking on the text field in a PDF reader and typing in text via their keyboard. This method will update the underlying state of the text field to indicate what text has been set. PDF libraries and readers will be able to extract these values from the saved document and determine what text was set.
    abstract setText: text: string -> unit 




type PDFForm = 
    /// The document to which this form belongs.
    abstract doc : PDFDocument with get
    /// Create a new button field in this PDFForm with the given name.
    /// An error will be thrown if a field already exists with the provided name.
    abstract createButton: name: string -> PDFButton
    /// Create a new check box field in this PDFForm with the given name.
    /// An error will be thrown if a field already exists with the provided name.
    abstract createCheckBox: name: string -> PDFCheckBox

    abstract createDropdown: name: string -> PDFDropdown 

    abstract createOptionList: name: string -> PDFOptionList 

    abstract createRadioGroup: name: string -> PDFRadioGroup

    abstract createTextField: name: string -> PDFTextField 

    /// Disconnect the XFA data from this PDFForm (if any exists). This will force readers to fallback to standard fields if the PDFDocument contains any. 
    abstract deleteXFA: unit -> unit 

    /// Returns true is the specified field has been marked as dirty.
    abstract fieldIsDirty: fieldRef: PDFRef -> unit 

    /// Flatten all fields in this PDFForm.
    ///
    ///Flattening a form field will take the current appearance for each of that field's widgets and make them part of their page's content stream. All form fields and annotations associated are then removed. Note that once a form has been flattened its fields can no longer be accessed or edited.
    ///
    ///This operation is often used after filling form fields to ensure a consistent appearance across different PDF readers and/or printers. Another common use case is to copy a template document with form fields into another document. In this scenario you would load the template document, fill its fields, flatten it, and then copy its pages into the recipient document - the filled fields will be copied over.
    abstract flatten: ?options: FlattenOptions -> unit 


    abstract getButton: name: string -> PDFButton 
    abstract getCheckBox: name: string -> PDFCheckBox
    abstract getDefaultFont: unit -> PDFFont 
    abstract getDropdown: name: string -> PDFDropdown 
    abstract getField: name: string -> PDFField 
    abstract getFieldMaybe: name: string -> PDFField option 
    abstract getFields: unit -> PDFField array 
    abstract getOptionList: name: string -> PDFOptionList 
    abstract getRadioGroup: name: string -> PDFRadioGroup 
    abstract getSignature: name: string -> PDFSignature 
    abstract getTextField: name: string -> PDFTextField 

    /// Returns true if this PDFForm has XFA data. Most PDFs with form fields do not use XFA as it is not widely supported by PDF readers.
    abstract hasXFA: unit -> bool 

    abstract markFieldAsClean: fieldRef: PDFRef -> unit 
    abstract markFieldAsDirty: fieldRef: PDFRef -> unit 

    abstract removeField: field: PDFField -> unit 

    /// Update the appearance streams for all widgets of all fields in this PDFForm. Appearance streams will only be created for a widget if it does not have any existing appearance streams, or the field's value has changed 
    abstract updateFieldAppearances: ?font : PDFFont -> unit 






type PDFPage =
    /// The document to which this page belongs.
    abstract doc : PDFDocument with get
    /// Draw a line on this page.
    abstract drawLine: options: PDFPageDrawLineOptions -> unit
    
    abstract drawPage: embeddedPage : PDFEmbeddedPage * options: PDFPageDrawPageOptions -> unit 
    /// Draw a rectangle on this page.
    abstract drawRectangle: options: PDFPageDrawRectangleOptions -> unit
    /// Draw one or more lines of text on this page.
    abstract drawText : text : string * ?options: PDFPageDrawTextOptions -> unit
    /// Draw an SVG path on this page.
    abstract drawSvgPath: path: string * ?options: PDFPageDrawSVGOptions -> unit
    /// Draw an image on this page.
    abstract drawImage : image: PDFImage * options: PDFPageDrawImageOptions -> unit
    // Translate this page's content to a new location on the page. This operation is often useful after resizing the page with setSize.
    abstract translateContent: x: float * y: float -> unit
    // Resize this page by increasing or decreasing its width
    abstract setWidth: width: float -> unit
    /// Resize this page by increasing or decreasing its width and height.
    ///    Note that the PDF specification does not allow for pages to have explicit widths and heights. Instead it defines the "size" of a page in terms of five rectangles: the MediaBox, CropBox, BleedBox, TrimBox, and ArtBox. As a result, this method cannot directly change the width and height of a page. Instead, it works by adjusting these five boxes.
    ///
    ///This method performs the following steps:
    ///
    ///     Set width & height of MediaBox.
    ///     Set width & height of CropBox, if it has same dimensions as MediaBox.
    ///     Set width & height of BleedBox, if it has same dimensions as MediaBox.
    ///     Set width & height of TrimBox, if it has same dimensions as MediaBox.
    ///     Set width & height of ArtBox, if it has same dimensions as MediaBox.
    /// This approach works well for most PDF documents as all PDF pages must have a MediaBox, but relatively few have a CropBox, BleedBox, TrimBox, or ArtBox. And when they do have these additional boxes, they often have the same dimensions as the MediaBox. However, if you find this method does not work for your document, consider setting the boxes directly:
    ///
    ///     PDFPage.setMediaBox
    ///     PDFPage.setCropBox
    ///     PDFPage.setBleedBox
    ///     PDFPage.setTrimBox
    ///     PDFPage.setArtBox
    abstract setSize: width: float * height: float -> unit
    /// Rotate this page by a multiple of 90 degrees.
    abstract setRotation: angle: Rotation -> unit
    /// Choose a default line height for this page. The default line height will be used whenever text is drawn on this page and no line height is specified.
    abstract setLineHeight: lineHeight: float -> unit
    /// Resize this page by increasing or decreasing its height.
    abstract setHeight: height: float -> unit
    /// Choose a default font size for this page. The default font size will be used whenever text is drawn on this page and no font size is specified.
    abstract setFontSize : fontSize: float -> unit
    /// Choose a default font color for this page. The default font color will be used whenever text is drawn on this page and no font color is specified.
    abstract setFontColor: fontColor: Color -> unit
    /// Choose a default font for this page. The default font will be used whenever text is drawn on this page and no font is specified.
    abstract setFont: font: PDFFont -> unit
    /// Scale the content of a page. This is useful after resizing an existing page. This scales only the content, not the annotations.
    abstract scaleContent: x: float * y: float -> unit
    /// Scale the annotations of a page. This is useful if you want to scale a page with comments or other annotations.
    abstract scaleAnnotations: x: float * y: float -> unit
    /// Scale the size, content, and annotations of a page.
    abstract scale: x: float * y: float -> unit
    /// Reset the x and y coordinates of this page to (0, 0). This operation is often useful after calling translateContent.
    abstract resetPosition: unit -> unit
    /// Change the default position of this page to be further up the y-axis.
    abstract moveUp: yIncrease: float -> unit
    /// Change the default position of this page.
    abstract moveTo: x: float * y: float -> unit
    /// Change the default position of this page to be further right on the x-axis.
    abstract moveRight: xIncrease: float -> unit
    /// Change the default position of this page to be further left on the x-axis.
    abstract moveLeft: xDecrease: float -> unit
    /// Change the default position of this page to be further down the y-axis.
    abstract moveDown:  yDecrease: float -> unit
    /// Get the default y coordinate of this page.
    abstract getY: unit -> float
    /// Get the default x coordinate of this page.
    abstract getX: unit -> float
    /// Get this page's width.
    abstract getWidth: unit -> float
    /// Get this page's width and height.
    abstract getSize: unit -> Size
    /// Get this page's rotation angle in degrees. The rotation angle of the page in degrees (always a multiple of 90 degrees).
    abstract getRotation: unit -> Rotation
    /// Get the default position of this page.
    abstract getPosition: unit -> Position
    /// Get this page's height.
    abstract getHeight: unit -> float


// namespaces can be imported as default
[<Import("default", from ="@pdf-lib/fontkit")>]
[<Emit("$1.registerFontkit($0)")>]
let registerFontKit (document: PDFDocument) : unit = jsNative

[<Import("degrees", from="pdf-lib")>]
let degrees(num: float): Degrees = jsNative

[<Import("rgb", from="pdf-lib")>]
let rgb (red: float, green: float, blue: float) : RGB = jsNative

[<Import("PDFDocument", from="pdf-lib")>]
let PDFDocument : PDFDocumentStatic = jsNative



