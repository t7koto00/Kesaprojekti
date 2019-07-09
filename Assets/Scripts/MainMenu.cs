using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject Optionsmenu;
    public GameObject Mainmenu;
    public GameObject LevelSelect;
    public GameObject batterySwitch;

    void Start()
    {
        //PlayerPrefs.SetInt("BatteryToggle", 1);
    }

    public void PlayGame()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        Mainmenu.SetActive(false);
        LevelSelect.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        Mainmenu.SetActive(false);
        Optionsmenu.SetActive(true);
        if (PlayerPrefs.GetInt("BatteryToggle") == 1)
        {
            batterySwitch.GetComponent<Text>().text = "ON";
        }
        else
        {
            batterySwitch.GetComponent<Text>().text = "OFF";
        }

    }

    public void BackToMenu()
    {
        Mainmenu.SetActive(true);
        Optionsmenu.SetActive(false);
        LevelSelect.SetActive(false);
    }

    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("#1 Museo");
    }

    public void Level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameSceneTonin");
    }

    public void Level3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("JokuMuseo");
    }


    public void ToggleFlashlightBattery()
    {
        if(PlayerPrefs.GetInt("BatteryToggle") == 1)
        {
            PlayerPrefs.SetInt("BatteryToggle", 0);
            batterySwitch.GetComponent<Text>().text = "OFF";
        }
        else
        {
            PlayerPrefs.SetInt("BatteryToggle", 1);
            batterySwitch.GetComponent<Text>().text = "ON";
        }
    }
}
