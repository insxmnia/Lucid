using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lucid.Classes;
using Pastel;

/*
Lucid Nitro Sniper
-----------
Version: 1.0.0 BETA
Developer: Exodus
-----------
OPEN-SOURCE PROJECT >> GITHUB https://github.com/Exodus-20-2/Lucid
*/

namespace Lucid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console Size Change
            Console.SetWindowSize(95, 38);
            Console.SetBufferSize(95, 1024);

            // Console title change
            Console.Title = $"[Lucid.ʙᴇᴛᴀ] - Preparing Objects...";

            // Main function
            Functions.Banner();
            Console.WriteLine($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Event".Pastel("00AAFF") + "] | Preparing Discord Object ".Pastel("CCDDFC"));
            Classes.Client client = new Classes.Client();
            client._client = new Discord.Gateway.DiscordSocketClient();
            Functions.Banner();
            
            // Checking if config exists
            if (Functions.ConfigCheck())
            {
                Functions.Log(Enums.LogLevel.Event, "Found Config.json, loading saved token and prefix");
                // Console title change
                client._token = Encoding.UTF8.GetString(Convert.FromBase64String(Functions.GetConfigElement("token").ToString()));
                client._prefix = Functions.GetConfigElement("prefix");

                // Calling the banner everytime i need to clear something as it contains the Console.Clear Code
                Functions.Banner();
                Console.Title = $"[Lucid.ʙᴇᴛᴀ] - Connecting...";
                if (client.Run())
                {
                    while (true)
                    {
                        // You can do this or turn the main function into a void and thread it, but im too lazy so ill just do this
                        continue;
                    }
                }

                // If connection to the token fails through the config, ask to input token manually
                Thread.Sleep(3000);
                Functions.Banner();
                client._token = Classes.Functions.Input($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + "] | Discord Token: ".Pastel("CCDDFC"));
                if (client.Run())
                {
                    Functions.CreateConfig(client);
                    while (true)
                    {
                        // You can do this or turn the main function into a void and thread it, but im too lazy so ill just do this
                        continue;
                    }
                }
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            else
            {

                // Console title change
                Console.Title = $"[Lucid.ʙᴇᴛᴀ] - Awaiting Token...";
                client._token = Classes.Functions.Input($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + "] | Discord Token: ".Pastel("CCDDFC"));
                client._prefix = Classes.Functions.Input($"| {DateTime.Now.ToString("HH:mm")} | [".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + "] | Command Prefix: ".Pastel("CCDDFC"));

                // Calling the banner everytime i need to clear something as it contains the Console.Clear Code
                Functions.Banner();
                Console.Title = $"[Lucid.ʙᴇᴛᴀ] - Connecting...";
                if (client.Run())
                {
                    // Create a config to make the sniper auto login, instead of typing in the prefix and token every time
                    Functions.CreateConfig(client);
                    while (true)
                    {
                        // You can do this or turn the main function into a void and thread it, but im too lazy so ill just do this
                        continue;
                    }
                }

                // If connection to the token fails it will pause for 3 seconds and then exit
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            
            


        }
    }
}
