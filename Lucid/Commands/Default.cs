using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Gateway;

namespace Lucid.Commands
{
    [Command("help")]
    public class help : CommandBase
    {
        public override void Execute()
        {
            if(Message.Author.User.Id != Client.User.Id)
            {
                return;
            }
            Message.Delete();

            EmbedMaker embed = new EmbedMaker();
            embed.Title = "✨ Lucid Sniper ✨";
            embed.Description = $"\nPrefix [**{Client.CommandHandler.Prefix}**]\nCommands [**{Client.CommandHandler.Commands.Count}**]\n```\n" +
                $"\n{Client.CommandHandler.Prefix}joinguilds          » Joins a bunch of servers that drop nitro codes" +
                $"\n{Client.CommandHandler.Prefix}setwebhook <url>    » Sets the webhook URL for nitro snipe logs" +
                $"\n{Client.CommandHandler.Prefix}webhooklog <on/off> » Turns on or off the webhook log feature" +
                $"\n```";
            embed.Color = Color.FromArgb(77, 166, 255);
            embed.Footer.Text = $"Lucid Sniper | 2021";
            embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";

            Message.Channel.SendMessage("", false, embed=embed);
        }
    }
}
