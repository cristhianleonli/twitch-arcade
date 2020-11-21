using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatCommand
{
    public string Command { get; }
    public string[] Parameters { get; }

    public ChatCommand(string command, string[] parameters)
    {
        Command = command.ToLower();
        Parameters = parameters;
    }
}