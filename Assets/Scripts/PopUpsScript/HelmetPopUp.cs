using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetPopUp : MonoBehaviour
{
    private HeartManager _heartManager;
    private void Start()
    {
        _heartManager = GameObject.FindObjectOfType<HeartManager>();
        _heartManager.isExtraHelmetActive = true;
    }
}
