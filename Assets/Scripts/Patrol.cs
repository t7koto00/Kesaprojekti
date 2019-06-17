using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    public Transform[] target;
    public Transform player;
    private int current;
    Light guardLight;
    NavMeshAgent agent;
    AudioSource audioSource;
    public AudioClip caught;
    public AudioClip spotted;
    private static bool playerSpotted;
    
    void Start()
    {
        guardLight = GetComponentInChildren<Light>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        InFront();
        HaveLineOfSight();
        if (InFront() && HaveLineOfSight())
        {
            playerSpotted = true;
            float t = Mathf.PingPong(Time.time, 0.7f) / 0.7f;
            guardLight.color = Color.Lerp(Color.red, Color.blue, t);
            Vector3 pos = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            agent.SetDestination(player.transform.position);
            Destroy(GameObject.Find("SoundTarget(Clone)"), 0);
            Vector3 lookDir = pos - transform.position;
            lookDir.y = 0;
            if (!audioSource.isPlaying) { 
            audioSource.clip = spotted;
            audioSource.Play();
            }

            transform.LookAt(transform.position + lookDir, Vector3.up);
        }
        else if(GameObject.Find("SoundTarget(Clone)") == true)
        {
            var sound = GameObject.Find("SoundTarget(Clone)");
            agent.SetDestination(sound.transform.position);
            if((transform.position - sound.transform.position).sqrMagnitude < 1 * 1)
            {
                Destroy(GameObject.Find("SoundTarget(Clone)"), 0);
            }
        }
        else
        {
            guardLight.color = Color.white;
            audioSource.Stop();
            playerSpotted = false;
            if ((transform.position - target[current].position).sqrMagnitude > 1 * 1)
            {
                agent.SetDestination(target[current].position);
            }
            else
            {
                current = (current + 1) % target.Length;
            }
        }
       
    }

    bool InFront()
    {

        Vector3 directiontoplayer = transform.position - player.transform.position;
        directiontoplayer.y = 0;
        float angle = Vector3.Angle(transform.forward, directiontoplayer);

        if (Mathf.Abs(angle) > 135 && Mathf.Abs(angle) < 225)
        {
            return true;
        }
        return false;
    }

    bool HaveLineOfSight()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;

        if(Physics.Raycast(transform.position, direction, out hit, 10))
        {
            if (hit.transform.CompareTag("Player")) {
                return true;
            }
        }
        return false;
    }

        void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            if (playerSpotted == true)
            {
                SceneManager.LoadSceneAsync("GameOver");
            }
            else
            {
                /*Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
              
                Vector3 lookDir = pos - transform.position;
                lookDir.y = 0;

                transform.LookAt(transform.position + lookDir, Vector3.up);*/
            }
        }
    }
}
