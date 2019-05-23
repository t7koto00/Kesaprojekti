using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItems : MonoBehaviour
{
    public float speed = 10;
    public bool canHold = true;
    public GameObject cube;
    public Transform guide;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!canHold)
                throw_drop();
            else
                Pickup();
        }

        if (!canHold && cube)
            cube.transform.position = guide.position;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "cube")
            if (!cube) 
                cube = col.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "cube")
        {
            if (canHold)
                cube = null;
        }
    }


    private void Pickup()
    {
        if (!cube)
            return;

        cube.transform.SetParent(guide);

        cube.GetComponent<Rigidbody>().useGravity = false;

        cube.transform.localRotation = transform.rotation;
        cube.transform.position = guide.position;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!cube)
            return;

        cube.GetComponent<Rigidbody>().useGravity = true;
        cube = null;
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        cube = guide.GetChild(0).gameObject;
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}