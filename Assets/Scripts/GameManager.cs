using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _playMenu;
    private void Awake()
    {
        Time.timeScale = 0f;
        _playMenu.SetActive(false);
    }
    public void StartGame()
    {
        _startMenu.SetActive(false);
        _playMenu.SetActive(true);
        Time.timeScale = 1f;
    }
    public void PlayerDeath()
    {
        Time.timeScale = 0f;
       _restartButton.SetActive(true);
    }
    public void RestartGame()
    {
        _restartButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
