using Data.Entities;

namespace Chat
{
    public interface IChatAdapter
    {
        void OnCommandReceived(ChatCommand command);
        bool IsValidCommand(string command, string[] parameters);
        void OnUserJoined(ChatUser user);
        void OnUserLeft(ChatUser user);
    }
}