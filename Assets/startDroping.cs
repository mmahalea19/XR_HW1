using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDroping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame


    private bool toogle = true;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
     GameObject cylinder=GameObject.Find("Cylinder");
     cylinder.GetComponent<Rigidbody>().isKinematic = toogle;
     cylinder.GetComponent<Rigidbody>().useGravity = !toogle;
     toogle = !toogle;



    }
    void OnControllerColliderHit(ControllerColliderHit hit){
       Debug.Log("COllided with controller");
    }
}
