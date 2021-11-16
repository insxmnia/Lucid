using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Pastel;

namespace Lucid.Classes
{
    class Handlers
    {
        public static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Functions.Banner();
            Console.Title = $"[Lucid] - User: {client.User.Username}  Guilds: {client.GetGuilds().Count}";
            Functions.Log(Enums.LogLevel.Event, $"Connected To {client.User.Username.Pastel("CC99FF")}#{client.User.Discriminator.ToString().Pastel("CC99FF")}");
        }
        public static void OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            #region Local Variables
            var message = args.Message;
            var author = message.Author;
            #endregion

        }
    }
}
