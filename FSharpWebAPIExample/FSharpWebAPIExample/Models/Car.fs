namespace FSharpWebAPIExample.Models

open Newtonsoft.Json

[<CLIMutable>]
type Car = {
    Make : string
    Model : string
}
