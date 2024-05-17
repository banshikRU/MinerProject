using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class HitMe : UnityEvent<int> { }
public class HeartManager : MonoBehaviour
{
    public static HitMe hitMeInstance = new HitMe();
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _firstHeart;
    [SerializeField] private GameObject _secondHeart;
    [SerializeField] private GameObject _thirdHeart;
    [SerializeField] private Sprite _fullHeart;
    [SerializeField] private Sprite _emptyHeart;
    public bool isExtraHelmetActive;
    private int _curentHealth;
    private void Start()
    {
        _curentHealth = 3;
        hitMeInstance.AddListener(HitMe);
    }
    private void HitMe(int hit)
    {
        if (isExtraHelmetActive && FindObjectOfType<ObstacleGenerator>()._curentSnake != null)
        {
            Destroy(GameObject.Find("ExtraHelmetPopUp"));
            isExtraHelmetActive = false;
        }
        else
        {
            _curentHealth -= hit;
            switch (_curentHealth)
            {
                case 0:
                    DeactivateHeart(_firstHeart);
                    DeactivateHeart(_secondHeart);
                    DeactivateHeart(_thirdHeart);
                    Death();
                    break;
                case 1:
                    ActivateHeart(_firstHeart);
                    DeactivateHeart(_secondHeart);
                    DeactivateHeart(_thirdHeart);
                    break;
                case 2:
                    ActivateHeart(_firstHeart);
                    ActivateHeart(_secondHeart);
                    DeactivateHeart(_thirdHeart);
                    break;
                case 3:
                    ActivateHeart(_firstHeart);
                    ActivateHeart(_secondHeart);
                    ActivateHeart(_thirdHeart);
                    break;
            }
        }
    }
    private void ActivateHeart(GameObject heart)
    {
        Image heartImage = heart.GetComponent<Image>();
        heartImage.sprite = _fullHeart;

    }
    private void DeactivateHeart(GameObject heart)
    {
        Image heartImage = heart.GetComponent<Image>();
        heartImage.sprite = _emptyHeart;
    }
    private void Death()
    {
        _gameManager.PlayerDeath();
    }
}
