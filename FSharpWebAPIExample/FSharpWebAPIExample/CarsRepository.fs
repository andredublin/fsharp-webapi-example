namespace FSharpWebAPIExample.CarsRepository

open FSharpWebAPIExample.Entities

module Cars = 
    open FSharp.Data
    
    type CarsDatabase = SqlProgrammabilityProvider< ConnectionStringOrName="name=CarsDatabase", ConfigFile="Web.config" >
    
    let toAutomobile (record : CarsDatabase.dbo.wspGetAutomobiles.Record) : Car = 
        { ID = record.ID
          Make = record.Make
          Model = record.Model
          Year = record.Year }
    
    let getById id = 
        async { 
            use wsproc = new CarsDatabase.dbo.wspGetAutomobiles()
            let! result = wsproc.AsyncExecuteSingle(id, "")
            return result.Value |> toAutomobile
        }
    
    let getByMake make = 
        async { 
            use wsproc = new CarsDatabase.dbo.wspGetAutomobiles()
            let! result = wsproc.AsyncExecute(0, make)
            return result |> Seq.map toAutomobile
        }
