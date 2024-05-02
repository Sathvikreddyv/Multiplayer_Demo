using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformChange : MonoBehaviour
{

    public Transform XRorigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = XRorigin.position;
    }
}
