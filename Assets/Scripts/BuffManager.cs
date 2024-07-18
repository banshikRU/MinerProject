using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager: MonoBehaviour
{
    public static BuffManager instance;
    private void Start()
    {
        instance = this;
    }
    private bool isExtraDamageActive;
    private bool isExtraDefenderActive;
    private bool isExtraExtractionActive;
    private bool isDoubleBuffTimeActive;
    private bool isMegaPickaxeActive;
    private bool isPirateActive;
    private bool isKnightActive;

    public bool IsExtraDamageActive { get => isExtraDamageActive; set => isExtraDamageActive = value; }
    public bool IsExtraDefenderActive { get => isExtraDefenderActive; set => isExtraDefenderActive = value; }
    public bool IsExtraExtractionActive { get => isExtraExtractionActive; set => isExtraExtractionActive = value; }
    public bool IsDoubleBuffTimeActive { get => isDoubleBuffTimeActive; set => isDoubleBuffTimeActive = value; }
    public bool IsMegaPickaxeActive { get => isMegaPickaxeActive; set => isMegaPickaxeActive = value; }
    public bool IsPirateActive { get => isPirateActive; set => isPirateActive = value; }
    public bool IsKnightActive { get => isKnightActive; set => isKnightActive = value; }
}
