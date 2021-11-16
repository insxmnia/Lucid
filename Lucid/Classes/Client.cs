using System;
using Discord;
using System.Linq;
using System.Text;
using Discord.Gateway;
using Discord.Commands;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pastel;


namespace Lucid.Classes
{
    public class Client
    {
        public DiscordSocketClient _client { get; set; }
        public string _token { get; set; }
        public string _prefix { get; set; }

        public bool Run()
        {
            try
            {
                // Attempt to login into the given token
                _client.Login(_token);
                // Attempting to create nessesary handlers
                _client.CreateCommandHandler(_prefix);
                Functions.Log(Enums.LogLevel.Event, "Command Handler Created");
                _client.OnLoggedIn += Handlers.OnLoggedIn;
                Functions.Log(Enums.LogLevel.Event, "Client Handler Created");
                _client.OnMessageReceived += Handlers.OnMessageReceived;
                Functions.Log(Enums.LogLevel.Event, "Message Handler Created");
                return true;
            }
            catch (Exception ex) { Functions.Log(Enums.LogLevel.Error, ex.Message); return false; }

        }

    }
}
