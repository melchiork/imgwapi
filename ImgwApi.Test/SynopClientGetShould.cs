namespace ImgwApi.Test;

[Trait("Category","Integration")]
public class SynopClientGetShould
{
    private readonly SynopClient _client;
    
    public SynopClientGetShould()
    {
        _client = SynopClient.Create();
    }

    [Fact]
    public async Task GetAllCurrentData()
    {
        var result = await _client.GetAllAsync();

        result.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetDataForStation()
    {
        var result = await _client.GetAsync(SynopStations.Warszawa);

        result.StationId.Should().Be((int)SynopStations.Warszawa);
    }
}