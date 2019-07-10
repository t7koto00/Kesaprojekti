using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trap : MonoBehaviour
{

    //public GameObject guard;
    public float secondsTrappedFor = 3.0f;

    void Start()
    {
        //guard = GameObject.Find("Guard");
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
                }

                secondsTrappedFor -= Time.deltaTime;

                if (secondsTrappedFor <= 0.0f)
                {
                    GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.TopDownController>().trapsUsed++;
                    Destroy(gameObject, 0);
                    if (target.GetComponent<NavMeshAgent>() != null)
                    {
                        target.GetComponent<NavMeshAgent>().isStopped = false;
                    }
                }
            }
            else
            {
                if (target.GetComponent<NavMeshAgent>() != null)
                {
                    target.GetComponent<NavMeshAgent>().isStopped = false;
                }
                
            }
        }
    }
}
