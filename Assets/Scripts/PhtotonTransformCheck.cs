using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhtotonTransformCheck : MonoBehaviourPun
{

    public ObjectManipulation objectManipulate;

    // Start is called before the first frame update
    void Start()
    {
        //if(!photonView.IsMine)
        //{
        //    gameObject.GetComponent<ObjectManipulation>().enabled = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if(!photonView.IsMine)
        //{
        //    transform.position = objectManipulate.latestPos;
        //    transform.rotation = objectManipulate.latestRot;
        //}
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // If this client owns the object, send its position and rotation to other clients
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            //// If this client doesn't own the object, receive its position and rotation from the owner
            //objectManipulate.latestPos = (Vector3)stream.ReceiveNext();
            // objectManipulate.latestRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
