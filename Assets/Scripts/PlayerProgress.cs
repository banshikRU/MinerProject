using UnityEngine;
[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int Scores;
    public int Bombs;
    public bool isFirstScinBuy;
    public bool isSecondScinBuy;
    public bool isThirdScinBuy;
    public bool isFirstTraining;
    public bool isLastTraining ;
    public bool isFirstSuperJump;
}
public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;
    public PlayerInfo playerInfo;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    public void Initialize()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 55);
            Debug.Log("Coins Set!");
        }
        if (!PlayerPrefs.HasKey("Bombs"))
        {
            PlayerPrefs.SetInt("Bombs", 0);
            Debug.Log("Bombs Set!");
        }
        if (!PlayerPrefs.HasKey("Scores"))
        {
            PlayerPrefs.SetInt("Scores", 0);
            Debug.Log("Scores Set!");
        }
        if (!PlayerPrefs.HasKey("FirstScinBuy"))
        {
            PlayerPrefs.SetInt("FirstScinBuy", 0);
            Debug.Log("FirstScinBuy Set!");
        }
        if (!PlayerPrefs.HasKey("SecondScinBuy"))
        {
            PlayerPrefs.SetInt("SecondScinBuy", 0);
            Debug.Log("SecondScinBuy Set!");
        }
        if (!PlayerPrefs.HasKey("ThirdScinBuy"))
        {
            PlayerPrefs.SetInt("ThirdScinBuy", 0);
            Debug.Log("ThirdScinBuy Set!");
        }
        if (!PlayerPrefs.HasKey("FirstTraining"))
        {
            PlayerPrefs.SetInt("FirstTraining", 0);
            Debug.Log("FirstTraining Set!");
        }
        if (!PlayerPrefs.HasKey("LastTraining"))
        {
            PlayerPrefs.SetInt("LastTraining", 0);
            Debug.Log("LastTraining Set!");
        }
        if (!PlayerPrefs.HasKey("FirstSuperJump"))
        {
            PlayerPrefs.SetInt("FirstSuperJump", 0);
            Debug.Log("FirstSuperJump Set!");
        }
        if (!PlayerPrefs.HasKey("GameRated"))
        {
            PlayerPrefs.SetInt("GameRated", 0);
            Debug.Log("GameRated Set!");
        }
        YandexManager.ysdk.Load();
       
    }
    public void Save()
    {
        string jsonString= JsonUtility.ToJson(playerInfo);
        YandexManager.ysdk.Save(jsonString);
    }
    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        Debug.Log(playerInfo.Coins);
        Debug.Log(playerInfo.Scores);
    }
}
