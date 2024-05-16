using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager: MonoBehaviour
{
    private bool isExtraDamageActive;
    private bool isExtraDefenderActive;
    private bool isExtraExtractionActive;

    public bool IsExtraDamageActive { get => isExtraDamageActive; set => isExtraDamageActive = value; }
    public bool IsExtraDefenderActive { get => isExtraDefenderActive; set => isExtraDefenderActive = value; }
    public bool IsExtraExtractionActive { get => isExtraExtractionActive; set => isExtraExtractionActive = value; }
}
