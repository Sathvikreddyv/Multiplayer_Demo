using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonChecker : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        FreeFlyCamera _freeFly = this.gameObject.GetComponent<FreeFlyCamera>();

        if(_freeFly != null)
        {
            if(photonView.IsMine)
            {
                _freeFly.enabled = true;
                this.transform.name = "Player";
            }

            else
            {
                this.GetComponent<Camera>().enabled = false;
            }
        }
        else
        {
            Debug.Log("you messed up!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
