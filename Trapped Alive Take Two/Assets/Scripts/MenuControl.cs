using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    Dropdown ResDrop;

    bool Full;

    void Start()
    {
        BackToMenu();

        if(Screen.fullScreen == true)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
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
        AudioSettingsMenu.SetActive(false);
        VideoSettingsMenu.SetActive(false);
        ControlMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void BackToSettings()
    {
        AudioSettingsMenu.SetActive(false);
        VideoSettingsMenu.SetActive(false);
        ControlMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ChangeResolution()
    {
        switch (ResDrop.value)
        {
            case 0:
                PlayerPrefs.SetInt("ScreenWidth", 1600);
                PlayerPrefs.SetInt("ScreenHeight", 675);
                break;

            case 1:
                PlayerPrefs.SetInt("ScreenWidth", 1920);
                PlayerPrefs.SetInt("ScreenHeight", 810);
                break;

            case 2:
                PlayerPrefs.SetInt("ScreenWidth", 1920);
                PlayerPrefs.SetInt("ScreenHeight", 1080);
                break;

            case 3:
                PlayerPrefs.SetInt("ScreenWidth", 1680);
                PlayerPrefs.SetInt("ScreenHeight", 1050);
                break;

            case 4:
                PlayerPrefs.SetInt("ScreenWidth", 1600);
                PlayerPrefs.SetInt("ScreenHeight", 900);
                break;

            case 5:
                PlayerPrefs.SetInt("ScreenWidth", 1440);
                PlayerPrefs.SetInt("ScreenHeight", 900);
                break;

            case 6:
                PlayerPrefs.SetInt("ScreenWidth", 1400);
                PlayerPrefs.SetInt("ScreenHeight", 1050);
                break;

            case 7:
                PlayerPrefs.SetInt("ScreenWidth", 1366);
                PlayerPrefs.SetInt("ScreenHeight", 768);
                break;

            case 8:
                PlayerPrefs.SetInt("ScreenWidth", 1360);
                PlayerPrefs.SetInt("ScreenHeight", 768);
                break;

            case 9:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 1024);
                break;

            case 10:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 960);
                break;

            case 11:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 768);
                break;

            case 12:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 800);
                break;

            case 13:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 720);
                break;

            case 14:
                PlayerPrefs.SetInt("ScreenWidth", 1152);
                PlayerPrefs.SetInt("ScreenHeight", 864);
                break;

            case 15:
                PlayerPrefs.SetInt("ScreenWidth", 1024);
                PlayerPrefs.SetInt("ScreenHeight", 768);
                break;

            case 16:
                PlayerPrefs.SetInt("ScreenWidth", 1280);
                PlayerPrefs.SetInt("ScreenHeight", 540);
                break;

            case 17:
                PlayerPrefs.SetInt("ScreenWidth", 800);
                PlayerPrefs.SetInt("ScreenHeight", 600);
                break;

            case 18:
                PlayerPrefs.SetInt("ScreenWidth", 640);
                PlayerPrefs.SetInt("ScreenHeight", 400);
                break;

            case 19:
                PlayerPrefs.SetInt("ScreenWidth", 512);
                PlayerPrefs.SetInt("ScreenHeight", 384);
                break;

            case 20:
                PlayerPrefs.SetInt("ScreenWidth", 640);
                PlayerPrefs.SetInt("ScreenHeight", 480);
                break;

            case 21:
                PlayerPrefs.SetInt("ScreenWidth", 400);
                PlayerPrefs.SetInt("ScreenHeight", 300);
                break;

            case 22:
                PlayerPrefs.SetInt("ScreenWidth", 320);
                PlayerPrefs.SetInt("ScreenHeight", 200);
                break;

            case 23:
                PlayerPrefs.SetInt("ScreenWidth", 320);
                PlayerPrefs.SetInt("ScreenHeight", 240);
                break;
            
            default:
                PlayerPrefs.SetInt("ScreenWidth", 1920);
                PlayerPrefs.SetInt("ScreenHeight", 1080);
                break;
        }
        if(PlayerPrefs.GetInt("Fullscreen") == 0)
        {
            Full = false;
        }
        else
        {
            Full = true;
        }

        Screen.SetResolution(PlayerPrefs.GetInt("ScreenWidth"), PlayerPrefs.GetInt("ScreenHeight"), Full);

    }

    public void FullscreenIO()
    {
        if(PlayerPrefs.GetInt("Fullscreen") == 0)
        {
            PlayerPrefs.SetInt("Fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Fullscreen", 0);
        }
        ChangeResolution();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
