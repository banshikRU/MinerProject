using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHiter : MonoBehaviour
{
    private bool isFirstHit;
    private void Start()
    {
        isFirstHit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isFirstHit)
        {
            isFirstHit =true;
            HeartManager.hitMeInstance.Invoke(1);
        }
    }
}
