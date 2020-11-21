using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChatAdapter
{
    void OnCommandReceived(ChatCommand command);
    bool IsValidCommand(string command, string[] parameters);
    void OnUserJoined(ChatUser user);
    void OnUserLeft(ChatUser user);
}