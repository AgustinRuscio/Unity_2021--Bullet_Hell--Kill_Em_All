using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform _playerSpawnPoint;

    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private GameObject _pausePanel;

    [SerializeField]
    private GameObject _winPanel;

    [SerializeField]
    private GameObject _losePanel;

    [SerializeField] 
    private ProgressBar progressBar;

    private ICommand updateCommand;
    private float progress = 0; 


    private float _endGameTimer;
    
    [SerializeField]
    private float _roundTime;

    [SerializeField]
    private string _nextLevel;


    private void Awake()
    {
        Time.timeScale = 1f;

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        EventManager.Subscribe(EventEnum.PauseGame, PauseGame);
        EventManager.Subscribe(EventEnum.BackToMenu, BackToMenu);
        EventManager.Subscribe(EventEnum.NextLevel, NextLevel);
        EventManager.Subscribe(EventEnum.RetryLevel, RetyLevel);
        EventManager.Subscribe(EventEnum.LoseLevel, LoseLevel);

        updateCommand = new UpdateProgressBarCommand(progressBar);

        _endGameTimer = _roundTime;
    }

    private void Update()
    {
        RoundTimer();
    }

    private void RoundTimer()
    {
        _endGameTimer -= Time.deltaTime;

        progress = Mathf.Clamp01(_endGameTimer / _roundTime);

        if (_endGameTimer <= 0) { 

            _endGameTimer = 0;
            WinLevel();
        }

        updateCommand.Execute(progress);
    }

    #region Canvas
    private void PauseGame(params object[] parameters)
    {
        if ((bool)parameters[0])
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pausePanel.SetActive(false);
        }
    }

    private void BackToMenu(params object[] parameters)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    private void RetyLevel(params object[] parameters)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void LoseLevel(params object[] parameters)
    {
        Time.timeScale = 0f;
        _losePanel.SetActive(true);
    }
    private void WinLevel()
    {
        Time.timeScale = 0;
        _winPanel.SetActive(true);
    }

    private void NextLevel(params object[] parameters)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_nextLevel);
    }

    #endregion


    private void OnDestroy()
    {
        EventManager.Unsubscribe(EventEnum.PauseGame, PauseGame);
        EventManager.Unsubscribe(EventEnum.BackToMenu, BackToMenu);
        EventManager.Unsubscribe(EventEnum.NextLevel, NextLevel);
        EventManager.Unsubscribe(EventEnum.RetryLevel, RetyLevel);
        EventManager.Unsubscribe(EventEnum.LoseLevel, LoseLevel);
    }
}