using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshoot : MonoBehaviour
{
      
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Debug.Log("1");
            ScreenCapture.CaptureScreenshot("Screenshot.png",100000000);
            Debug.Log("2");
        }
        
    }
    
}
