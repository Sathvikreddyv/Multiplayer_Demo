using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Photon.Pun;

public class ObjectManipulationXR : MonoBehaviour
{
    public InputActionReference triggerButton;
    public XRRayInteractor rayInteractor;
    public GameObject RightHandController;
    public LayerMask layerMask;
    //GameObject grabbedObject;
    public GameObject rayEndPoint;
    public PhotonView photonView;

    bool ObjectSelected;

    // Start is called before the first frame update
    void Start()
    {
        //rayEndPoint.transform.SetParent(rayInteractor.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerButton.action.triggered && triggerButton.action != null)
        {   
            Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (photonView.IsMine || photonView.Owner == null)
                {
                    return;
                }
                else
                {
                    photonView.RequestOwnership();
                }
            }
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // This client owns this object: send the others our data
            stream.SendNext(transform.position);
        }
        else
        {
            // Network player, receive data
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }

    public void OnOwnershipRequest(PhotonView targetView, Photon.Realtime.Player requestingPlayer)
    {
        if (targetView != photonView) return;

        // You can add more logic here to decide if you want to transfer ownership
        photonView.TransferOwnership(requestingPlayer);
    }
}
