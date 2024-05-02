using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNetworkScript : MonoBehaviourPunCallbacks
{
    public GameObject localXRRigObject;




    void Start()
    {
        if (photonView.IsMine)
        {
            localXRRigObject.SetActive(true);


        }
        else
        {
            localXRRigObject.SetActive(false);

        }

    }
}
