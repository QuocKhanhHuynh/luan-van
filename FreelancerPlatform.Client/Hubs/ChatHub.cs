﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    // Phương thức gửi tin nhắn đến một người dùng cụ thể
    public async Task SendMessageToUser(string userId, string hubChatId, string message)
    {
        await Clients.User(userId).SendAsync("ReceiveMessage", userId, hubChatId, message, DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
       
    }

    public async Task SendMessage(string message)
    {
        //await Clients.User(userId).SendAsync("ReceiveMessage", message);s
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}



/*public override Task OnConnectedAsync()
{
    string userId = Context.UserIdentifier; // Lấy UserId từ context
    Groups.AddToGroupAsync(Context.ConnectionId, userId); // Thêm vào nhóm người dùng
    return base.OnConnectedAsync();
}*/