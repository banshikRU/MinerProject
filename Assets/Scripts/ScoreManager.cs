using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Rendering;
using System;
using Cinemachine;
using UnityEditor.ShaderGraph.Internal;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public class PlayerScore : UnityEvent<int> { }
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private BuffManager _buffManager;
    [SerializeField] private TextMeshProUGUI _scores;
    [SerializeField] private TextMeshProUGUI _damageMulti;
    [SerializeField] private GameObject _fire;
    private int curentScores;
    public static PlayerScore _scoreEvent;
    private float t;
    private float _timeMyulti;
    private int scoresToMulti;
    [SerializeField] private float _timeToMultiply;
    [SerializeField] private float timeToFire;
    private bool isFire;
    [SerializeField] private Animator scoreAnimation;
    private void Start()
    {
        isFire = false;
        t = 0;
        curentScores = 0;
        _timeMyulti = _timeToMultiply;
        _scoreEvent = new PlayerScore();
        _scores.text = 0.ToString();
        UpdateScoresMulti(1f);
        _scoreEvent.AddListener(ScoreUpdate);
    }
    private void UpdateScoresMulti (float scoresMulti)
    {
        _damageMulti.text = "Damage X"+ scoresMulti;
    }
    public void ScoreUpdate(int scores)
    {
        if (scores >=10)
        {
            scoresToMulti += scores;
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
            _timeMyulti -= Time.fixedDeltaTime;
            Debug.Log(_timeMyulti);
            t -= Time.fixedDeltaTime;
            if (_timeMyulti <= 0)
            {
                _timeMyulti = _timeToMultiply;
                if (scoresToMulti >=250)
                {
                    _playerMover._damageMultiplier = 1.7f;
                }
                else if (scoresToMulti >= 200)
                {
                    _playerMover._damageMultiplier = 1.6f;
                }
                else if (scoresToMulti >= 150)
                {
                    _playerMover._damageMultiplier = 1.5f;
                }
                else if (scoresToMulti >= 100)
                {
                    _playerMover._damageMultiplier = 1.4f;
                }
                else if (scoresToMulti >= 50)
                {
                    _playerMover._damageMultiplier = 1.3f;
                }
                else
                {
                    _playerMover._damageMultiplier = 1;
                }
                UpdateScoresMulti(_playerMover._damageMultiplier);
                scoresToMulti = 0;
            }
            if (t <= 0)
            {
                _playerMover._damageMultiplier = 1;
                UpdateScoresMulti(_playerMover._damageMultiplier);
                _fire.SetActive(false);
                isFire = false;
                t = timeToFire;
                _timeMyulti = _timeToMultiply;
            }
        }
    }
}
