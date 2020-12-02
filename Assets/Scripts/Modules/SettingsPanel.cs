using System.Linq;
using System.Text.RegularExpressions;
using Chat;
using Data;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public InputField tokenField;
    public InputField channelNameField;
    public InputField usernameField;
    public InputField commandPrefixField;
    public Button saveButton;

    // New data to save to player preferences
    private string _token;
    private string _username;
    private string _channelName;
    private string _commandPrefix;
    private int _musicLevel;
    private int _effectsLevel;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        SetupSliders();
        PrefillData();
        AddObservers();
    }

    private void SetupSliders()
    {
        musicSlider.maxValue = 10;
        musicSlider.minValue = 0;
        musicSlider.wholeNumbers = true;

        sfxSlider.maxValue = 10;
        sfxSlider.minValue = 0;
        sfxSlider.wholeNumbers = true;
    }

    private void PrefillData()
    {
        tokenField.text = PreferenceService.Token;
        usernameField.text = PreferenceService.Username;
        channelNameField.text = PreferenceService.ChannelName;
        commandPrefixField.text = PreferenceService.CommandPrefix;

        _token = PreferenceService.Token;
        _username = PreferenceService.Username;
        _channelName = PreferenceService.ChannelName;
        _commandPrefix = PreferenceService.CommandPrefix;

        musicSlider.value = PreferenceService.MusicLevel;
        sfxSlider.value = PreferenceService.EffectsLevel;
    }

    private void AddObservers()
    {
        musicSlider.onValueChanged.AddListener(
            (value) => {
                _musicLevel = (int) value;
            });
        
        sfxSlider.onValueChanged.AddListener(
            (value) =>
            {
                _effectsLevel = (int) value;
                _audioManager.PlayTestSound(_effectsLevel);
            });

        tokenField.onValueChanged.AddListener(
            (value) =>
            {
                _token = value;
            });
        
        usernameField.onValueChanged.AddListener(
            (value) =>
            {
                _username = value;   
            });
        
        channelNameField.onValueChanged.AddListener(
            (value) =>
            {
                _channelName = value;
            });
        
        commandPrefixField.onValueChanged.AddListener(
            (value) =>
            {
                _commandPrefix = ParseCommandPrefix(value);
                commandPrefixField.text = _commandPrefix;
            });
        saveButton.onClick.AddListener(OnSavePreferences);
        saveButton.onClick.AddListener(OnCloseTapped);
    }
    
    private void OnSavePreferences()
    {
        PreferenceService.MusicLevel = _musicLevel;
        PreferenceService.EffectsLevel = _effectsLevel;

        if (PreferenceService.Token != _token || PreferenceService.Username != _username ||
            PreferenceService.ChannelName != _channelName)
        {
            PreferenceService.Token = _token;
            PreferenceService.Username = _username;
            PreferenceService.ChannelName = _channelName;
            ChatManager.Instance.Reconnect();
        }

        _audioManager.UpdateBackgroundLevel();
        PreferenceService.CommandPrefix = ParseCommandPrefix(_commandPrefix);
    }

    private string ParseCommandPrefix(string value)
    {
        value = value.Replace("!", "").ToLower();
        
        if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
        {
            value = Regex.Replace(value, "[^a-zA-Z]", "");
        }

        return "!" + value;
    }

    private void OnCloseTapped()
    {

    }
}
