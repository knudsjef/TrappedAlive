using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    [SerializeField]
    GameObject MainMenu;

    [SerializeField]
    GameObject SettingsMenu;

    [SerializeField]
    GameObject AudioSettingsMenu;

    [SerializeField]
    GameObject VideoSettingsMenu;

    [SerializeField]
    GameObject ControlMenu;

    void Start()
    {
        BackToMenu();
    }
    
    public void NewGame()
    {
        PlayerPrefs.SetInt("Current Scene", 0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Current Scene") + 1);
        PlayerPrefs.SetInt("Current Scene", PlayerPrefs.GetInt("Current Scene") + 1);
    }

    public void Resume()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Current Scene"));
    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Audio()
    {
        SettingsMenu.SetActive(false);
        AudioSettingsMenu.SetActive(true);
    }

    public void Video()
    {
        SettingsMenu.SetActive(false);
        VideoSettingsMenu.SetActive(true);
    }

    public void Controls()
    {
        SettingsMenu.SetActive(false);
        ControlMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void BackToSettings()
    {
        AudioSettingsMenu.SetActive(false);
        VideoSettingsMenu.SetActive(false);
        ControlMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
