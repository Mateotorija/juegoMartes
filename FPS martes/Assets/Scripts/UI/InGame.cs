using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public Gun Gun;
    public RoundTime RoundTime;
    public Score Score;
    private bool scoreSaved = false;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private GameObject _pauseText;
    [SerializeField] private GameObject _endText;
    private bool _isPlaying;
    #endregion

    #region UNITY_METHODS
    private void Start()
    {
        _isPlaying = false;
    }
    private void Update()
    {
        HandleEnter();
        HandleEscape();
        HandleReset();
        HandleMenu();
    }
    #endregion

    #region METHODS
    private void HandleEnter()
    {
        if (!_isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _isPlaying = true;
                _pauseText.SetActive(false);
                Time.timeScale = 1f;
                Gun.CanShoot = true;
            }
        }
    }
    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseText.SetActive(!_pauseText.activeSelf);
            if (!_pauseText.activeSelf)
            {
                Time.timeScale = 1f;
                Gun.CanShoot = true;
            }
            else
            {
                Time.timeScale = 0f;
                Gun.CanShoot = false;
            }
        }
    }
    private void HandleReset()
    {
        if (RoundTime.IsEndRound && !scoreSaved)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Score.SaveScore();
                scoreSaved = true;

                //_endText.SetActive(false);
                //RoundTime.InitRoundTime();
                //Score.InitScore();
                //Time.timeScale = 1f;
                //Gun.CanShoot = true;
                SceneManager.LoadScene(1);
            }
        }
    }
    private void HandleMenu()
    {
        if (RoundTime.IsEndRound && !scoreSaved)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                _endText.SetActive(false);
                Score.SaveScore();
                Time.timeScale = 1f;
                
                SceneManager.LoadScene(0);
                scoreSaved = true;
            }
        }
    }
    #endregion
}