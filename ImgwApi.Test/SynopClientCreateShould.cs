namespace ImgwApi.Test;

public class SynopClientCreateShould
{
    [Fact]
    public void NoParams_ReturnNewInstance()
    {
        var client = SynopClient.Create();

        client.Should().NotBeNull();
    }

    [Fact]
    public void ClientProvided_ReturnNewInstance()
    {
        var client = SynopClient.Create(new HttpClient());

        client.Should().NotBeNull();
    }

    [Fact]
    public void NullClientProvided_ReturnNewInstance()
    {
        Action act = () => SynopClient.Create(null);

        act.Should().Throw<ArgumentNullException>();
    }
}