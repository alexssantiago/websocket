namespace WebSocket.SignalRChat.Interfaces;

public interface ILiveChatHub
{
    Task OnEnterChatAsync(string userName);
    Task OnExitChatAsync(string userName);
    Task OnNewMessageAsync(string userName, string message);
}