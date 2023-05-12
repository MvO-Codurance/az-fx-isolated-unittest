using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp;

public class JsonFunction
{
    private readonly ILogger _logger;

    public JsonFunction(ILogger<JsonFunction> logger)
    {
        _logger = logger;
    }
    
    [Function("JsonFunction")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);

        var welcome = new WelcomeMessage { Message = "Welcome to Azure Functions!" };
        await response.WriteAsJsonAsync(welcome);

        return response;
        
    }
}