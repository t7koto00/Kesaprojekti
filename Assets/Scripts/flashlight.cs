using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    private Light lt;
    AudioSource audioData;
    public AudioClip onSound;
    private double battery = 100;
    public Slider BatterySlider;

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
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("BatteryToggle") == 1)
        {
            BatterySlider.value = (float)battery;
            if (lt.enabled == true)
            {
                battery = battery - 0.1;
            }
            if (lt.enabled == false)
            {
                battery = battery + 0.075;
            }
            if (battery <= 0)
            {
                lt.enabled = false;
            }
            if (battery > 100)
            {
                battery = 100;
            }
        }
        
        //Debug.Log(battery);
    }
}
