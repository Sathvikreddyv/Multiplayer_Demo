using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CanvasChange : MonoBehaviour
{
    public GameObject DesktopCanvas;
    public GameObject XRCanvas;
    //public Transform canvasNewPos;
    // Start is called before the first frame update
    void Start()
    {
        if (XRSettings.isDeviceActive)
        {
            DesktopCanvas.SetActive(false);
            XRCanvas.SetActive(true);
        }
        else
        {
            DesktopCanvas.SetActive(true);
            XRCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
