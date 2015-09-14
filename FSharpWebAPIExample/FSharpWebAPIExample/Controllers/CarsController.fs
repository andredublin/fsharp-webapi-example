namespace FSharpWebAPIExample.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http
open FSharpWebAPIExample.CarsRepository

[<RoutePrefix("v1/cars")>]
type CarsController() = 
    inherit ApiController()
    
    [<HttpGet>]
    [<Route("{id:int}")>]
    member controller.Car(id : int) = Cars.getById id
    
    [<HttpGet>]
    [<Route("{make:alpha}")>]
    member controller.Car(make : string) = Cars.getByMake make
