using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip music;
    public GameObject Optionsmenu;
    public GameObject Mainmenu;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.Play();
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
}
