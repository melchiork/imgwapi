# ImgwApi
.NET API client for IMGW (Instytut Meteorologii i Gospodarki Wodnej) API. This is not an official package nor it is endorsed by IMGW in any way.

## Usage Restrictions
* [https://danepubliczne.imgw.pl/](https://danepubliczne.imgw.pl/)
* [https://danepubliczne.imgw.pl/apiinfo](https://danepubliczne.imgw.pl/apiinfo)

## Usage

```csharp
var client = SynopClient.Create();

//calls IMGW weather api at https://danepubliczne.imgw.pl/api/data/synop/
var result = await _client.GetAllAsync();

var avgTemp = result.Select(x => x.TemperatureC).Average();

//...

var resultForWarsaw = await _client.GetAsync(SynopStations.Warszawa);
```

## License
This package (but not the data, see Usage Restrictions above) comes with MIT license.