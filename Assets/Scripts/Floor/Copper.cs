using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copper :IAmBlock
{
    [SerializeField] private GameObject _collectableOre;
    public override void DestroyMe()
    {
        base.DestroyMe();
        Instantiate(_collectableOre, transform.position, Quaternion.identity);
    }
}
