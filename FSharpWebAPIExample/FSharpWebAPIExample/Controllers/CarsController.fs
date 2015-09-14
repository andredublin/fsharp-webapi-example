namespace FSharpWebAPIExample.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open DataAccess

/// Retrieves values.
[<RoutePrefix("v1/cars")>]
type CarsController() =
    inherit ApiController()

    [<HttpGet>]
    [<Route("{id:int}")>]
    member controller.Car(id : int) = CarsContext.getById id

    [<HttpGet>]
    [<Route("{make:string}")>]
    member controller.Car(make : string) = CarsContext.getByMake make