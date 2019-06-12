﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UnityStandardAssets.Characters.FirstPerson
{

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
        public AudioClip[] walkingSound;
        private double m_StepCycle;
        private double m_NextStep;
        public Slider staminaSlider;
        public Image crosshair;
        public Camera mainCamera;
        public GameObject fpCamera;
        Camera FpsCamera;
        [SerializeField] private MouseLook m_MouseLook;
        public GameObject trapPrefab;
        public static bool test = false;


        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            cam = GetComponentInChildren<Camera>();
            staminaStart = stamina - 0.5;
            AudioSource[] audios = GetComponents<AudioSource>();
            audioSource = audios[0];
            walkingAudio = audios[2];
            m_StepCycle = 0f;
            m_NextStep = m_StepCycle / 2f;
            mainCamera.enabled = true;
            FpsCamera = fpCamera.GetComponentInChildren<Camera>();
            FpsCamera.enabled = false;
            QualitySettings.vSyncCount = 0;
            //Application.targetFrameRate = 40;
            m_MouseLook.Init(transform, fpCamera.transform);
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                test = true;
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                mainCamera.enabled = !mainCamera.enabled;
                FpsCamera.enabled = !FpsCamera.enabled;

                m_MouseLook.Init(transform, fpCamera.transform);

            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                lookPos = hit.point;
            }

            Vector3 lookDir = lookPos - transform.position;
            lookDir.y = 0;

            if (mainCamera.enabled == true)
            {
                GameObject.Find("FPCamera").GetComponent<PaintExample>().enabled = false;
                GameObject.Find("FPCamera").GetComponent<AudioSource>().enabled = false;
                m_MouseLook.SetCursorLock(false);
                Cursor.visible = true;
                crosshair.enabled = false;
                transform.LookAt(transform.position + lookDir, Vector3.up);
            }
            else if(FpsCamera.enabled == true)
            {
                RotateView();
            }
        
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameObject.Find("Trap(Clone)") == false)
                { 
                    Instantiate(trapPrefab, transform.position + (transform.forward * 2), transform.rotation);
                }
                else
                {
                    Destroy(GameObject.Find("Trap(Clone)"), 0);
                    Instantiate(trapPrefab, transform.position + (transform.forward * 2), transform.rotation);
                }
            }
    }

        void FixedUpdate()
        {
            if (mainCamera.enabled == false)
            {
                if (stamina <= staminaStart)
                {
                    stamina = stamina + 0.5;
                    staminaSlider.value = (float)stamina;
                }
                return;
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            movement = new Vector3(horizontal, 0, vertical);

            if (Input.GetKey(KeyCode.LeftShift))
            {

                if (stamina <= 0)
                {
                    stamina = 0;
                    staminaSlider.value = (float)stamina;
                    ProgressStepCycle(speed);
                    rigidBody.velocity = movement * speed;

                    if (playing != true)
                    {
                        audioSource.clip = outOfBreath;
                        audioSource.Play();
                        playing = true;
                    }
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    test = true;
                    if (!audioSource.isPlaying)
                    { playing = false; }
                    ProgressStepCycle(sprintSpeed);
                    rigidBody.velocity = movement * sprintSpeed;
                    stamina = stamina - 1;
                    staminaSlider.value = (float)stamina;
                }
            }
            else
            {
                test = false;
                rigidBody.velocity = movement * speed;
                ProgressStepCycle(speed);


                if (stamina <= staminaStart)
                {
                    stamina = stamina + 0.5;
                    staminaSlider.value = (float)stamina;
                }
            }

        }

        private void ProgressStepCycle(float speed)
        {
            if (rigidBody.velocity.sqrMagnitude > 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                bool m_IsWalking = !Input.GetKey(KeyCode.LeftShift);
                m_StepCycle += (rigidBody.velocity.magnitude + (speed * (m_IsWalking ? 1f : 0.7))) *
                             Time.fixedDeltaTime;
            }

            if (!(m_StepCycle > m_NextStep))
            {
                return;
            }

            m_NextStep = m_StepCycle + 5;

            PlayFootStepAudio();
        }
        private void PlayFootStepAudio()
        {

            // pick & play a random footstep sound from the array,
            // excluding sound at index 0
            int n = Random.Range(1, walkingSound.Length);
            walkingAudio.clip = walkingSound[n];
            walkingAudio.PlayOneShot(walkingAudio.clip);
            // move picked sound to index 0 so it's not picked next time
            walkingSound[n] = walkingSound[0];
            walkingSound[0] = walkingAudio.clip;
        }

        private void RotateView()
        {
            GameObject.Find("FPCamera").GetComponent<PaintExample>().enabled = true;
            GameObject.Find("FPCamera").GetComponent<AudioSource>().enabled = true;
            //m_MouseLook.SetCursorLock(true);
            Cursor.visible = false;
            crosshair.enabled = true;
            m_MouseLook.LookRotation(transform, FpsCamera.transform);
        }

    }
}
