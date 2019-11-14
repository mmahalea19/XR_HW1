using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        speed = Vector3.zero;
    }
    
    public static Vector3 speed=new Vector3(0,0,0);
    void Update()
    {
        
       // transform.Translate(speed*Time.deltaTime);
//        transform.position+=speed;
    }

    // Update is called once per frame
  
    void OnCollisionEnter(Collision collision)
    {
        
   

    }

    public bool collided = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!collided)
        {
            Debug.Log("Triggered");
            Rigidbody body = GameObject.Find("Cylinder").AddComponent<Rigidbody>();
            body.mass = 1;
            body.useGravity = true;
            collided = true;
        }

    }
}
