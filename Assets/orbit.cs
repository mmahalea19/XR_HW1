using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class orbit : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.RotateAround(transform.parent.position, new Vector3(0, 1, 0), 2);
//    Debug.Log("ROtated");
        
    }
}
