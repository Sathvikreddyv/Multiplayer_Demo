using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCameraMov : MonoBehaviour
{
    // Start is called before the first frame update
    public bool KeyCheck = false;
    public int Counter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            if(KeyCheck == true) 
            { 
                gameObject.GetComponent<FreeFlyCamera>().enabled = true;
                KeyCheck= false;
            }
            if(KeyCheck == false)
            {
                gameObject.GetComponent<FreeFlyCamera>().enabled = false;
                KeyCheck = true;
            }
        
        }        
    }
}
