using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _highscorePanel;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private FirstPersonController _player;
    private void Awake()
    {
        //Cursor.visible = true;
    }
    public void Play()
    {
        //_gameManager.InGame.SetActive(true);
        //_player.IsGaming = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenHighscorePanel() => _highscorePanel.SetActive(true);
    public void CloseHighscorePanel() => _highscorePanel.SetActive(false);
}