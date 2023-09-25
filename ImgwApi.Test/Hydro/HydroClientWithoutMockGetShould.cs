namespace ImgwApi.Test.Hydro;

[Trait("Category", "Integration")]
public  class HydroClientWithoutMockGetShould
{
    private readonly HydroClient _client = HydroClient.Create();

    [Fact]
    public async Task GetAllAsync()
    {
        var result = await _client.GetAllAsync();

        result.Should().NotBeNullOrEmpty();
    }
}