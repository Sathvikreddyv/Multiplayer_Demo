using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ObjectManipulation : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 offset;
    private float distanceToCamera;
    private float yPosition;
    private bool isDragged;
    private bool isPressed = false;
    public float rotationRate;
    public LayerMask layerMask;
    private GameObject toRotate;

    public InputActionReference RightTriggerButtonAction;
    
    public GameObject rayInteractor;

    void Start()
    {
        yPosition = transform.position.y;
    }

    #region asset rotation
    void Update()
    {
        XRRayInteractor[] rayInteractors = GameObject.FindObjectsOfType<XRRayInteractor>();
        foreach (XRRayInteractor x in rayInteractors)
        {
            if(x.transform.parent.name.Contains("RightHand"))
            rayInteractor = GameObject.Find("Ray Interactor").gameObject;
        }
        

        //XR
        #region handling rotation and ray interaction through XR input(trigger Left/Right)
        if (RightTriggerButtonAction != null && RightTriggerButtonAction.action != null && RightTriggerButtonAction.action.triggered)
        {
            Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, layerMask))
            {
                if (photonView.IsMine || photonView.Owner == null)
                {
                   
                }
                else
                {
                    photonView.RequestOwnership();
                }
            }
        }
        #endregion

        //Desktop
        #region handling rotation and ray interaction through mouse input
        if (Input.GetMouseButtonDown(1)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (photonView.IsMine || photonView.Owner == null)
                {
                    toRotate = hit.collider.gameObject;
                    isPressed = true;
                }
                else
                {
                    photonView.RequestOwnership();
                }
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        }

        if(isPressed)
        {
            toRotate.transform.rotation = Quaternion.Euler(0, -Input.mousePosition.x * rotationRate, 0);
        }

        if(Input.GetMouseButtonUp(1))
        {
            isPressed= false;
        }
        #endregion
    }
    #endregion

    #region asset translation
    void OnMouseDown()
    {
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
        isDragged= true;
    }

    void OnMouseDrag()
    {
        if (isDragged && photonView.IsMine)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
    #endregion

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
