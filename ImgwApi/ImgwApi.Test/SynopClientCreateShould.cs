namespace ImgwApi.Test;

public class SynopClientCreateShould
{
    [Fact]
    public void NoParams_ReturnNewInstance()
    {
        var client = SynopClient.Create();

        client.Should().NotBeNull();
    }
}