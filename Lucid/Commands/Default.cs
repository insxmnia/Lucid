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
        public async override void Execute()
        {
            // Check if the message author is the logged in user
            if(Message.Author.User.Id != Client.User.Id) return;
            // Will continue with the code if thats the case, else it will just return and not do anything
            await Message.DeleteAsync();

            // Create message embed
            EmbedMaker message_embed = new EmbedMaker();
            message_embed.Title = "✨ Lucid Sniper ✨";
            message_embed.Description = $"\nPrefix [**{Client.CommandHandler.Prefix}**]\nCommands [**{Client.CommandHandler.Commands.Count}**]\n```\n" +
                $"\n{Client.CommandHandler.Prefix}joinguilds          » Joins a bunch of servers that drop nitro codes" +
                $"\n{Client.CommandHandler.Prefix}setwebhook <url>    » Sets the webhook URL for nitro snipe logs" +
                $"\n{Client.CommandHandler.Prefix}webhooklog <on/off> » Turns on or off the webhook log feature" +
                $"\n```";
            message_embed.Color = Color.FromArgb(77, 166, 255);
            message_embed.Footer.Text = $"Lucid Sniper | 2021";
            message_embed.Footer.IconUrl = "https://user-images.githubusercontent.com/73559155/141868864-948c59fa-8f2b-49d7-a7ff-5ae837496f93.png";

            // Send the message as an embed
            await Message.Channel.SendMessageAsync("", false, message_embed);
        }
    }
}
