using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRockGenerator : MonoBehaviour
{
    [SerializeField] private float timeBetweenObstacles;
    [SerializeField] private float timeBetweenDelete;
    [SerializeField] private GameObject _attention;
    [SerializeField] private GameObject _rock;
    private float time;
    private bool isTimerStart;
    [SerializeField] private GameObject player;
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
                Instantiate(_attention, player.transform.position, Quaternion.identity);
                Instantiate(_rock, player.transform.position+ new Vector3(0,15), Quaternion.identity);
            }
        }
    }
}
