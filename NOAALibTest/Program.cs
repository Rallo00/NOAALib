using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOAALibTest
{
    internal class Program
    {
        static string ICAO_STATION;
        static void Main(string[] args)
        {

            while (true)
            {
                //////////// TEST PROMPT ////////////
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*****************************************");
                Console.Write("Enter a ICAO station: ");
                Console.ForegroundColor = ConsoleColor.White;
                ICAO_STATION = Console.ReadLine();

                //Getting airport information
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">> METAR RESULT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(NOAALib.GetAirportMetarAsync(ICAO_STATION).Result);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(">> TAF RESULT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(NOAALib.GetAirportTafAsync(ICAO_STATION).Result);

            }

            Console.ReadKey();


        }
    }
}
