using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Rendering;
using System;
using Cinemachine;

public class PlayerScore : UnityEvent<int> { }
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private BuffManager _buffManager;
    [SerializeField] private TextMeshProUGUI _scores;
    [SerializeField] private GameObject _fire;
    private int curentScores;
    public static PlayerScore _scoreEvent;
    private float t;
    [SerializeField] private float timeToFire;
    private bool isFire;
    [SerializeField] private Animator scoreAnimation;
    private void Start()
    {
        isFire = false;
        t = 0;
        curentScores = 0;
        _scoreEvent = new PlayerScore();
        _scores.text = 0.ToString();
        _scoreEvent.AddListener(ScoreUpdate);
    }
    public void ScoreUpdate(int scores)
    {
        if (scores >=15)
        {
            if (isFire == true)
            {
                _fire.SetActive(true);
                t = timeToFire;
            }
            else
            {
                t = timeToFire;
                isFire = true;
            }
        }
        if (_buffManager.IsExtraExtractionActive)
        {
            curentScores += scores*2;
        }
        else
        {
            curentScores += scores ;
        }
        _scores.text = curentScores.ToString();
        scoreAnimation.Play("ScoreAnimation");
    }
    private void FixedUpdate()
    {
        if (isFire)
        {
            t -= Time.fixedDeltaTime;
            if (t <= 0)
            {
                _fire.SetActive(false);
                isFire = false;
                t = timeToFire;
            }
        }
    }
}
