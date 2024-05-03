using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class RemoverXR : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject selectedAsset;
    public ObjectPlacementXR objectPlacement;
    public LayerMask layerMask;

    public InputActionReference PrimaryButtonAction;
    public XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
        RaycastHit hit;

        if (PrimaryButtonAction != null && PrimaryButtonAction.action != null && PrimaryButtonAction.action.triggered)
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
            Debug.Log(selectedAsset.tag);
            for (int i = 0; i < 21; i++)
            {
                if (selectedAsset.tag == objectPlacement.button[i].tag)
                {
                    if (photonView.IsMine)
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

    [System.Obsolete]
    public void RotateObject()
    {
        Debug.Log(selectedAsset.name);
        if (selectedAsset.tag != "ground")
        {
            Debug.Log(selectedAsset.transform.rotation.y);
            selectedAsset.transform.RotateAroundLocal(new Vector3(0,1,0), 30.0f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // This client owns this object: send the others our data
            stream.SendNext(selectedAsset.transform);
        }
        else
        {
            // Network player, receive data
            selectedAsset.transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}
