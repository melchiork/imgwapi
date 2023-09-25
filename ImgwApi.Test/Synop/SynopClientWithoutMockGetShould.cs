namespace ImgwApi.Test.Synop;

[Trait("Category","Integration")]
public class SynopClientWithoutMockGetShould
{
    private readonly SynopClient _client = SynopClient.Create();

    [Fact]
    public async Task GetAllAsync()
    {
        var result = await _client.GetAllAsync();

        result.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetAsync()
    {
        var result = await _client.GetAsync(SynopStations.Chojnice);

        result.StationId.Should().Be((int)SynopStations.Chojnice);
    }
}