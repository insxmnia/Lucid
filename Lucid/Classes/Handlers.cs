using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Pastel;
using System.Diagnostics;

namespace Lucid.Classes
{
    class Handlers
    {
        private static List<string> NitroCodes = new List<string>();
        public static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Functions.Banner();
            Console.Title = $"[Lucid.ʙᴇᴛᴀ] - User: {client.User.Username}  Guilds: {client.GetGuilds().Count}";
            Functions.Log(Enums.LogLevel.Event, $"Connected To {client.User.Username.Pastel("CC99FF")}#{client.User.Discriminator.ToString().Pastel("CC99FF")}");
        }
        public static void OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            #region Local Variables
            var message = args.Message;
            var author = message.Author;
            var content = message.Content;

            var snipe_time = new Stopwatch();
            #endregion
            if (author.User.Id == client.User.Id) 
            {
                if (content.StartsWith("https://discord.gift/") || content.StartsWith("discord.gift/"))
                {
                    snipe_time.Start();
                    var code = content.Replace("https://", "").Split('/')[1];
                    if(code.Length == 16)
                    {
                        snipe_time.Stop();
                        Functions.Log(Enums.LogLevel.Event, $"Code: {code}, Elapsed: {snipe_time.Elapsed.TotalMilliseconds}ms");
                        return;
                    }
                    Functions.Log(Enums.LogLevel.Event, "Fake Nitro Code Sent");

                }
                else if (content.StartsWith("https://discord.com/gifts/") || content.StartsWith("discord.com/gifts/"))
                {
                    snipe_time.Start();
                    var code = content.Replace("https://", "").Split('/')[2];
                    if (code.Length == 16)
                    {
                        snipe_time.Stop();
                        Functions.Log(Enums.LogLevel.Event, $"Code: {code}, Elapsed: {snipe_time.Elapsed.TotalMilliseconds}ms");
                        return;
                    }
                    Functions.Log(Enums.LogLevel.Event, "Fake Nitro Code Sent");
                }
            }


        }
    }
}
