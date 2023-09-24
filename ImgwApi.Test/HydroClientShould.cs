namespace ImgwApi.Test;

public class HydroClientShould
{
    private readonly HydroClient _sut = HydroClient.Create();

    [Fact]
    public async Task GetAll()
    {
        var result = await _sut.GetAllAsync();

        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
    }
}