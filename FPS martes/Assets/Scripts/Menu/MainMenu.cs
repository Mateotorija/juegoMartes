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
    [SerializeField] private GameObject _targetsPanel;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _profileText;
    public bool canPlay = false;
    private string _profileName;
    private void Start()
    {
        _profileName = PlayerPrefs.GetString("Player");
        UpdateCanPlay();
    }
    public void Play()
    {
        if (canPlay)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            Debug.Log("No se puede jugar sin un perfil");
    }
    private void UpdateCanPlay()
    {
        canPlay = !string.IsNullOrEmpty(_profileName);
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
        PlayerPrefs.Save();
        Debug.Log(_profileName);
        UpdateProfileName();
        UpdateCanPlay();
    }
    public void UpdateProfileName() => _profileText.text = "Profile: " + _profileName;
    public void OpenHighscorePanel() 
    {
        _highscorePanel.SetActive(true);
    } 
    public void CloseHighscorePanel() => _highscorePanel.SetActive(false);
    public void OpenProfilePanel() 
    {
        UpdateProfileName();
        _profilePanel.SetActive(true);
    } 
    public void CloseProfilePanel() => _profilePanel.SetActive(false);
    public void OpenTargetsPanel() => _targetsPanel.SetActive(true);
    public void CloseTargetsPanel() => _targetsPanel.SetActive(false);
}