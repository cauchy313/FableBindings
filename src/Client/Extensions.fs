[<AutoOpen>]
module Extensions


type AsyncOperationStatus<'t> =
    | Started
    | Finished of 't
