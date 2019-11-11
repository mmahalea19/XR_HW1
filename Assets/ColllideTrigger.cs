using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllideTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject cilindru=GameObject.Find("Cylinder");
        simpleCollision.speed=new Vector3(0,(float)-1,0);
        cilindru.GetComponent<Rigidbody>().isKinematic = false;
        cilindru.GetComponent<Rigidbody>().useGravity = true;
      

    }
 

  
}
