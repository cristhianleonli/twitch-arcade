﻿using TwitchChatConnect.Client;
using TwitchChatConnect.Data;
using TwitchChatConnect.Config;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance { get; private set; }

    public IChatAdapter adapter;
    private readonly UserManager userManager = UserManager.Instance;
    private readonly DataManager dataManager = DataManager.Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        TwitchConnectConfig config = new TwitchConnectConfig(
            dataManager.GetUsername(),
            dataManager.GetToken(),
            dataManager.GetChannelName()
            );

        TwitchChatClient.instance.Init(
            config,
            () =>
            {
                TwitchChatClient.instance.onChatMessageReceived += ShowMessage;
                TwitchChatClient.instance.onChatCommandReceived += ShowCommand;
                TwitchChatClient.instance.onChatRewardReceived += ShowReward;
            },
            message =>
            {
                Debug.Log(message);
            });
    }

    void ShowCommand​(TwitchChatCommand chatCommand)
    {
        ChatCommand command = new ChatCommand(chatCommand.Command, chatCommand.Parameters);
        ChatUser user = new ChatUser(chatCommand.User.DisplayName);

        if (adapter == null) { return; }

        if (IsJoinCommand(command))
        {
            // TODO: check if this user has ever been persisted
            // if not, save the user as a new entry
            userManager.AddUser(user);
            adapter.OnUserJoined(user);
            return;
        }

        if (IsLeaveCommand(command))
        {
            userManager.RemoveUser(user);
            adapter.OnUserLeft(user);
            return;
        }

        if (adapter.IsValidCommand(command.Command, command.Parameters))
        {
            adapter.OnCommandReceived(command);
        }
    }

    void ShowReward​(TwitchChatReward chatReward)
    {
    }

    void ShowMessage​(TwitchChatMessage chatMessage)
    {
    }

    private bool IsJoinCommand(ChatCommand command)
    {
        return command.Command == "!join" && command.Parameters.Length == 0;
    }

    private bool IsLeaveCommand(ChatCommand command)
    {
        return command.Command == "!leave" && command.Parameters.Length == 0;
    }
}
