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
        
        transform.Translate(speed*Time.deltaTime);
//        transform.position+=speed;
    }

    // Update is called once per frame
  
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with box");
    

    }

    private void OnTriggerEnter(Collider other)
    {
        speed=new Vector3(0,-1,0);
    }
}
