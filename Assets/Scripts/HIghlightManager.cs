using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HIghlightManager : MonoBehaviourPun
{
    private GameObject HiglightBound;
    public  GameObject HighlightAsset;
    public LayerMask layerMask;
    private bool CheckInstantiate = true;

    //VR ray
    public XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        if(CheckInstantiate)
        {
            HiglightBound = PhotonNetwork.Instantiate(HighlightAsset.name, HighlightAsset.transform.position, Quaternion.identity);
            CheckInstantiate = false;
        }

        if (XRSettings.isDeviceActive)
        {
            ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
        }
        else
        {
           ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            //HiglightBound.SetActive(true);
            float x = (hit.collider.bounds.size.x) / 4;
            float y = (hit.collider.bounds.size.y) / 4;
            float z = (hit.collider.bounds.size.z) / 4;

            HiglightBound.transform.position = hit.collider.gameObject.transform.position;
            HiglightBound.transform.localScale = new Vector3(x, y, z);
            Debug.Log(hit.collider.gameObject.name);
        } 
        else
        {
            HiglightBound.transform.position = new Vector3(0, -60, 0);
            //HiglightBound.SetActive(false);
        }

    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        // Send flag indicating if the highlight object is active
    //        stream.SendNext(HiglightBound.activeSelf);
    //    }
    //    else
    //    {
    //        // Receive flag and update highlight object's visibility
    //        bool isActive = (bool)stream.ReceiveNext();
    //        if (HiglightBound != null)
    //        {
    //            HiglightBound.SetActive(isActive);
    //        }
    //    }
    //}
}
