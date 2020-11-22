namespace Chat
{
    public interface ICredentials
    {
        string GetUsername();
        string GetToken();
        string GetChannelName();
    }
}
