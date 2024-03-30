using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraManager : MonoBehaviour
{

    public GameObject godView;
    public GameObject flyCam;
    public GameObject XRcamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!string.IsNullOrEmpty(XRSettings.loadedDeviceName))
        {
            godView.SetActive(false);
            flyCam.SetActive(false);
            XRcamera.SetActive(true);
            Debug.Log("Running on VR device: " + XRSettings.loadedDeviceName);
        }
        else
        {
            XRcamera.SetActive(false);
            if (Input.GetKeyDown("1"))
            {
                godView.SetActive(true);
                flyCam.SetActive(false);
            }

            if (Input.GetKeyDown("2"))
            {
                godView.SetActive(false);
                flyCam.SetActive(true);
            }
        }
    }
}
