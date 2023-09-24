namespace ImgwApi.Test;

public class HydroClientCreateShould
{
    [Fact]
    public void ReturnNewInstanceWhenNoParamsCtorIsUsed()
    {
        var client = HydroClient.Create();

        client.Should().NotBeNull();
    }

    [Fact]
    public void ReturnNewInstanceWhenProvidedWithHttpClient()
    {
        var client = HydroClient.Create(new HttpClient());

        client.Should().NotBeNull();
    }

    [Fact]
    public void ThrowExceptionWhenNullIsProvided()
    {
        Action act = () => HydroClient.Create(null);

        act.Should().Throw<ArgumentNullException>();
    }
}