using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lucid.Classes;
using Pastel;

namespace Lucid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console title change
            Console.Title = $"[Lucid] - Preparing Objects...";

            // Main function
            Functions.Banner();
            Console.WriteLine($"[".Pastel("CCDDFC") + "Event".Pastel("00AAFF") + "] - Preparing Discord Object ".Pastel("CCDDFC"));
            Classes.Client client = new Classes.Client();
            client._client = new Discord.Gateway.DiscordSocketClient();
            Functions.Banner();

            // Console title change
            Console.Title = $"[Lucid] - Awaiting Token...";
            client._token = Classes.Functions.Input($"[".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + "] - Discord Token: ".Pastel("CCDDFC"));
            client._prefix = Classes.Functions.Input($"[".Pastel("CCDDFC") + "Lucid".Pastel("00AAFF") + "] - Command Prefix: ".Pastel("CCDDFC"));

            // Calling the banner everytime i need to clear something as it contains the Console.Clear Code
            Functions.Banner();
            Console.Title = $"[Lucid] - Connecting...";
            if (client.Run() == true)
            {
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
