using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateBackGround : UnityEvent { }
public class BackGroundGenerator : MonoBehaviour
{
    public static GenerateBackGround instance = new GenerateBackGround();
    private Queue<GameObject> _generatedQueue = new Queue<GameObject>();
    [SerializeField] private List<GameObject> _backGroundPrefabs;
    [SerializeField] private int _countBetweenGenerate;
    private int count;
    private void Start()
    {
        instance.AddListener(GenerateBackGround);
        count = 0;
    }
    private void GenerateBackGround()
    {
        if (_generatedQueue.Count > 3)
        {
            Destroy(_generatedQueue.Dequeue());
        }
        count++;
        if (count >= _countBetweenGenerate)
        {
            count = 0;
            _generatedQueue.Enqueue(Instantiate(_backGroundPrefabs[Random.Range(0, _backGroundPrefabs.Count)], new Vector3(1, transform.position.y - 5.8f), Quaternion.identity));
        }
    }
}
