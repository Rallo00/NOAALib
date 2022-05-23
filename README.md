# NOAALib
This C# Library allows users to get METAR and TAF of the desidered airport by using NOAA provided APIs.

---- REQUISITES ----

- Requires Newtonsoft.Json.dll to parse JSON information, get it from NuGet into Visual Studio.
- .Net Framework SDK v4.5.1

---- HOW TO USE ----
- Add the provided DLL file as Reference into your C# project.
- Add `using NOAALib;` at the top of your Project code-behind file.

Call the APIs by doing so:
```cs
public static async Task<string> GetStationMetarRaw(string icao)
public static async Task<string> GetStationMetar(string icao)
public static async Task<string> GetStationTafRaw(string icao)
public static async Task<string> GetStationTaf(string icao)
```

To avoid thread blocking I recommend to use async methods.

---- PROVIDED INFORMATION ----
- Raw Json METAR;
- Raw METAR;
- Raw Json TAF;
- Raw TAF;
