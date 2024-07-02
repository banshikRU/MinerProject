using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetBlock : IAmBlock
{
    HeartManager heartManager;
    SmothMovement playerMover;
    public override void DestroyMe()
    {
        base.DestroyMe();
        playerMover = FindObjectOfType<SmothMovement>();
        heartManager = FindObjectOfType<HeartManager>();
        BuffManager.instance.IsExtraDefenderActive = true;
        if(!BuffManager.instance.IsKnightActive && !BuffManager.instance.IsPirateActive)
        {
            playerMover.SetAnimatorHelmet();
        }
        heartManager._extraHelmetHeart.SetActive(true);
    }
}
