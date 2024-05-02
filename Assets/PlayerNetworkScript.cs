using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNetworkScript : MonoBehaviourPunCallbacks
{
    public GameObject localXRRigObject;
    public GameObject localInteractionManager;
    public GameObject localEventSystem;
    public GameObject inputActionManager;



    void Start()
    {
        if (photonView.IsMine)
        {
            localXRRigObject.SetActive(true);
            localInteractionManager.SetActive(true);
            localEventSystem.SetActive(true);
            //inputActionManager.SetActive(true);

        }
        else
        {
            localXRRigObject.SetActive(false);
            localInteractionManager.SetActive(false);
            localEventSystem.SetActive(false);
            //inputActionManager.SetActive(false);
        }

    }
}
