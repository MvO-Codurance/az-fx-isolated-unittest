using Microsoft.Azure.Functions.Isolated.TestDoubles;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Microsoft.Azure.Functions.Isolated.TestDoubles.Extensions;

namespace MyFunctionApp.Tests;
public class JsonFunctionTest
{
    [Fact]
    public async Task When_Invoked_Responds_Correct()
    {
        //Arrange
        var requestData = MockHelpers.CreateHttpRequestData();

        //Act
        var sut = new JsonFunction(Mock.Of<ILogger<JsonFunction>>());
        var response = await sut.Run(requestData);
        var result = response.ReadHttpResponseDataAsJson<WelcomeMessage>();

        //Assert
        Assert.NotNull(result);
        var expected = new WelcomeMessage { Message = "Welcome to Azure Functions!" };
        Assert.Equal(expected, result);
    }

}
