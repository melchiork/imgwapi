[![NuGet version (ImgwApi)](https://img.shields.io/nuget/v/ImgwApi.svg?style=flat-square)](https://www.nuget.org/packages/ImgwApi/)

# ImgwApi
.NET API client for IMGW (Instytut Meteorologii i Gospodarki Wodnej) API. This is not an official package nor it is endorsed by IMGW in any way.

## Usage Restrictions
* [https://danepubliczne.imgw.pl/](https://danepubliczne.imgw.pl/)
* [https://danepubliczne.imgw.pl/apiinfo](https://danepubliczne.imgw.pl/apiinfo)

## Usage

```csharp
var client = SynopClient.Create();

//call IMGW weather api at https://danepubliczne.imgw.pl/api/data/synop/
var result = await client.GetAllAsync();

var avgTemp = result.Select(x => x.TemperatureC).Average();

//read for single station
var resultForWarsaw = await client.GetAsync(SynopStations.Warszawa);

//create Api Client with external HttpClient
var client = SynopClient.Create(new HttpClient());

//register in DI - there are no public constuctors in SynopClient, only factory methods
services.AddSingleton<ISynopClient>(serviceProvider => SynopClient.Create())

//create hydro client
var hydroClient = HydroClient.Create();

//call IMGW hydro api at https://danepubliczne.imgw.pl/api/data/hydro/
var result = await hydroClient.GetAllAsync();
```

## License
This package (but not the data, see Usage Restrictions above) comes with MIT license.