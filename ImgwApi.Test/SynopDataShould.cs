namespace ImgwApi.Test;

public class SynopDataShould
{
    [Theory]
    [InlineData("2023-09-12", 1, "2023-09-12T01:00:00")]
    [InlineData("2023-09-12", 10, "2023-09-12T10:00:00")]
    [InlineData("2023-09-12", 23, "2023-09-12T23:00:00")]
    public void Ctor_CalculateDateTimeOfMeasurement(string dateText, int hour, string expectedDateText)
    {
        var date = DateTime.Parse(dateText);
        var synopData = new SynopData(1, "a", date, hour, 2, 10, 2, 3, 4, null);

        var expectedDate = DateTime.Parse(expectedDateText);

        synopData.DateTimeOfMeasurement.Should().Be(expectedDate);
    }

}