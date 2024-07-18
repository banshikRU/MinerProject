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
            CurentLanguage = YandexManager.ysdk.GetLanguage();
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    public void LanguageSwitch()
    {
        lanSwitch.Invoke(CurentLanguage);
    }
}
