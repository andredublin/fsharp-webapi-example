namespace FSharpWebAPIExample.Entities

[<AutoOpen>]
module DomainTypes = 
    [<CLIMutable>]
    type Car = 
        { ID : int
          Make : string
          Model : string
          Year : int }
