using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

public class NOAALib
{
    private static string URL_METAR = "https://aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&stationString=";
    private static string URL_TAF = "https://aviationweather.gov/adds/dataserver_current/httpparam?dataSource=tafs&requestType=retrieve&format=xml&stationString=";
    public static async Task<string> GetAirportMetarRawAsync(string icao)
    {
        return await Http_GetRequest(URL_METAR + icao + "&hoursBeforeNow=1");
    }
    public static async Task<string> GetAirportMetarAsync(string icao)
    {
        string jsonRaw = await Http_GetRequest(URL_METAR + icao + "&hoursBeforeNow=1");
        METAR metar = Newtonsoft.Json.JsonConvert.DeserializeObject<METAR>(jsonRaw);
        return metar.raw_text;
    }
    public static async Task<string> GetAirportTafRawAsync(string icao)
    {
        return await Http_GetRequest(URL_TAF + icao + "&hoursBeforeNow=1");
    }
    public static async Task<string> GetAirportTafAsync(string icao)
    {
        string jsonRaw = await Http_GetRequest(URL_TAF + icao + "&hoursBeforeNow=1");
        METAR metar = Newtonsoft.Json.JsonConvert.DeserializeObject<METAR>(jsonRaw);
        return metar.raw_text;
    }
    private static string GetAirportMetarRaw(string icao) { return GetAirportMetarRawAsync(icao).Result; }
    private static string GetAirportMetar(string icao) { return GetAirportMetarAsync(icao).Result; }
    private static string GetAirportTafRaw(string icao) { return GetAirportTafRawAsync(icao).Result; }
    private static string GetAirportTaf(string icao) { return GetAirportTafAsync(icao).Result; }

    private static async Task<string> Http_GetRequest(string url)
    {
        var baseAddress = new Uri("https://avwx.rest/api/");

        using (var httpClient = new HttpClient { BaseAddress = baseAddress })
        {
            using (var response = await httpClient.GetAsync(url))
            {
                string xmlRaw = await response.Content.ReadAsStringAsync();
                //Converting XML to JSON
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlRaw);
                string jsonRaw = JsonConvert.SerializeXmlNode(doc);
                //Cleaning up useless xml data
                jsonRaw = "{" + jsonRaw.Substring(jsonRaw.IndexOf("\"raw_text\":\""));
                string[] results = jsonRaw.Split(',');
                jsonRaw = results[0] + "}";
                return jsonRaw;
            }
        }
    }

    public struct METAR
    {
        public string raw_text;
    }
}
