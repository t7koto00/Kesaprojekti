using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    Rigidbody rigidBody;
    Camera cam;
    public float speed = 5;
    public float sprintSpeed = 8;
    public double stamina;
    private double staminaStart;
    Vector3 lookPos;
    bool playing = false;
    AudioSource audioSource;
    AudioSource walkingAudio;
    public AudioClip outOfBreath;
    Vector3 movement;
    public AudioClip walkingSound;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        staminaStart = stamina - 0.5;
        AudioSource[] audios = GetComponents<AudioSource>();
        audioSource = audios[0];
        walkingAudio = audios[2];
       
    }
    
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            if (stamina <= 0)
            {
                stamina = 0;
                rigidBody.velocity = movement * speed;
                if (playing != true)
                {
                    audioSource.clip = outOfBreath;
                    audioSource.Play();
                    playing = true;
                }
            }
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (!audioSource.isPlaying)
                { playing = false; }
                rigidBody.velocity = movement * sprintSpeed;
                stamina = stamina - 1;
            }
        }
        else
        {
            rigidBody.velocity = movement * speed;
            if (stamina <= staminaStart)
            {
                stamina = stamina + 0.5;
            }
        }
        Debug.Log(stamina);
       
       
    }

 
}
