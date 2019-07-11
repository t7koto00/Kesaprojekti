using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trap : MonoBehaviour
{

    //public GameObject guard;
    public float secondsTrappedFor = 3.0f;
    public bool droneTrapped = false;
    Animator animator;
    public GameObject lightning;
    AudioSource audioSource;
    public AudioClip shockAudio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   
    void Update()
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("guard");
        foreach (GameObject target in guards)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < 1.1)
            {
                if (target.GetComponent<NavMeshAgent>() != null)
                {
                    target.GetComponent<NavMeshAgent>().isStopped = true;
                    droneTrapped = true;
                    animator = target.GetComponent<Animator>();
                    animator.SetBool("droneTrapped", droneTrapped);
                    target.transform.GetChild(2).gameObject.SetActive(true);
                    target.GetComponentInChildren<Light>().enabled = false;
                    lightning.SetActive(true);
                    if (!audioSource.isPlaying)
                    {
                        audioSource.clip = shockAudio;
                        audioSource.Play();
                    }
                }

                secondsTrappedFor -= Time.deltaTime;

                if (secondsTrappedFor <= 0.0f)
                {
                    GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.TopDownController>().trapsUsed++;
                    Destroy(gameObject, 0);
                    if (target.GetComponent<NavMeshAgent>() != null)
                    {
                        droneTrapped = false;
                        animator = target.GetComponent<Animator>();
                        animator.SetBool("droneTrapped", droneTrapped);
                        target.GetComponent<NavMeshAgent>().isStopped = false;
                        target.transform.GetChild(2).gameObject.SetActive(false);
                        target.GetComponentInChildren<Light>().enabled = true;
                    }
                }
            }
            else
            {
                if (target.GetComponent<NavMeshAgent>() != null)
                {
                    target.GetComponent<NavMeshAgent>().isStopped = false;
                    droneTrapped = false;
                    animator = target.GetComponent<Animator>();
                    animator.SetBool("droneTrapped", droneTrapped);
                    target.transform.GetChild(2).gameObject.SetActive(false);
                    target.GetComponentInChildren<Light>().enabled = true;
                }
                
            }
        }
    }
}
