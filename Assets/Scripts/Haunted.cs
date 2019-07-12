using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haunted : MonoBehaviour
{
    public static bool isHaunted;
    bool isSpooked;
    public Material hauntedMaterial;
    AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
     audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHaunted == true && isSpooked == false) {
        GameObject[] objs;

        objs = GameObject.FindGameObjectsWithTag("painting");
        foreach (GameObject ObjectFound in objs)
        {
            //Do something to ObjectFound, like this:
            ObjectFound.GetComponent<Renderer>().material = hauntedMaterial;
        }
            isSpooked = true;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
