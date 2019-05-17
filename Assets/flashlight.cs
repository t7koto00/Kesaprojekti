using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class flashlight : NetworkBehaviour
{
    private Light lt;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
            {
                // exit from update if this is not the local player
                return;
            }
            lt.enabled = !lt.enabled;
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }
}
