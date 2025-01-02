
using BigEshop.Domain.Models.Chat;
using Microsoft.AspNetCore.SignalR;

namespace BigEshop.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string name, string text)
        {
            var message = new Chat
            {
                SenderName = name,
                Text = text,
                CreateDate = DateTime.Now
            };

            await Clients.All.SendAsync("ReceiveMessage", message.SenderName, message.CreateDate, message.Text);

        }
    }
}
