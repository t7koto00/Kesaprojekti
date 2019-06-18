using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip music;
    public GameObject Optionsmenu;
    public GameObject Mainmenu;
    //public AudioMixer mixer;
    //public Slider slider;
    //float volume = 100;

    void Start()
    {
        //slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        //slider.value = volume;
        //mixer.SetFloat("Master", volume);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.Play();
    }

    /*void FixedUpdate()
    {
        volume = slider.value;
        mixer.SetFloat("Master", volume);
        Debug.Log(volume);
    }*/

   /* public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        Debug.Log(sliderValue);
    }*/

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
