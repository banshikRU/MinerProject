using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    [SerializeField]private GameObject _pauseButton;
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("FirstTraining")== 0)
        {
            _pauseButton.SetActive(false);
        }
        else
        {
            _pauseButton.SetActive(true);
        }
    }
    
}
