using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class BuildNewLevel : UnityEvent { }
public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private List<GameObject> wallTiles;
    [SerializeField] private List<GameObject> floorTiles;
    [SerializeField] private List<GameObject> ores;
    private int _curentLevel;
    private float _strongBlockMin;
    private float _strongBlockMax;
    private float _minOresSpawn;
    private float _minRareOresSpawn;
    private float _maxRareOresSpawn;
    public static BuildNewLevel BuildNewLevel = new BuildNewLevel();
    public void Initialize()
    {
        BuildNewLevel.AddListener(BuildNewWorldLevel);
        for (int i = 0; i < 10; i++)
        {
            BuildNewWorldLevel();
        }
        _curentLevel = 0;
    }
    public void BuildNewWorldLevel()
    {
        _curentLevel += 1;
        _strongBlockMin = _curentLevel * 0.05f;
        _strongBlockMax = _curentLevel * 0.03f;
        _minOresSpawn = _curentLevel * 0.01f;
        _minRareOresSpawn = _curentLevel * 0.05f;
        _maxRareOresSpawn = _curentLevel * 0.03f;
        if (_strongBlockMin >= 2)
        {
            _strongBlockMin = 2;
        }
        if (_strongBlockMax >= floorTiles.Count)
        {
            _strongBlockMax = floorTiles.Count;
        }
        if (_minRareOresSpawn >= 1)
        {
            _minRareOresSpawn = 1;
        }
        if (_maxRareOresSpawn >= ores.Count)
        {
            _maxRareOresSpawn = ores.Count;
        }
        if (_minOresSpawn >= 40)
        {
            _minOresSpawn = 40;
        }
        for (float x = transform.position.x; x <= 4; x++) 
        {
            if ( x == transform.position.x || x == 4)
            {
                Instantiate(wallTiles[Random.Range(0, wallTiles.Count )],new Vector3(x, transform.position.y,0),Quaternion.identity);
            }
            else
            {
                if (Random.Range(_minOresSpawn,100)>95)
                {
                    Instantiate(ores[Random.Range(0 + (int)Random.Range(0, _minRareOresSpawn), (int)_maxRareOresSpawn)], new Vector3(x, transform.position.y, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(floorTiles[Random.Range(0 + (int)Random.Range(0, _strongBlockMin), (int)_strongBlockMax)], new Vector3(x, transform.position.y, 0), Quaternion.identity);
                }
               
            }
        }
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y-1, 0);

    }
}
