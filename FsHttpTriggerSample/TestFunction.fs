namespace FsHttpTriggerSample



type MyRecord = {
  id: string
  name: string
  }

module CosmosDbFunc = 

    open Microsoft.AspNetCore.Mvc
    open Microsoft.Azure.WebJobs
    open Microsoft.AspNetCore.Http
    open Microsoft.Azure.WebJobs.Extensions.Http
    open System.Collections.Generic
    

    [<FunctionName("CosmosDBSample")>]
    let Run([<HttpTrigger(AuthorizationLevel.Anonymous, "get")>] req: HttpRequest,
            [<CosmosDB("ToDoList","Items", ConnectionStringSetting = "MyConnectionString", SqlQuery = "SELECT top 2 * FROM c order by c._ts desc")>] documents: IEnumerable<MyRecord>) =
    
     OkObjectResult(documents)
     



