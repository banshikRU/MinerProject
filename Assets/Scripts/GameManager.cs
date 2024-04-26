using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
public class UpdateInventoryStatus : UnityEvent<OreTypeEnum> { }
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _UpgradeMenu;
    public static UpdateInventoryStatus updateInventoryStatus;
    [SerializeField]private TextMeshProUGUI _curentEndurance;
    private int _cooperCount;
    private int _goldCount;
    private int _ironCount;
    private int _emeraldCount;
    private int _diamondCount;
    private int _moneyCount = 10;
    private int _curentPickaxeEndurance = 10;
    private int _curentPickaxeDamage;

    public int CooperCount { get => _cooperCount; set => _cooperCount = value; }
    public int GoldCount { get => _goldCount; set => _goldCount = value; }
    public int IronCount { get => _ironCount; set => _ironCount = value; }
    public int EmeraldCount { get => _emeraldCount; set => _emeraldCount = value; }
    public int DiamondCount { get => _diamondCount; set => _diamondCount = value; }
    public int MoneyCount { get => _moneyCount; set => _moneyCount = value; }
    public int CurentPickaxeEndurance 
    { 
        get => _curentPickaxeEndurance;
        set
        {
            _curentEndurance.text = _curentPickaxeEndurance.ToString();
            if (value <= 0)
            {
                _curentPickaxeEndurance = 0;
                StopGame();
            }
            else
            {
                _curentPickaxeEndurance = value;
            }
        }
    }
    public int CurentPickaxeDamage { get => _curentPickaxeDamage; set => _curentPickaxeDamage = value; }

    private void StopGame()
    {
        _UpgradeMenu.SetActive(true);
    }
    private void Start()
    {
        _curentEndurance.text = _curentPickaxeEndurance.ToString();
        updateInventoryStatus = new UpdateInventoryStatus();
        updateInventoryStatus.AddListener(UpdateOresCount);
        CooperCount = 0;
        GoldCount = 0;
        IronCount = 0;
        EmeraldCount = 0;
        DiamondCount = 0;
        //MoneyCount = 0;
    }
    public int ReturnResourceCount(OreTypeEnum ore)
    {
        switch (ore)
        {
            case OreTypeEnum.cooper:
                return CooperCount;
            case OreTypeEnum.iron:
                return IronCount;
            case OreTypeEnum.gold:
                return GoldCount;
            case OreTypeEnum.diamond:
                return DiamondCount;
            case OreTypeEnum.emerald:
                return EmeraldCount;
            case OreTypeEnum.money:
                return MoneyCount;
            default:
                return 0;
        }
    }
    private void UpdateOresCount(OreTypeEnum ore)
    {
        switch (ore)
        {
            case OreTypeEnum.cooper:
                CooperCount++;
                break;
            case OreTypeEnum.iron:
                GoldCount++;   
                break;
            case OreTypeEnum.gold:
                IronCount++;
                break;
            case OreTypeEnum.diamond:
                DiamondCount++;
                break;
            case OreTypeEnum.emerald:
                EmeraldCount++;
                break;
            case OreTypeEnum.money:
                EmeraldCount++
                ;break;
            default:
                break;
        }
    }
    public void UpdateOresCount(OreTypeEnum ore,int curentCount)
    {
        switch (ore)
        {
            case OreTypeEnum.cooper:
                CooperCount = curentCount;
                break;
            case OreTypeEnum.iron:
                GoldCount = curentCount;
                break;
            case OreTypeEnum.gold:
                IronCount = curentCount;
                break;
            case OreTypeEnum.diamond:
                DiamondCount = curentCount;
                break;
            case OreTypeEnum.emerald:
                EmeraldCount = curentCount;
                break;
            case OreTypeEnum.money:
                MoneyCount= curentCount; break;
            default:
                break;
        }

    }
}
