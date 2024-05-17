using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject _attention;
    [SerializeField]private float timeToRevert;
    private bool isRevert;
    private void Awake()
    {
        _attention.SetActive(false);
        isRevert = false;
    }
    public void RevertSprite()
    {
        _attention.SetActive(true);
        isRevert = true;
    }
    private void Update()
    {
        if (isRevert)
        {
            timeToRevert -= Time.fixedDeltaTime;
            if (timeToRevert <= 0)
            {
                isRevert = false;
                _attention.SetActive(false);
            }
        }
    }
    
}
