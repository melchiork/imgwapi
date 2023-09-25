namespace ImgwApi.Test.Hydro;

public class HydroClientShould
{
    private readonly HydroClient _sut;

    public HydroClientShould()
    {
        _sut =  HydroClient.Create(new HttpClient(new MockHttpMessageHandler("./Hydro/FullHydro.json")));
    }

    [Fact]
    public async Task GetAllAsync()
    {
        var result = await _sut.GetAllAsync();

        result.Should().HaveCount(609);
    }

    [Fact]
    public async Task ParseSingleCorrectlyWhenGetAllAsyncSucceeds()
    {
        var expected = new HydroData(151140030, "Przewoźniki", "Skroda", "lubuskie", 
            224, DateTime.Parse("2023-09-25 18:00:00"),
            null, null, 
            0, DateTime.Parse("2023-03-15 10:59:00"), 
            0, DateTime.Parse("2023-09-11 10:00:00"));

        var result = await _sut.GetAllAsync();

        result.First().Should().BeEquivalentTo(expected);
    }
}