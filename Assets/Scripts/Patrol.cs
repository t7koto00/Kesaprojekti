using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] target;
    public Transform player;
    public float speed;
    private int current;
    Light light;
    
    void Start()
    {
        light = GetComponent<Light>();
    }
    void Update()
    {
        InFront();
        HaveLineOfSight();
        if(InFront() && HaveLineOfSight())
        {
            light.color = Color.red;
        }
        else { light.color = Color.white; }
        //else
        //{
            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                current = (current + 1) % target.Length;
                transform.Rotate(0, 90, 0);
            }
        //}
       
    }

    bool InFront()
    {

        Vector3 directiontoplayer = transform.position - player.position;
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
        Vector3 direction = player.position - transform.position;

        if(Physics.Raycast(transform.position, direction, out hit, 10))
        {
            if (hit.transform.CompareTag("Player")) {
                return true;
            }
        }
        return false;
    }
}
