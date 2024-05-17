using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private LevelBuilder _levelBuilder;
    [SerializeField] private GameObject _attention;
    [SerializeField] private GameObject _snake;
    [SerializeField] private GameObject _rock;
    public GameObject _curentSnake;
    private double timeToRock;
    private double timeToSnake;
    private bool isTimerStart;
    [SerializeField] private GameObject player;
    private List<int> level = new List<int>() {-1,0,1,2,3};
    private void Start()
    {
        _curentSnake = null;
        timeToRock = 5 - (_levelBuilder.CurentLevel * 0.005);
        timeToSnake = 10 - (_levelBuilder.CurentLevel * 0.005);
        isTimerStart = true;
    }
    private void FixedUpdate()
    {
        if (isTimerStart)
        {
            timeToRock -= Time.fixedDeltaTime;
            if (timeToRock <= 0)
            {
                timeToRock =5 - (_levelBuilder.CurentLevel * 0.005);
                GenerateRockObstacle();
            }

            timeToSnake -= Time.fixedDeltaTime;
            if (timeToSnake<= 0)
            {
                timeToSnake = 10 - (_levelBuilder.CurentLevel * 0.005);
                GenerateSnakeObstacle();
            }
        }
    }
    private void GenerateRockObstacle()
    {
        int x = Random.Range(0, 100);
        if (x>80)
        {
            StartCoroutine(GenerateRainRock());
        }
        else
        if (x > 50)
        {
            List<int> a = new List<int>(level);
            int y = Random.Range(1, 5);
            for (int i = 0; i < y; i++)
            {
                int levelX = a[Random.Range(0, a.Count)];
                a.Remove(levelX);
                Instantiate(_attention, new Vector3(levelX,player.transform.position.y), Quaternion.identity);
                Instantiate(_rock, new Vector3(levelX, player.transform.position.y + 15), Quaternion.identity);
            }
        }
        else
        {
            Instantiate(_attention, player.transform.position, Quaternion.identity);
            Instantiate(_rock, player.transform.position+ new Vector3(0,15), Quaternion.identity);
        }

    }
    private void GenerateSnakeObstacle()
    {
        Debug.Log("snake");
        int x = Random.Range(0, 100);
        if (x > 50 && _curentSnake == null)
        {
            int y = Random.Range(0, 2);
            int z;
            if (y == 1)
            {
                z = 15;
            }
            else
            {
                z = -15;
            }
            _curentSnake = Instantiate(_snake, player.transform.position + new Vector3(z,Random.Range(-5,5)), Quaternion.identity);
        }
    }
    IEnumerator GenerateRainRock()
    {
        List<int> a = new List<int>(level);
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (a.Count == 0)
            {
                a = new List<int>(level);
            }
            int levelX = a[Random.Range(0, a.Count)];
            a.Remove(levelX);
            Instantiate(_attention, new Vector3(levelX, player.transform.position.y), Quaternion.identity);
            Instantiate(_rock, new Vector3(levelX, player.transform.position.y + 15), Quaternion.identity);
        }
        
    }
}
