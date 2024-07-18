using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBlock :IAmBlock
{
    [SerializeField] private int _myPrize;
    public override void DestroyMe()
    {
        RunTimeCoinManager.instance.PlusCoins(_myPrize);
        base.DestroyMe();

    }
}
