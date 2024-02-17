using Microsoft.AspNetCore.SignalR;
using WebSocket.SignalRChat.Common;
using WebSocket.SignalRChat.Interfaces;

namespace WebSocket.SignalRChat.Hubs;

public class LiveChatHub : Hub<ILiveChatHub>, ILiveChatHub
{
    public override async Task OnConnectedAsync() => await Groups.AddToGroupAsync(Context.ConnectionId, Constants.LIVE_CHAT_GROUP);

    public override async Task OnDisconnectedAsync(Exception? exception) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, Constants.LIVE_CHAT_GROUP);

    public async Task OnEnterChatAsync(string userName) => await Clients.Groups(Constants.LIVE_CHAT_GROUP).OnEnterChatAsync(userName);

    public async Task OnExitChatAsync(string userName) => await Clients.OthersInGroup(Constants.LIVE_CHAT_GROUP).OnExitChatAsync(userName);
    
    public async Task OnNewMessageAsync(string userName, string message) => await Clients.OthersInGroup(Constants.LIVE_CHAT_GROUP).OnNewMessageAsync(userName, message);
}