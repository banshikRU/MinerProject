using UnityEngine;
using TMPro;

public class LocalizationText : MonoBehaviour
{
    [TextArea(0,4)]
    [SerializeField]private string ru;
    [TextArea(0, 4)]
    [SerializeField]private string eng;
    private TextMeshProUGUI localizationText;
    private void Awake()
    {
        localizationText = GetComponent<TextMeshProUGUI>();
        Language.lanSwitch.AddListener(SwitchLanguage);
    }
    private void SwitchLanguage(string lang)
    {
        if (lang == "ru")
        {
            localizationText.text = ru;
        }
        else
        {
            localizationText.text = eng;
        }
    }
    private void OnEnable()
    {
        Language.instance.LanguageSwitch();
    }

}
