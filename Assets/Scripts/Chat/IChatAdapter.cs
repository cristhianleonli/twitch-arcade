using Data.Entities;

namespace Chat
{
    public interface IChatAdapter
    {
        void OnCommandReceived(ChatCommand command);
        bool IsValidCommand(string command, string[] parameters);
    }
}