using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSockets;
using Discord;
using Discord.Commands;
using Discord.Gateway;
using Lucid.Classes;
using Newtonsoft.Json;
using Pastel;

namespace Lucid.Commands
{
    [Command("joinguilds")]
    public class joinguilds : CommandBase
    {
        public async override void Execute()
        {
            // Check if the message author is the logged in user
            if (Message.Author.User.Id != Client.User.Id) return;
            // Will continue with the code if thats the case, else it will just return and not do anything
            await Message.DeleteAsync();
            Functions.Log(Enums.LogLevel.Normal, "Command has not beed made yet");
        }
    }

    [Command("setwebhook")]
    public class setwebhook : CommandBase
    {
        public async override void Execute()
        {
            // Check if the message author is the logged in user
            if (Message.Author.User.Id != Client.User.Id) return;
            // Will continue with the code if thats the case, else it will just return and not do anything
            await Message.DeleteAsync();

            // Use a try statement so that the program doesnt crack on any errors.
            try
            {
                // Try to get the URL from message
                string URL = Message.Content.Split(' ')[1];

                // Try getting the webhook information
                string webhook_json = new WebClient().DownloadString(URL);
                dynamic webhook = JsonConvert.DeserializeObject<dynamic>(webhook_json);
                ulong webhook_id = ulong.Parse($"{webhook["id"]}");
                string webhook_token = webhook["token"];
                // Create testing embed
                EmbedMaker embed = new EmbedMaker();
                embed.Title = "✨ Lucid Sniper ✨";
                embed.Description = $"Testing the webhook\nIf this went through your webhook URL will be saved in your `Config.json`\nConfig location: `{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Lucid\\Config.json`";
                embed.Color = Color.FromArgb(77, 166, 255);
                embed.Footer.Text = $"Lucid Sniper | 2021";
                embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";
                // Send the webhook test message
                await Client.SendWebhookMessageAsync(webhook_id, webhook_token, "", embed, new DiscordWebhookProfile() { Username = "Lucid Logs", AvatarUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png" });
                // Add webhook URL to the config or change the current config 
                if(Functions.GetConfigElement("webhook") == "Element doesn't exist")
                {
                    Functions.AddToConfig("webhook", URL);
                    if (Functions.GetConfigElement("webhook_log") == "Element doesn't exist")
                    {
                        Functions.AddToConfig("webhook_log", "true");
                    }
                }
                else if (Functions.GetConfigElement("webhook") != "Element doesn't exist")
                {
                    Functions.UpdateConfigItem("webhook", URL);
                }
                Functions.Log(Enums.LogLevel.Event, "Webhook Log Created");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    [Command("webhooklog")]
    public class webhooklog : CommandBase
    {
        public async override void Execute()
        {
            // Check if the message author is the logged in user
            if (Message.Author.User.Id != Client.User.Id) return;
            // Will continue with the code if thats the case, else it will just return and not do anything
            await Message.DeleteAsync();

            // Use a try statement so that the program doesnt crack on any errors.
            try
            {
                // Try to get the webhook url from config
                if (Functions.GetConfigElement("webhook") == "Element doesn't exist") 
                { 
                    Functions.Log(Enums.LogLevel.Error, "Missing webhook URL from config"); 
                    return; 
                }
                string option = Message.Content.Split(' ')[1];
                if (Functions.GetConfigElement("webhook_log") == "Element doesn't exist")
                {
                    if (option == "on")
                    {
                        Functions.AddToConfig("webhook_log", "true");
                    }
                    else if (option == "off")
                    {
                        Functions.AddToConfig("webhook_log", "false");
                    }
                    else
                    {
                        Functions.Log(Enums.LogLevel.Error, $"Invalid argument '{option.Pastel("CCDDFC")}' passed");
                    }
                }
                else if (Functions.GetConfigElement("webhook_log") != "Element doesn't exist")
                {
                    if (option == "on")
                    {
                        Functions.UpdateConfigItem("webhook_log", "true");
                    }
                    else if (option == "off")
                    {
                        Functions.UpdateConfigItem("webhook_log", "false");
                    }
                    else
                    {
                        Functions.Log(Enums.LogLevel.Error, $"Invalid argument '{option.Pastel("CCDDFC")}' passed");
                    }
                }
                Functions.Log(Enums.LogLevel.Event, $"Webhook logs changed to '{option}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}