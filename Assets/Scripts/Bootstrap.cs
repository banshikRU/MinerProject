using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelBuilder LevelBuilder;
    private void Start()
    {
        LevelBuilder.Initialize();
    }
}
