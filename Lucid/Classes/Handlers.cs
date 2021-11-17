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
        private static List<string> codes = new List<string>();
        private static int sniped = 0;
        public static void OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Functions.Banner();
            Console.Title = $"[Lucid.ʙᴇᴛᴀ] - User: {client.User.Username}  Guilds: {client.GetGuilds().Count}  Sniped: 0";
            Functions.Log(Enums.LogLevel.Event, $"Connected To {client.User.Username.Pastel("CC99FF")}#{client.User.Discriminator.ToString().Pastel("CC99FF")}");
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
                if (content.StartsWith("https://discord.gift/") || content.StartsWith("discord.gift/"))
                {
                    sniped++;
                    Console.Title = Console.Title.Replace($"Sniped: {sniped - 1}", $"Sniped: {sniped}");
                    snipe_time.Start();
                    var code = content.Replace("https://", "").Split('/')[1];
                    if (codes.Contains(code))
                    {
                        Console.WriteLine();
                        snipe_time.Stop();
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
                            snipe_time.Stop();
                            try
                            {
                                redeem_time.Start();
                                client.RedeemGift(code);
                                redeem_time.Stop();
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator}");
                                Functions.Log(Enums.LogLevel.Event, $"Owner:".Pastel("00AAFF") + $" {client.GetGift(code).Gifter.Username}#{client.GetGift(code).Gifter.Discriminator}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {client.GetGuild(message.Guild.Id).Name}");
                                }
                                else
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator} DMs");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {client.GetGift(code).SubscriptionPlan.Name}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {snipe_time.Elapsed.TotalMilliseconds}ms");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms");
                            }
                            catch
                            {
                                redeem_time.Stop();
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator}");
                                if (client.GetChannel(message.Channel.Id).Type != ChannelType.DM)
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {client.GetGuild(message.Guild.Id).Name}");
                                }
                                else
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator} DMs");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" Unkown{"/".Pastel("CCDDFC")}Already Redeemed{"/".Pastel("CCDDFC")}Fake Code");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {snipe_time.Elapsed.TotalMilliseconds}ms");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms");
                            }

                            return;
                        }
                        Console.WriteLine();
                        snipe_time.Stop();
                        Functions.Log(Enums.LogLevel.Event, "Detected Fake Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }

                }
                else if (content.StartsWith("https://discord.com/gifts/") || content.StartsWith("discord.com/gifts/"))
                {
                    sniped++;
                    Console.Title = Console.Title.Replace($"Sniped: {sniped - 1}", $"Sniped: {sniped}");
                    snipe_time.Start();
                    var code = content.Replace("https://", "").Split('/')[2];
                    if (codes.Contains(code))
                    {
                        Console.WriteLine();
                        snipe_time.Stop();
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
                            snipe_time.Stop();
                            try
                            {
                                redeem_time.Start();
                                client.RedeemGift(code);
                                redeem_time.Stop();
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator}");
                                Functions.Log(Enums.LogLevel.Event, $"Owner:".Pastel("00AAFF") + $" {client.GetGift(code).Gifter.Username}#{client.GetGift(code).Gifter.Discriminator}");
                                try
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {client.GetGuild(message.Guild.Id).Name}");
                                }
                                catch
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator} DMs");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" {client.GetGift(code).SubscriptionPlan.Name}");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {snipe_time.Elapsed.TotalMilliseconds}ms");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms");
                            }
                            catch
                            {
                                redeem_time.Stop();
                                Functions.Log(Enums.LogLevel.Event, $"{"Nitro Sniped".Pastel("00AAFF")}!".Pastel("CCDDFC"));
                                Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("00AAFF") + $" {code}");
                                Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator}");
                                try
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {client.GetGuild(message.Guild.Id).Name}");
                                }
                                catch
                                {
                                    Functions.Log(Enums.LogLevel.Event, $"Server:".Pastel("00AAFF") + $" {author.User.Username}#{author.User.Discriminator} DMs");
                                }
                                Functions.Log(Enums.LogLevel.Event, $"Type:".Pastel("00AAFF") + $" Unkown{"/".Pastel("CCDDFC")}Already Redeemed{"/".Pastel("CCDDFC")}Fake Code");
                                Functions.Log(Enums.LogLevel.Event, $"Snipe Time:".Pastel("00AAFF") + $" {snipe_time.Elapsed.TotalMilliseconds}ms");
                                Functions.Log(Enums.LogLevel.Event, $"Redeem Time:".Pastel("00AAFF") + $" {redeem_time.Elapsed.TotalMilliseconds.ToString().Split('.')[0]}ms");
                            }

                            return;
                        }
                        Console.WriteLine();
                        snipe_time.Stop();
                        Functions.Log(Enums.LogLevel.Event, "Detected Fake Nitro Code!".Pastel("FF6680"));
                        Functions.Log(Enums.LogLevel.Event, $"Sender:".Pastel("FF6680") + $" {author.User.Username}#{author.User.Discriminator}");
                        Functions.Log(Enums.LogLevel.Event, $"Code:".Pastel("FF6680") + $" {code}");
                    }
                }
            }


        }
    }
}
