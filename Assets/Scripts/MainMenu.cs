using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject Optionsmenu;
    public GameObject Mainmenu;
    public GameObject batterySwitch;

    void Start()
    {
        PlayerPrefs.SetInt("BatteryToggle", 1);
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        Mainmenu.SetActive(false);
        Optionsmenu.SetActive(true);

    }

    public void BackToMenu()
    {
        Mainmenu.SetActive(true);
        Optionsmenu.SetActive(false);
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
