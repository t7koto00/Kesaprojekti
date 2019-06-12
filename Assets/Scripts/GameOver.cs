using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip caught;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = caught;
        audioSource.Play();
        Cursor.visible = true;
    }
    public void TryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
