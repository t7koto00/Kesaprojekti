using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    private Light lt;
    AudioSource audioData;
    public AudioClip onSound;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponentInChildren<Light>();
        AudioSource[] audios = GetComponents<AudioSource>();
        audioData = audios[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lt.enabled = !lt.enabled;
            audioData.clip = onSound;
            audioData.Play();
        }
    }
}
