using System.Net;

namespace ImgwApi.Test;

public class HydroClientGetWithErrorShould
{
    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.GatewayTimeout)]
    [InlineData(HttpStatusCode.RequestTimeout)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task ThrowExceptionWhenNon2XXCodeIsReturnedForGetAll(HttpStatusCode code)
    {
        var client = HydroClient.Create(new HttpClient(new MockHttpMessageHandler(code)));

        var act = async () => await client.GetAllAsync();

        await act.Should().ThrowAsync<ApiClientException>().WithMessage($"Api returned error code {code}");
    }
}