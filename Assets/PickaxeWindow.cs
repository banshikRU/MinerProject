using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
public class PickaxeWindow : MonoBehaviour
{
    [SerializeField]private UpgradeMenuManager _upgradeMenuManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Picaxe _curentPickaxe;
    [SerializeField] private TextMeshProUGUI _pickaxeName;
    [SerializeField] private TextMeshProUGUI _pickaxeDamage;
    [SerializeField] private TextMeshProUGUI _pickaxeEndurance;
    [SerializeField] private TextMeshProUGUI _pickaxeLevel;
    [SerializeField] private TextMeshProUGUI _enduranceButtonText;
    [SerializeField] private TextMeshProUGUI _damageButtonText;
    [SerializeField] private Image _curentPickaxeImage;
    [SerializeField] private Button _pickaxeUpgradeEnduranceButton;
    [SerializeField] private Button _pickaxeUpgradeDamageButton;
    [SerializeField] private Button _repairButton;
    [SerializeField] private GameObject _repairIcon;
    private int _curentPickaxeEndurance;
    private int _curentPickaxeLevel;
    private int _curentPickaxeDamage;
    private void Start()
    {
        _curentPickaxeImage.sprite = _curentPickaxe.picaxeImage;
        _curentPickaxeEndurance = _curentPickaxe.baseEndurance;
        _curentPickaxeDamage = _curentPickaxe.baseDamage;
        _curentPickaxeLevel = 1;
        _pickaxeName.text = _curentPickaxe.pickaxeName;
        UpdatePickaxeStatus();
        CanUpgradeDamagePickaxe();
        CanUpgradeEndurancePickaxe();
    }
    public void RepairPickaxe()
    {
        double a = _gameManager.ReturnResourceCount(_curentPickaxe.repairResource);
        a -= Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.repairRatio);
        _gameManager.CurentPickaxeEndurance = _curentPickaxeEndurance;
        _gameManager.UpdateOresCount(_curentPickaxe.repairResource, (int)a);
        _upgradeMenuManager.UpdateResourcesCount();
        UpdatePickaxeStatus();
        CanUpgradeEndurancePickaxe();
    }
    private void IsNeedRepair()
    {
        if (_gameManager.CurentPickaxeEndurance <= 0)
        {
            _repairIcon.SetActive(true);
            if (Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.repairRatio) <= _gameManager.ReturnResourceCount(_curentPickaxe.repairResource))
            {
                _repairButton.interactable = true;
            }
            else
            {
                _repairButton.interactable = false;
            }
        }
        else
        {
            _repairIcon.SetActive(false);
        }
    }
    private void UpdatePickaxeStatus()
    {
        _pickaxeDamage.text = _curentPickaxeDamage.ToString()+" "+"Damage";
        _pickaxeEndurance.text  = _curentPickaxeEndurance.ToString()+" "+"Endurance";
        _pickaxeLevel.text = _curentPickaxeLevel.ToString()+" "+"Level";

    }
    private void CanUpgradeEndurancePickaxe()
    {
        if (_curentPickaxeLevel!= 10)
        {
            if (Math.Ceiling(_curentPickaxeLevel* _curentPickaxe.enduranceRatioUpgrade)<= _gameManager.ReturnResourceCount(_curentPickaxe.enduranceUpgradeResource) )
            {
                _pickaxeUpgradeEnduranceButton.interactable = true;
            }
            else
            {
                _pickaxeUpgradeEnduranceButton.interactable = false;
            }
        }
        else
        {
            _pickaxeUpgradeEnduranceButton.interactable = false;
        }
        _enduranceButtonText.text = Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.enduranceRatioUpgrade).ToString() +" "+"Neded";
    }
    private void CanUpgradeDamagePickaxe()
    {
        if (_curentPickaxeLevel != 10)
        {
            if (Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.damageRatioUpgrade) <= _gameManager.ReturnResourceCount(_curentPickaxe.damageUpgradeResource))
            {
                _pickaxeUpgradeDamageButton.interactable = true;
            }
            else
            {
                _pickaxeUpgradeDamageButton.interactable = false;
            }
        }
        else
        {
            _pickaxeUpgradeDamageButton.interactable = false;
        }
        _damageButtonText.text = Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.damageRatioUpgrade).ToString()+" "+"Neded";
    }
    public void UpgradePickaxeDamage()
    {
        double a = _gameManager.ReturnResourceCount(_curentPickaxe.damageUpgradeResource);
        a -= Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.damageRatioUpgrade);
        _curentPickaxeLevel += 1;
        _curentPickaxeDamage += 5;
        _gameManager.CurentPickaxeDamage = _curentPickaxeDamage;
        _gameManager.UpdateOresCount(_curentPickaxe.damageUpgradeResource, (int)a);
        _upgradeMenuManager.UpdateResourcesCount();
        UpdatePickaxeStatus();
        CanUpgradeDamagePickaxe();
    }
    public void UpgradePickaxeEndurance()
    {
        double a = _gameManager.ReturnResourceCount(_curentPickaxe.enduranceUpgradeResource);
        a -= Math.Ceiling(_curentPickaxeLevel * _curentPickaxe.enduranceRatioUpgrade);
        _curentPickaxeLevel += 1;
        _curentPickaxeEndurance += 5;
        _gameManager.CurentPickaxeEndurance = _curentPickaxeEndurance;
        _gameManager.UpdateOresCount(_curentPickaxe.enduranceUpgradeResource, (int)a);
        _upgradeMenuManager.UpdateResourcesCount();
        UpdatePickaxeStatus();
        CanUpgradeEndurancePickaxe();
    }
}
