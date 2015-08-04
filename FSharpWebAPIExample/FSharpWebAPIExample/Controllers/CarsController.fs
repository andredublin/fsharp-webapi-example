namespace FSharpWebAPIExample.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open FSharpWebAPIExample.Models

/// Retrieves values.
[<RoutePrefix("v1/cars")>]
type CarsController() =
    inherit ApiController()

    let values = [ 
        { Make = "Ford"; Model = "Mustang"; Id = 1 }; 
        { Make = "Nissan"; Model = "Titan"; Id = 2 }; 
        { Make = "Audi"; Model = "R8"; Id = 3 } 
    ]

    /// Gets all values.
    [<HttpGet>]
    [<Route("")>]
    member x.AllCars() = values

    [<HttpGet>]
    [<Route("{id:int}")>]
    member x.Car(id : int) = values |> List.filter(fun car -> car.Id = id)