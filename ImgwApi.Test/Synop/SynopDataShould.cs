﻿namespace ImgwApi.Test.Synop;

public class SynopDataShould
{
    [Theory]
    [InlineData("2023-09-12", 1, "2023-09-12T01:00:00")]
    [InlineData("2023-09-12", 10, "2023-09-12T10:00:00")]
    [InlineData("2023-09-12", 23, "2023-09-12T23:00:00")]
    public void CalculateDateTimeOfMeasurementWhenConstructed(string dateText, int hour, string expectedDateText)
    {
        var date = DateTime.Parse(dateText);
        var synopData = new SynopData(1, "a", date, hour, 2, 10, 2, 3, 4, null);

        var expectedDate = DateTime.Parse(expectedDateText);

        synopData.DateTimeOfMeasurement.Should().Be(expectedDate);
    }

    [Theory]
    [InlineData(12600, SynopStation.BielskoBiala)]
    [InlineData(12560, SynopStation.Katowice)]
    [InlineData(123, null)]
    public void MapSynopStationWhenConstructed(int id, SynopStation? expected)
    {
        var synopData = new SynopData(id, "a", DateTime.UtcNow, 0, 2, 10, 2, 3, 4, null);

        synopData.Station.Should().Be(expected);
    }
}