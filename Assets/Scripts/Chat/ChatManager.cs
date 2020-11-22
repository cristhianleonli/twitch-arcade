using Data;
using Data.Entities;
using TwitchChatConnect.Client;
using TwitchChatConnect.Config;
using TwitchChatConnect.Data;
using UnityEngine;

namespace Chat
{
    public class ChatManager : MonoBehaviour
    {
        public static ChatManager Instance { get; private set; }

        public IChatAdapter adapter;
        private readonly UserManager _userManager = UserManager.Instance;
        private readonly DataManager _dataManager = DataManager.Instance;

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
            var username = _dataManager.GetUsername();
            var token = _dataManager.GetToken();
            var channel = _dataManager.GetChannelName();

            if (username == null || token == null || channel == null) return;

            var config = new TwitchConnectConfig(username, token, channel);
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

        private void ShowCommand(TwitchChatCommand chatCommand)
        {
            var command = new ChatCommand(chatCommand.Command, chatCommand.Parameters);
            var user = new ChatUser(chatCommand.User.DisplayName);

            if (adapter == null) return;

            if (IsJoinCommand(command))
            {
                _userManager.AddUser(user);
                adapter.OnUserJoined(user);
                return;
            }

            if (IsLeaveCommand(command))
            {
                _userManager.RemoveUser(user);
                adapter.OnUserLeft(user);
                return;
            }

            if (adapter.IsValidCommand(command.Command, command.Parameters))
            {
                adapter.OnCommandReceived(command);
            }
        }

        private void ShowReward(TwitchChatReward chatReward)
        {
        }

        private void ShowMessage(TwitchChatMessage chatMessage)
        {
        }

        private bool IsJoinCommand(ChatCommand command)
        {
            if (command.Command != _dataManager.GetCommandPrefix()) return false;
            if (command.Parameters.Length != 1) return false;

            return command.Parameters[0] == "join";
        }

        private bool IsLeaveCommand(ChatCommand command)
        {
            if (command.Command != _dataManager.GetCommandPrefix()) return false;
            if (command.Parameters.Length != 1) return false;

            return command.Parameters[0] == "leave";
        }
    }
}
