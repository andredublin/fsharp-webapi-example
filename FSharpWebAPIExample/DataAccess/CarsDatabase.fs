namespace DataAccess

module CarsContext = 
    open FSharp.Data
    
    [<CLIMutable>]
    type Car = 
        { ID : int
          Make : string
          Model : string
          Year : int }
    
    /// Defines our database provider
    type CarsDatabase = SqlProgrammabilityProvider< ConnectionStringOrName="name=CarsDatabase", ConfigFile="app.config" >
    
    let toAutomobile (record : CarsDatabase.dbo.wspGetAutomobiles.Record) : Car = 
        { ID = record.ID
          Make = record.Make
          Model = record.Model
          Year = record.Year }
    
    /// Get a single car by ID
    let getById id = 
        async { 
            use wsproc = new CarsDatabase.dbo.wspGetAutomobiles()
            let! result = wsproc.AsyncExecuteSingle(id, "")
            return result |> Option.map toAutomobile
        }
    
    /// Get multiple cars by make
    let getByMake make = 
        async { 
            use wsproc = new CarsDatabase.dbo.wspGetAutomobiles()
            let! result = wsproc.AsyncExecute(0, make)
            return result |> Seq.map toAutomobile
        }
