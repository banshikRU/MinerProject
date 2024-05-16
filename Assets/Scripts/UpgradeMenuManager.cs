using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeMenuManager : MonoBehaviour
{
    [SerializeField] private Gaga _gameManager;
    [SerializeField] private TextMeshProUGUI _cooperCount;
    [SerializeField] private TextMeshProUGUI _ironCount;
    [SerializeField] private TextMeshProUGUI _goldCount;
    [SerializeField] private TextMeshProUGUI _diamondCount;
    [SerializeField] private TextMeshProUGUI _emeraldCount;
    [SerializeField] private TextMeshProUGUI _moneyCount;
    public void Start()
    {
        UpdateResourcesCount();
    }
    public void UpdateResourcesCount()
    {
        _cooperCount.text = _gameManager.CooperCount.ToString();
        _ironCount.text = _gameManager.IronCount.ToString();
        _goldCount.text = _gameManager.GoldCount.ToString();
        _diamondCount.text =_gameManager.DiamondCount.ToString();
        _emeraldCount.text = _gameManager.EmeraldCount.ToString();
        _moneyCount.text = _gameManager.MoneyCount.ToString();
    }
}
