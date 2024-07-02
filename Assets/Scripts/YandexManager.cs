using System.Runtime.InteropServices;
using UnityEngine;

public class YandexManager : MonoBehaviour
{
    public static YandexManager ysdk;
    private void Awake()
    {
        ysdk = this;
    }
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    [DllImport("__Internal")]
    private static extern void SaveToLeaderBoardExt(int value);
    [DllImport("__Internal")]
    private static extern string GetLang();
    [DllImport("__Internal")]
    private static extern void RateGameExt();
    [DllImport("__Internal")]
    private static extern void ShowRew(int value);
    [DllImport("__Internal")]
    private static extern void ShowRewBomb();
    [DllImport("__Internal")]
    private static extern void ShowRewX(int value);
    [DllImport("__Internal")]
    private static extern void ShowRewPlusRunTimeCoins(int value);
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    public string GetLanguage()
    {
        string lan = GetLang();
        return lan;
    }
    public void ShowFullScreenAdv()
    {
        //ShowAdv();
    }
    public void Save(string date)
    {
       //SaveExtern(date);
    }
    public void Load()
    {
      // LoadExtern();
    }
    public void SetPlayerData(string data)
    {
        PlayerProgress.instance.SetPlayerInfo(data);
        CoinManager.instance.Initialize();
    }
    public void AddCoins(int value)
    {
        SoundManager.instance.AdvOff();
        CoinManager.instance.AddCoins(value);
    }
    public void AddBomb()
    {
        SoundManager.instance.AdvOff();
        //PlayerProgress.instance.playerInfo.Bombs++;
        //PlayerProgress.instance.Save();
        PlayerPrefs.SetInt("Bombs", PlayerPrefs.GetInt("Bombs") + 1);
        PlayerPrefs.Save();
        ConsumablesBomb.instance.Initialize();
    }
    public void AddX(int value)
    {
        SoundManager.instance.AdvOff();
        CoinManager.instance.AddCoins(value);
    }
    public void ShowRewardedAdv(int value)
    {
        SoundManager.instance.AdvOn();
        ShowRew(value);
    }
    public void ShowRewardedAdvBomb()
    {
        SoundManager.instance.AdvOn();
        ShowRewBomb();
    }
    public void ShowRewardedAdvX(int value)
    {
        SoundManager.instance.AdvOn();
        ShowRewX(value);
    }
    public void ShowRewardedAdvPlusCoinsRunTime(int value)
    {
        SoundManager.instance.AdvOn();
        ShowRewPlusRunTimeCoins(value);
    }
    public void AddRunTimeCoins(int value)
    {
        SoundManager.instance.AdvOff();
        //PlayerProgress.instance.playerInfo.Coins += value;
        //PlayerProgress.instance.Save();
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + value);
        PlayerPrefs.Save();
        RunTimeCoinManager.instance.AbsoluteCoinsCount += value;
        RestartMenu.instance.RestartMenuInitialize();

    }
    public void SaveToLeaderBoard(int value)
    {
        SaveToLeaderBoardExt(value);
    }
    public void RateGame()
    {
        RateGameExt();
    }
}
