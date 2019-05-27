using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] target;
    public Transform player;
    public float speed;
    private int current;
    Light guardLight;
    
    void Start()
    {
        guardLight = GetComponent<Light>();
    }
    void Update()
    {
        InFront();
        HaveLineOfSight();
        if (InFront() && HaveLineOfSight())
        {
            guardLight.color = Color.red;
            Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

            Vector3 lookDir = pos - transform.position;
            lookDir.y = 0;

            transform.LookAt(transform.position + lookDir, Vector3.up);
        }
        else
        {
            guardLight.color = Color.white;

            if (transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
                Vector3 lookDir = pos - transform.position;
                lookDir.y = 0;

                transform.LookAt(transform.position + lookDir, Vector3.up);
            }
            else
            {
                current = (current + 1) % target.Length;
                //transform.Rotate(0, 90, 0);
            }
        }
       
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

        void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            Debug.Log("Collision with player");
        }
    }
}
