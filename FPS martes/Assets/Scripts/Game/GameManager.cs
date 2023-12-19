using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public Gun Gun;
    public bool IsPlaying;
    public GameObject InGame 
    {
        get { return _inGame; }
        set { _inGame = value; }
    }
    #endregion

    #region PRIVATE_PROPERTIES
    private bool scoreSaved = false;

    [SerializeField] private GameObject _inGame;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseText;
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _endText;
    public GameObject _winText;
    public GameObject _losserText;

    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private RoundTime _roundTime;
    [SerializeField] private Score _score;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        HandleEscape();
        HandleEnter();
        //HandleReset();
        HandleMenu();
        
    }
    #endregion

    #region METHODS
    public void Init()
    {
        PauseGame();
        Gun.CanShoot = false;
        IsPlaying = false;
        _winText.SetActive(false);
        _losserText.SetActive(false);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    #endregion

    #region HANDLES_METHODS
    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPlaying)
        {
            _pauseText.SetActive(!_pauseText.activeSelf);
            if (!_pauseText.activeSelf)
            {
                ResumeGame();
                Gun.CanShoot = true;
            }
            else
            {
                PauseGame();
                Gun.CanShoot = false;
            }
        }
    }
    private void HandleEnter()
    {
        if (!IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                IsPlaying = true;
                _startText.SetActive(false);
                ResumeGame();
                Gun.CanShoot = true;
            }
        }
    }
    private void HandleReset()
    {
        if (_roundTime.IsEndRound && !scoreSaved && !IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _score.SaveScore();
                _score.SaveCounter();
                scoreSaved = true;

                //_endText.SetActive(false);
                //RoundTime.InitRoundTime();
                //Score.InitScore();
                //Time.timeScale = 1f;
                //Gun.CanShoot = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                WaveSpawner.EnemiesAlive = 0;
            }
        }
    }
    private void HandleMenu()
    {
        if (_roundTime.IsEndRound && !scoreSaved && !IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _endText.SetActive(false);
                _score.SaveScore();
                _score.SaveCounter();
                Time.timeScale = 1f;

                SceneManager.LoadScene(0);
                scoreSaved = true;
                WaveSpawner.EnemiesAlive = 0;
            }
        }
    }
    #endregion
}