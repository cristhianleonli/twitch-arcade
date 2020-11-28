using Data.Entities;

public struct ArcherData
{
    public string Nickname;
    public int Score;
    
    public ArcherData(ChatUser user)
    {
        Nickname = user.Nickname;
        Score = user.Score;
    }
}