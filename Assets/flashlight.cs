﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    private Light lt;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lt.enabled = !lt.enabled;
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }
}
