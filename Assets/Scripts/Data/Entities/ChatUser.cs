using System;

namespace Data.Entities
{
    public enum Ranking
    {
        Iron,
        Bronze,
        Silver,
        Gold,
        Platinum,
        Diamond
    }

    public class ChatUser
    {
        public int Id { get; }
        public string Nickname { get; }
        public int Score { get; }
        public string CreatedAt { get; }


        public ChatUser(int id, string nickName, int score, string createdAt)
        {
            Id = id;
            Nickname = nickName;
            Score = score;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"[{Id}, {Nickname}, {Score}]";
        }

        public Ranking GetRanking()
        {
            // FIXME: Check ranking logic
            if (Score < 10) return Ranking.Iron;
            if (Score < 20) return Ranking.Iron;
            if (Score < 30) return Ranking.Iron;
            if (Score < 40) return Ranking.Iron;
            if (Score < 50) return Ranking.Iron;
            return Ranking.Diamond;
        }
    }
}