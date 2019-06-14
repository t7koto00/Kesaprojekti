using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip victory;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = victory;
        audioSource.Play();
        Cursor.visible = true;
    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
