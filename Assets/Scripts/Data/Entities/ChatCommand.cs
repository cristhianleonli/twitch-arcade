namespace Data.Entities
{
    public class ChatCommand
    {
        public string Command { get; }
        public string[] Parameters { get; }

        public ChatCommand(string command, string[] parameters)
        {
            Command = command;
            Parameters = parameters;
        }
    }
}