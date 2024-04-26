using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private OreTypeEnum _oreType;
    private Transform target; // Целевой объект, к которому нужно переместиться
    [SerializeField]private float speed = 1.0f; // Скорость перемещения
    [SerializeField]private int _price;
    private void Start()
    {
        target = GameObject.Find("Target").transform;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, target.position, step);
        if (Vector2.Distance(gameObject.transform.position,target.transform.position) < 2f)
        {
            Destroy(gameObject);
            ScoreManager._scoreEvent.Invoke(_price);
        }
    }
}
