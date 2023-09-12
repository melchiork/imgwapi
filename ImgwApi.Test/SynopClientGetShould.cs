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
    public async Task ReadAllCurrentData()
    {
        var result = await _client.GetAll();

        result.Should().NotBeNullOrEmpty();
    }
}