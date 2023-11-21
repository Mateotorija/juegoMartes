using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _highscorePanel;
    [SerializeField] private GameObject _profilePanel;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _profileText;
    private string _profileName;
    private void Start()
    {
        _profileName = PlayerPrefs.GetString("Player");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("¡Datos de PlayerPrefs eliminados!");
    }
    public void SavePlayer()
    {
        _profileName = _inputField.text;
        PlayerPrefs.SetString("Player", _profileName);
        Debug.Log(_profileName);
        UpdateProfileName();
    }
    public void UpdateProfileName() => _profileText.text = "Profile: " + _profileName;
    public void OpenHighscorePanel() => _highscorePanel.SetActive(true);
    public void CloseHighscorePanel() => _highscorePanel.SetActive(false);
    public void OpenProfilePanel() 
    {
        UpdateProfileName();
        _profilePanel.SetActive(true);
    } 
    public void CloseProfilePanel() => _profilePanel.SetActive(false);
}