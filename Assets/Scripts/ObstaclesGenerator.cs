using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] private float timeBetweenObstacles;
    private float time;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject player;
    private bool isTimerStart;
    private void Start()
    {
        time = timeBetweenObstacles;
        isTimerStart = true;    
        
    }
    private void FixedUpdate()
    {
        if (isTimerStart)
        {
            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                time = timeBetweenObstacles;
                Instantiate(obstacle, player.transform.position,Quaternion.identity);
            }
        }
    }
}
