using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetBlock : IAmBlock
{
    HeartManager heartManager;
    public override void DestroyMe()
    {
        base.DestroyMe();
        heartManager = FindObjectOfType<HeartManager>();
        heartManager._extraHelmetHeart.SetActive(true);
        heartManager.isExtraHelmetActive = true;
    }
}
