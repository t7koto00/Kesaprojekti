using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trap : MonoBehaviour
{

    public GameObject guard;
    public float secondsTrappedFor = 3.0f;

    void Start()
    {
        guard = GameObject.Find("Guard");
    }
   
    void Update()
    {
        if ((transform.position - guard.transform.position).sqrMagnitude < 1 * 1)
        {
            guard.GetComponent<NavMeshAgent>().isStopped = true;

            secondsTrappedFor -= Time.deltaTime;

            if (secondsTrappedFor <= 0.0f)
            {
                gameObject.SetActive(false);
                guard.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }
        else
        {
            guard.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
