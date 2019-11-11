using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool changedLight = false;
    private Color originalColor ;
    void Start()
    {
        light = GetComponent<Light>();
        originalColor = light.color;

    }

    public Light light;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)|| OVRInput.GetDown(OVRInput.Button.Two))

        {
            if (!changedLight)
            {
                light.color = new Color(255, 0, 0);
            }
            else
            {
                light.color = originalColor;

            }

            changedLight = !changedLight;

        }
    }
}
