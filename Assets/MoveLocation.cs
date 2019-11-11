using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrBoardGame;
using UnityEngine;

public class MoveLocation : MonoBehaviour
{
    
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/
     
     
    float mainSpeed = 2.0f; //regular speed
    float shiftAdd = 2.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 10.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun= 1.0f;
public CharacterController control;

    void Start()
    {
        this.control=GetComponent<CharacterController>();
        toogle = false;
    }

    public bool toogle ;
    
    void checkOthers()
    {
        if (Input.GetKeyDown((KeyCode.Escape)))
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            toogle = !toogle;

            if (toogle)
            {
                var pos =     transform.position;
               
                
                Debug.Log("Here");
                pos.y -= 1;
                Debug.Log(pos);
                control.enabled = false;
                control.transform.position = new Vector3(0,2,0);
                control.enabled = true;
                // transform.position=new Vector3(0,2,0);


            }
            else
            {
                Debug.Log("Other here");
                Debug.Log(transform.position);
                control.enabled = false;
                control.transform.position = new Vector3(-20, 2, -20);
          
                //  transform.Translate(20, 0, 20,Space.Self);

            }
        }


        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, -1, 0);
        }
    }
    void Update()
    {
        checkOthers();

    }
    void oldMovement ()
    {

        lastMouse = Input.mousePosition - lastMouse ;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        control.transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;
        
        Vector3 pos;
     int speed;
     Vector3 normalizeDirection;
        
        pos = Input.mousePosition;
   
        pos = Camera.main.ScreenToWorldPoint(pos);
        normalizeDirection = (pos - transform.position).normalized;
        //Mouse  camera angle done.  
        //Keyboard commands
        float f = 0.0f;
        Vector3 p =  GetBaseInput();
        
        
      p = transform.TransformDirection(p);

        p = p * mainSpeed;
        
       
        p = p * Time.deltaTime;
        
        control.Move(p);



    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
