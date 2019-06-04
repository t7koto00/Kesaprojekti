using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Trap : MonoBehaviour
{

    public GameObject guard;
    bool timerStarted = false;
    public float targetTime = 3.0f;

    void Start()
    {
        
    }
   
    void Update()
    {
        if ((transform.position - guard.transform.position).sqrMagnitude < 1 * 1)
        {
            guard.GetComponent<NavMeshAgent>().isStopped = true;

            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                gameObject.SetActive(false);
                guard.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }
    }
}
