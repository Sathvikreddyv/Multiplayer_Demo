using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnableCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(XRSettings.isDeviceActive)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
