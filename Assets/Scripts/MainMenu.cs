using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject Optionsmenu;
    public GameObject Mainmenu;

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
}
