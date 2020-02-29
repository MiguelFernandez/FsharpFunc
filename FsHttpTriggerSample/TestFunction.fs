namespace FsHttpTriggerSample

open System.Collections.Generic
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.AspNetCore.Http
open Newtonsoft.Json
open Microsoft.Azure.WebJobs.Extensions
open System.IO
open Microsoft.Extensions.Logging
open Microsoft.Azure.WebJobs.Extensions.Http
open System
 



type MyRecord = {
  id: string
  name: string
  }

module CosmosDbFunc = 
   
   

    [<FunctionName("CosmosDBSample")>]
    let Run([<HttpTrigger(AuthorizationLevel.Anonymous, "get")>] req: HttpRequest ,
            [<CosmosDB("ToDoList","Items", ConnectionStringSetting = "MyConnectionString", SqlQuery = "SELECT top 2 * FROM c")>] documents: IEnumerable<MyRecord>) =
    
     OkObjectResult(documents)
     



