using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Pastel;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using System.Drawing;

namespace Lucid.Classes
{
    class Handlers
    {
        private static List<string> codes = new List<string>();
        private static int sniped = 0;
        public static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Functions.Banner();
            Console.Title = $"[Lucid.ʙᴇᴛᴀ] - User: {client.User.Username}  Guilds: {client.GetGuilds().Count}  Sniped: 0";
            Functions.Log(Enums.LogLevel.Event, $"Connected To {client.User.Username.Pastel("CC99FF")}#{client.User.Discriminator.ToString().Pastel("CC99FF")}");
            Functions.Log(Enums.LogLevel.Event, $"Prefix [{client.CommandHandler.Prefix.Pastel("CC99FF")}]");
        }
        public static void OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            #region Local Variables
            var message = args.Message;
            var author = message.Author;
            var content = message.Content;

            var snipe_time = new Stopwatch();
            var redeem_time = new Stopwatch();
            #endregion
            if (author.User.Id != client.User.Id) 
            {
                snipe_time.Start();
                if (content.StartsWith("https://discord.gift/") || content.StartsWith("discord.gift/") || content.StartsWith("Discord.gift/"))
                {
                    snipe_time.Stop();
                    sniped++;
                    Console.Title = Console.Title.Replace($"Sniped: {sniped - 1}", $"Sniped: {sniped}");
                    var code = content.Replace("https://", "").Split('/')[1];
                    if (codes.Contains(code))
                    {
                        Console.WriteLine();
                        
                        Functions.Log(Enums.LogLevel.Event, "Detected Duplicate Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }
                    else
                    {
                        
                        codes.Add(code);
                        if (code.Length == 16)
                        {
                            Console.WriteLine();
                            try
                            {
                                redeem_time.Start();
                                client.RedeemGift(code);
                                redeem_time.Stop();
                                string Sender = $"{author.User.Username}#{author.User.Discriminator}";
                                string Owner = $"{client.GetGift(code).Gifter.Username}#{client.GetGift(code).Gifter.Discriminator}";
                                string Server = string.Empty;
                                string Type = $"{client.GetGift(code).SubscriptionPlan.Name}";
                                string SnipeTime = $"{snipe_time.Elapsed.TotalMilliseconds}ms";
                                string RedeemTime = $"{redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms";
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {Sender}");
                                Functions.Log(Enums.LogLevel.Event, $"Owner:".Pastel("00AAFF") + $" {Owner}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Server = $" {client.GetGuild(message.Guild.Id).Name}";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                else
                                {
                                    Server = $" {author.User.Username}#{author.User.Discriminator} DMs";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {Type}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {SnipeTime}");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {RedeemTime}");
                                if (Functions.GetConfigElement("webhook_log") != "Element doesn't exist" && Functions.GetConfigElement("webhook_log") == "true") 
                                {
                                    
                                    try
                                    {
                                        string webhook_json = new WebClient().DownloadString($"{Functions.GetConfigElement("webhook")}");
                                        
                                        dynamic webhook = JsonConvert.DeserializeObject<dynamic>(webhook_json);
                                        ulong webhook_id = ulong.Parse($"{webhook["id"]}");
                                        string webhook_token = webhook["token"];
                                        // Create nitro embed
                                        EmbedMaker embed = new EmbedMaker();
                                        embed.Title = "✨ Lucid Sniper ✨";
                                        embed.Description = $"__**Nitro Sniped**__" + 
                                            $"\nCode: `{code}`" + 
                                            $"\nSender: `{Sender}`" + 
                                            $"\nOwner: `{Owner}`" +
                                            $"\nServer: `{Server}`" +
                                            $"\nType: `{Type}`" +
                                            $"\nSnipe Time: `{SnipeTime}`" +
                                            $"\nRedeem Time: `{RedeemTime}`";
                                        embed.Color = Color.FromArgb(77, 166, 255);
                                        embed.Footer.Text = $"Lucid Sniper | 2021";
                                        embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";
                                        // Send the webhook message
                                        client.SendWebhookMessage(webhook_id, webhook_token, "", embed, new DiscordWebhookProfile() { Username = "Lucid Logs", AvatarUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png" });
                                    }
                                    catch (Exception ex) { Functions.Log(Enums.LogLevel.Error, "Failed to send webhook log: " + ex.Message); }
                                }
                            }
                            catch
                            {
                                redeem_time.Stop();
                                string Sender = $"{author.User.Username}#{author.User.Discriminator}";
                                string Server = string.Empty;
                                string Type = $"Unkown{"/".Pastel("CCDDFC")}Already Redeemed{"/".Pastel("CCDDFC")}Fake Code";
                                string WebhookType = $"Unkown/Already Redeemed/Fake Code";
                                string SnipeTime = $"{snipe_time.Elapsed.TotalMilliseconds}ms";
                                string RedeemTime = $"{redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms";
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {Sender}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Server = $" {client.GetGuild(message.Guild.Id).Name}";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                else
                                {
                                    Server = $" {author.User.Username}#{author.User.Discriminator} DMs";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {Type}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {SnipeTime}");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {RedeemTime}");
                                if (Functions.GetConfigElement("webhook_log") != "Element doesn't exist" && Functions.GetConfigElement("webhook_log") == "true")
                                {
                                    
                                    try
                                    {
                                        string webhook_json = new WebClient().DownloadString($"{Functions.GetConfigElement("webhook")}");
                                        
                                        dynamic webhook = JsonConvert.DeserializeObject<dynamic>(webhook_json);
                                        ulong webhook_id = ulong.Parse($"{webhook["id"]}");
                                        string webhook_token = webhook["token"];
                                        // Create nitro 
                                        EmbedMaker embed = new EmbedMaker();
                                        embed.Title = "✨ Lucid Sniper ✨";
                                        embed.Description = $"__**Nitro Sniped**__" +
                                            $"\nCode: `{code}`" +
                                            $"\nSender: `{Sender}`" +
                                            $"\nServer: `{Server}`" +
                                            $"\nType: `{WebhookType}`" +
                                            $"\nSnipe Time: `{SnipeTime}`" +
                                            $"\nRedeem Time: `{RedeemTime}`";
                                        embed.Color = Color.FromArgb(77, 166, 255);
                                        embed.Footer.Text = $"Lucid Sniper | 2021";
                                        embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";
                                        // Send the webhook message
                                        client.SendWebhookMessage(webhook_id, webhook_token, "", embed, new DiscordWebhookProfile() { Username = "Lucid Logs", AvatarUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png" });
                                    }
                                    catch (Exception ex) { Functions.Log(Enums.LogLevel.Error, "Failed to send webhook log: " + ex.Message); }
                                }
                            }

                            return;
                        }
                        Console.WriteLine();
                        Functions.Log(Enums.LogLevel.Event, "Detected Fake Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }

                }
                else if (content.StartsWith("https://discord.com/gifts/") || content.StartsWith("discord.com/gifts/") || content.StartsWith("Discord.com/gifts/"))
                {
                    snipe_time.Stop();
                    sniped++;
                    Console.Title = Console.Title.Replace($"Sniped: {sniped - 1}", $"Sniped: {sniped}");
                    var code = content.Replace("https://", "").Split('/')[2];
                    if (codes.Contains(code))
                    {
                        Console.WriteLine();
                        
                        Functions.Log(Enums.LogLevel.Event, "Detected Duplicate Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }
                    else
                    {
                        
                        codes.Add(code);
                        
                        if (code.Length == 16)
                        {
                            Console.WriteLine();
                            try
                            {
                                redeem_time.Start();
                                client.RedeemGift(code);
                                redeem_time.Stop();
                                string Sender = $"{author.User.Username}#{author.User.Discriminator}";
                                string Owner = $"{client.GetGift(code).Gifter.Username}#{client.GetGift(code).Gifter.Discriminator}";
                                string Server = string.Empty;
                                string Type = $"{client.GetGift(code).SubscriptionPlan.Name}";
                                string SnipeTime = $"{snipe_time.Elapsed.TotalMilliseconds}ms";
                                string RedeemTime = $"{redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms";
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {Sender}");
                                Functions.Log(Enums.LogLevel.Event, $"Owner:".Pastel("00AAFF") + $" {Owner}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Server = $" {client.GetGuild(message.Guild.Id).Name}";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                else
                                {
                                    Server = $" {author.User.Username}#{author.User.Discriminator} DMs";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {Type}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {SnipeTime}");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {RedeemTime}");
                                if (Functions.GetConfigElement("webhook_log") != "Element doesn't exist" && Functions.GetConfigElement("webhook_log") == "true")
                                {
                                    
                                    try
                                    {
                                        Console.WriteLine(Functions.GetConfigElement("webhook"));
                                        string webhook_json = new WebClient().DownloadString($"{Functions.GetConfigElement("webhook")}");
                                        
                                        dynamic webhook = JsonConvert.DeserializeObject<dynamic>(webhook_json);
                                        ulong webhook_id = ulong.Parse($"{webhook["id"]}");
                                        string webhook_token = webhook["token"];
                                        // Create nitro embed
                                        EmbedMaker embed = new EmbedMaker();
                                        embed.Title = "✨ Lucid Sniper ✨";
                                        embed.Description = $"__**Nitro Sniped**__" +
                                            $"\nCode: `{code}`" +
                                            $"\nSender: `{Sender}`" +
                                            $"\nOwner: `{Owner}`" +
                                            $"\nServer: `{Server}`" +
                                            $"\nType: `{Type}`" +
                                            $"\nSnipe Time: `{SnipeTime}`" +
                                            $"\nRedeem Time: `{RedeemTime}`";
                                        embed.Color = Color.FromArgb(77, 166, 255);
                                        embed.Footer.Text = $"Lucid Sniper | 2021";
                                        embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";
                                        // Send the webhook message
                                        client.SendWebhookMessage(webhook_id, webhook_token, "", embed, new DiscordWebhookProfile() { Username = "Lucid Logs", AvatarUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png" });
                                    }
                                    catch (Exception ex) { Functions.Log(Enums.LogLevel.Error, "Failed to send webhook log: " + ex.Message); }
                                }
                            }
                            catch
                            {
                                redeem_time.Stop();
                                string Sender = $"{author.User.Username}#{author.User.Discriminator}";
                                string Server = string.Empty;
                                string Type = $"Unkown{"/".Pastel("CCDDFC")}Already Redeemed{"/".Pastel("CCDDFC")}Fake Code";
                                string WebhookType = $"Unkown/Already Redeemed/Fake Code";
                                string SnipeTime = $"{snipe_time.Elapsed.TotalMilliseconds}ms";
                                string RedeemTime = $"{redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms";
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {Sender}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Server = $" {client.GetGuild(message.Guild.Id).Name}";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                else
                                {
                                    Server = $" {author.User.Username}#{author.User.Discriminator} DMs";
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {Server}");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {Type}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {SnipeTime}");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {RedeemTime}");
                                if (Functions.GetConfigElement("webhook_log") != "Element doesn't exist" && Functions.GetConfigElement("webhook_log").ToString() == "true")
                                {  
                                    try
                                    {
                                        string webhook_json = new WebClient().DownloadString($"{Functions.GetConfigElement("webhook")}");
                                        
                                        dynamic webhook = JsonConvert.DeserializeObject<dynamic>(webhook_json);
                                        ulong webhook_id = ulong.Parse($"{webhook["id"]}");
                                        string webhook_token = webhook["token"];
                                        // Create nitro embed 
                                        EmbedMaker embed = new EmbedMaker();
                                        embed.Title = "✨ Lucid Sniper ✨";
                                        embed.Description = $"__**Nitro Sniped**__" +
                                            $"\nCode: `{code}`" +
                                            $"\nSender: `{Sender}`" +
                                            $"\nServer: `{Server}`" +
                                            $"\nType: `{WebhookType}`" +
                                            $"\nSnipe Time: `{SnipeTime}`" +
                                            $"\nRedeem Time: `{RedeemTime}`";
                                        embed.Color = Color.FromArgb(77, 166, 255);
                                        embed.Footer.Text = $"Lucid Sniper | 2021";
                                        embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";
                                        // Send the webhook message
                                        client.SendWebhookMessage(webhook_id, webhook_token, "", embed, new DiscordWebhookProfile() { Username = "Lucid Logs", AvatarUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png" });
                                    }
                                    catch (Exception ex) { Functions.Log(Enums.LogLevel.Error, "Failed to send webhook log: " + ex.Message); }
                                }
                            }

                            return;
                        }
                        Console.WriteLine();
                        Functions.Log(Enums.LogLevel.Event, "Detected Fake Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }
                }
            }


        }
    }
}
