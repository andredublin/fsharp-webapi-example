namespace FSharpWebAPIExample.Models

open Newtonsoft.Json

[<CLIMutable>]
type Car = {
    Id : int
    Make : string
    Model : string
}
