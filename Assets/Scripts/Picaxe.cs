using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Picaxe", order = 1)]
public class Picaxe : ScriptableObject
{
    public Sprite picaxeImage;
    public float enduranceRatioUpgrade;
    public float damageRatioUpgrade;
    public float repairRatio;
    public int baseEndurance;
    public int baseDamage;
    public string pickaxeName;
    public OreTypeEnum enduranceUpgradeResource;
    public OreTypeEnum damageUpgradeResource;
    public OreTypeEnum repairResource;


}
