using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lucid.Classes.Enums;
using Pastel;

namespace Lucid.Classes
{
    class Functions
    {
        public static void Log(LogLevel LogLevel, string content)
        {
            switch (LogLevel)
            {
                case LogLevel.Info:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Info".Pastel("B3CCFF") + $"] - {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Error:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Error".Pastel("FF6680") + $"] - {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Event:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Event".Pastel("00AAFF") + $"] - {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Normal:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + $"] - {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Warning:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Warning".Pastel("FFAA00") + $"] - {content}".Pastel("CCDDFC"));
                    break;
                case LogLevel.Critical:
                    Console.WriteLine("[".Pastel("CCDDFC") + "Critical".Pastel("FF2B2B") + $"] - {content}".Pastel("CCDDFC"));
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
            Console.WriteLine();
            Console.WriteLine("                     __" + @"/\\\".Pastel("00AAFF") + "_______________________________________________________" + @"/\\\".Pastel("00AAFF") + "__        ");
            Console.WriteLine("                      _" + @"\/\\\".Pastel("00AAFF") + "______________________________________________________" + @"\/\\\".Pastel("00AAFF") + "__       ");
            Console.WriteLine("                       _" + @"\/\\\".Pastel("00AAFF") + "__________________________________________" + @"/\\\".Pastel("00AAFF") + "________" + @"\/\\\".Pastel("00AAFF") + "__      ");
            Console.WriteLine("                        _" + @"\/\\\".Pastel("00AAFF") + "______________" + @"/\\\".Pastel("00AAFF") + "____" + @"/\\\".Pastel("00AAFF") + "_____" + @"/\\\\\\\\".Pastel("00AAFF") + "_" + @"\///".Pastel("00AAFF") + "_________" + @"\/\\\".Pastel("00AAFF") + "__     ");
            Console.WriteLine("                         _" + @"\/\\\".Pastel("00AAFF") + "_____________" + @"\/\\\".Pastel("00AAFF") + "___" + @"\/\\\".Pastel("00AAFF") + "___" + @"/\\\//////".Pastel("00AAFF") + "___" + @"/\\\".Pastel("00AAFF") + "___" + @"/\\\\\\\\\".Pastel("00AAFF") + "__    ");
            Console.WriteLine("                          _" + @"\/\\\".Pastel("00AAFF") + "_____________" + @"\/\\\".Pastel("00AAFF") + "___" + @"\/\\\".Pastel("00AAFF") + "__" + @"/\\\".Pastel("00AAFF") + "_________" + @"\/\\\".Pastel("00AAFF") + "__" + @"/\\\////\\\".Pastel("00AAFF") + "__   ");
            Console.WriteLine("                           _" + @"\/\\\".Pastel("00AAFF") + "_____________" + @"\/\\\".Pastel("00AAFF") + "___" + @"\/\\\".Pastel("00AAFF") + "_" + @"\//\\\".Pastel("00AAFF") + "________" + @"\/\\\".Pastel("00AAFF") + "_" + @"\/\\\".Pastel("00AAFF") + "__" + @"\/\\\".Pastel("00AAFF") + "__  ");
            Console.WriteLine("                            _" + @"\/\\\\\\\\\\\\\\\".Pastel("00AAFF") + "_" + @"\//\\\\\\\\\".Pastel("00AAFF") + "___" + @"\///\\\\\\\\".Pastel("00AAFF") + "_" + @"\/\\\".Pastel("00AAFF") + "_" + @"\//\\\\\\\/\\".Pastel("00AAFF") + "_ ");
            Console.WriteLine("                             _" + @"\///////////////".Pastel("00AAFF") + "___" + @"\/////////".Pastel("00AAFF") + "______" + @"\////////".Pastel("00AAFF") + "__" + @"\///".Pastel("00AAFF") + "___" + @"\///////\//".Pastel("00AAFF") + "__");
            Console.WriteLine();
            Console.WriteLine("________________________________________________________________________________________________________________________\n");
        }

    }
}
