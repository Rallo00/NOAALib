using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

public class NOAALib
{
    private static string URL_METAR = "https://aviationweather.gov/api/data/metar?ids=";
    private static string URL_TAF = "https://aviationweather.gov/api/data/taf?ids=";
    /// <summary>
    /// Obtain RAW text METAR from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String containing raw string METAR</returns>
    public static async Task<string> GetAirportMetarAsync(string icao)
    {
        return await Http_GetRequest(URL_METAR + icao + "&format=raw&taf=false&hours=0");
    }
    /// <summary>
    /// Obtain JSON raw text METAR from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String JSON coded of station METAR</returns>
    public static async Task<string> GetAirportMetarJsonAsync(string icao)
    {
        string jsonRaw = await Http_GetRequest(URL_METAR + icao + "&format=json&taf=false&hours=0");
        return jsonRaw;
    }
    /// <summary>
    /// Obtain XML raw text METAR from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String XML coded of station METAR</returns>
    public static async Task<string> GetAirportMetarXmlAsync(string icao)
    {
        string xmlRaw = await Http_GetRequest(URL_METAR + icao + "&format=xml&taf=false&hours=0");
        return xmlRaw;
    }

    /// <summary>
    /// Obtain RAW text TAF from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String containing raw string TAF</returns>
    public static async Task<string> GetAirportTafAsync(string icao)
    {
        return await Http_GetRequest(URL_TAF + icao + "&format=raw&taf=false&hours=0");
    }
    /// <summary>
    /// Obtain JSON raw text TAF from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String JSON coded of station TAF</returns>
    public static async Task<string> GetAirportTafJsonAsync(string icao)
    {
        string jsonRaw = await Http_GetRequest(URL_TAF + icao + "&format=json&taf=false&hours=0");
        return jsonRaw;
    }
    /// <summary>
    /// Obtain XML raw text TAF from ICAO station
    /// </summary>
    /// <param name="icao">ICAO code of station</param>
    /// <returns>String XML coded of station TAF</returns>
    public static async Task<string> GetAirportTafXmlAsync(string icao)
    {
        string xmlRaw = await Http_GetRequest(URL_TAF + icao + "&format=xml&taf=false&hours=0");
        return xmlRaw;
    }

    private static string GetAirportMetar(string icao) { return GetAirportMetarAsync(icao).Result; }
    private static string GetAirportMetarJson(string icao) { return GetAirportMetarJsonAsync(icao).Result; }
    private static string GetAirportMetarXml(string icao) { return GetAirportMetarXmlAsync(icao).Result; }
    private static string GetAirportTaf(string icao) { return GetAirportTafAsync(icao).Result; }
    private static string GetAirportTafJson(string icao) { return GetAirportTafJsonAsync(icao).Result; }
    private static string GetAirportTafXml(string icao) { return GetAirportTafXmlAsync(icao).Result; }

    private static async Task<string> Http_GetRequest(string url)
    {
        var baseAddress = new Uri("https://avwx.rest/api/");

        using (var httpClient = new HttpClient { BaseAddress = baseAddress })
        {
            using (var response = await httpClient.GetAsync(url))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
