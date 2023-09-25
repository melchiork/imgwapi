using System.Net;

namespace ImgwApi.Test.Synop;

public class SynopClientGetWithErrorShould
{
    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.GatewayTimeout)]
    [InlineData(HttpStatusCode.RequestTimeout)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task ThrowExceptionWhenNon2XXCodeIsReturnedForGetAll(HttpStatusCode code)
    {
        var client = SynopClient.Create(new HttpClient(new MockHttpMessageHandler(code)));

        var act = async () => await client.GetAllAsync();

        await act.Should().ThrowAsync<ApiClientException>().WithMessage($"Api returned error code {code}");
    }

    [Theory]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.GatewayTimeout)]
    [InlineData(HttpStatusCode.RequestTimeout)]
    [InlineData(HttpStatusCode.InternalServerError)]
    public async Task ThrowExceptionWhenNon2XXCodeIsReturnedForGet(HttpStatusCode code)
    {
        var client = SynopClient.Create(new HttpClient(new MockHttpMessageHandler(code)));

        var act = async () => await client.GetAsync(SynopStations.Gdansk);

        await act.Should().ThrowAsync<ApiClientException>().WithMessage($"Api returned error code {code}");
    }
}