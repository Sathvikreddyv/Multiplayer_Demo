using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Remover : MonoBehaviourPun
{

    public GameObject selectedAsset;

    public ObjectPlacement objectPlacement;


    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                selectedAsset = hit.collider.gameObject;
                Debug.Log(selectedAsset.name);
            }
        }
    }

    public void Remove()
    {
        Debug.Log(selectedAsset.name);
        if (selectedAsset.tag != "ground")
        {
            for(int i = 0; i<21; i++)
            {
                if(selectedAsset.tag == objectPlacement.button[i].tag)
                {
                    PhotonNetwork.Destroy(selectedAsset);
                    Debug.Log("removed" + selectedAsset.name);
                    objectPlacement.button[i].GetComponent<assetCounter>().Counter++;
                    objectPlacement.button[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = objectPlacement.button[i].GetComponent<assetCounter>().Counter.ToString();
                }
            }
        }
    }
}
