using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIghlightManager : MonoBehaviour
{
    public GameObject HiglightBound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag != "ground" && hit.collider.gameObject != null && hit.collider.gameObject.tag != null)
            {
                float x = (hit.collider.bounds.size.x)/4;
                float y = (hit.collider.bounds.size.y)/4;
                float z = (hit.collider.bounds.size.z)/4;

                HiglightBound.transform.position = hit.collider.gameObject.transform.position;
                HiglightBound.transform.localScale = new Vector3(x, y, z);
            }
        }
    }
}
