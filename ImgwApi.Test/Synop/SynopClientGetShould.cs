namespace ImgwApi.Test.Synop;

public class SynopClientGetShould
{
    private SynopClient _client = null!;

    [Fact]
    public async Task GetAllAsync()
    {
        _client = SynopClient.Create(new HttpClient(new MockHttpMessageHandler("./Synop/FullSynop.json")));

        var result = await _client.GetAllAsync();

        result.Should().HaveCount(62);
    }

    [Fact]
    public async Task GetAsync()
    {
        _client = SynopClient.Create(new HttpClient(new MockHttpMessageHandler("./Synop/SingleSynop.json")));
        var expected = new SynopData(12235, "Chojnice", DateTime.Parse("2023-09-25"), 
            18, 16.5m, 3, 110, 70.5m, 0, 1027.8m);

        var result = await _client.GetAsync(SynopStation.Chojnice);

        result.Should().BeEquivalentTo(expected);
    }
}