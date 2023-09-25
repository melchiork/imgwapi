namespace ImgwApi.Test.Synop;

public class SynopClientCreateShould
{
    [Fact]
    public void ReturnNewInstanceWhenNoParamsCtorIsUsed()
    {
        var client = SynopClient.Create();

        client.Should().NotBeNull();
    }

    [Fact]
    public void ReturnNewInstanceWhenProvidedWithHttpClient()
    {
        var client = SynopClient.Create(new HttpClient());

        client.Should().NotBeNull();
    }

    [Fact]
    public void ThrowExceptionWhenNullIsProvided()
    {
        Action act = () => SynopClient.Create(null);

        act.Should().Throw<ArgumentNullException>();
    }
}