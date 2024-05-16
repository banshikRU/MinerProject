using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraExtractionPopUp : MonoBehaviour
{
    private BuffManager _buffManager;
    [SerializeField] private float _remainingTime;
    private void Start()
    {
        _buffManager = GameObject.FindObjectOfType<BuffManager>();
    }
    void FixedUpdate()
    {
        _buffManager.IsExtraExtractionActive = true;
        _remainingTime -= Time.fixedDeltaTime;
        if (_remainingTime <= 0)
        {
            _buffManager.IsExtraDamageActive = false;
            Destroy(gameObject);
        }
    }
}
