using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanguageSwitch : UnityEvent<string> {}
public class Language : MonoBehaviour
{
    private string _curentLanguage;
    public static Language instance;
    public static LanguageSwitch lanSwitch;

    public string CurentLanguage { get => _curentLanguage; set => _curentLanguage = value; }

    private void Awake()
    {
        if (instance == null)
        {
            if (lanSwitch == null)
            {
                lanSwitch = new LanguageSwitch();
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    public void Initialize()
    {
        CurentLanguage = YandexManager.ysdk.GetLanguage();
    }
    public void LanguageSwitch()
    {
        lanSwitch.Invoke(CurentLanguage);
    }
}
