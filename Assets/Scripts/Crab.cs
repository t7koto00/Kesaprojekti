using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    public static bool isPainted;
    AudioSource audioSource;
    public AudioClip audioClip;
    private bool raving = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPainted == true && raving == false)
        {
            raving = true;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
