
using BigEshop.Domain.Models.Chat;
using Microsoft.AspNetCore.SignalR;

namespace BigEshop.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SendAt = DateTimeOffset.Now,
            };

            await Clients.All.SendAsync("ReceiveMessage", message.SenderName, message.SendAt, message.Text);

        }
    }
}
