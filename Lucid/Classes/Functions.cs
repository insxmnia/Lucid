using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucid.Classes.Enums;
using Pastel;
using System.IO;

namespace Lucid.Classes
{
    class Functions
    {
        public static void Log(LogLevel LogLevel, string content)
        {
            switch (LogLevel)
            {
                case LogLevel.Info:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH: mm")} |  [".Pastel("CCDDFC") + "Info".Pastel("B3CCFF") + $"]   |  {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Error:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} |  [".Pastel("CCDDFC") + "Error".Pastel("FF6680") + $"]   | {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Event:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} |  [".Pastel("CCDDFC") + "Event".Pastel("00AAFF") + $"]   | {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Normal:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} |  [".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + $"]   | {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Warning:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Warning".Pastel("FFAA00") + $"]  | {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Critical:
                    Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Critical".Pastel("FF2B2B") + $"] | {content}".Pastel("CCDDFC"));
                    break;
            }
        }

        public static string Input(string content)
        {
            Console.Write(content);
            return Console.ReadLine();
        }

        public static void Banner()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"                       /" + "$$      ".Pastel("00AAFF") + " /" + "$$".Pastel("00AAFF") + "   /" + "$$".Pastel("00AAFF") + "  /" + "$$$$$$".Pastel("00AAFF") + "  /" + "$$$$$$".Pastel("00AAFF") + " /" + "$$$$$$$".Pastel("00AAFF") + "          ");
            Console.WriteLine($"                      | " + "$$      ".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + " /" + "$$".Pastel("00AAFF") + "__  $$".Pastel("00AAFF") + "|_  " + "$$".Pastel("00AAFF") + "_/| " + "$$".Pastel("00AAFF") + "__  " + "$$         ".Pastel("00AAFF"));
            Console.WriteLine($"                      | " + "$$      ".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + @"  \__/  | " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + @"  \ " + "$$         ".Pastel("00AAFF"));
            Console.WriteLine($"                      | " + "$$      ".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "        | " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "  | " + "$$         ".Pastel("00AAFF"));
            Console.WriteLine($"                      | " + "$$      ".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "        | " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "  | " + "$$         ".Pastel("00AAFF"));
            Console.WriteLine($"                      | " + "$$      ".Pastel("00AAFF") + "| " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "| " + "$$    $$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "  | " + "$$".Pastel("00AAFF") + "  | " + "$$         ".Pastel("00AAFF"));
            Console.WriteLine($"                      | " + "$$$$$$$$".Pastel("00AAFF") + "| " + " $$$$$$".Pastel("00AAFF") + "/|  " + "$$$$$$".Pastel("00AAFF") + "/ /" + "$$$$$$".Pastel("00AAFF") + "| " + "$$$$$$$".Pastel("00AAFF") + "/         ");
            Console.WriteLine($@"                      |________/ \______/  \______/ |______/|_______/          ");
            Console.WriteLine($"");
            Console.WriteLine($"               ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine($"                ,.-'`".Pastel("CCDDFC") + "*".Pastel("ADC2ED") + " Snipe Nitro Codes At Lightning Speeds With Lucid".Pastel("00AAFF") + " *".Pastel("ADC2ED") + "`'-., ".Pastel("CCDDFC"));
            Console.WriteLine($"");
            Console.WriteLine(",.-`'═════════════════════════════════════════════════════════════════════════════════════'`-.,\n");
        }

        public static void CreateConfig(Client client)
        {
            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Lucid\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string config_data = "{\n    " + $"'token': '{Convert.ToBase64String(Encoding.UTF8.GetBytes(client._token))}',\n    'prefix': '{client._prefix}'" + "\n}";
            FileStream file = File.Create(path + "Config.json");
            byte[] encoded_data = Encoding.UTF8.GetBytes(config_data);
            file.Write(encoded_data, 0, encoded_data.Length);
            file.Close();
        }

    }
}
