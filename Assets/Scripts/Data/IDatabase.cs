using System.Collections.Generic;
using Data.Entities;

namespace Data
{
    public interface IDatabase
    {
        ChatUser FetchUser(string nickname);
        List<ChatUser> FetchAllUsers();
        bool UserExists(string nickname);

        void CreateUser(string nickname, string datetime);
    }
}
