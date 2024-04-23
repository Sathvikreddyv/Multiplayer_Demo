using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Photon.Pun;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ObjectPlacementXR : MonoBehaviour
{

    [SerializeField]
    private GameObject assetPrefab = null;

    public Button[] button;

    private GameObject[] placedObjects;

    private string Tag;

    public bool counterCheck = false;
    public int counter;

    public TextMeshProUGUI Assetcounter;

    public LayerMask layermask;

    //public ActionBasedController xrController;
    public InputActionReference PrimaryButtonAction;
    public XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    #region buttons
    void Start()
    {
        button[0].onClick.AddListener(delegate { AssignAsset(button[0].tag, button[0].GetComponent<assetCounter>().Counter); });
        button[1].onClick.AddListener(delegate { AssignAsset(button[1].tag, button[1].GetComponent<assetCounter>().Counter); });
        button[2].onClick.AddListener(delegate { AssignAsset(button[2].tag, button[2].GetComponent<assetCounter>().Counter); });
        button[3].onClick.AddListener(delegate { AssignAsset(button[3].tag, button[3].GetComponent<assetCounter>().Counter); });
        button[4].onClick.AddListener(delegate { AssignAsset(button[4].tag, button[4].GetComponent<assetCounter>().Counter); });
        button[5].onClick.AddListener(delegate { AssignAsset(button[5].tag, button[5].GetComponent<assetCounter>().Counter); });
        button[6].onClick.AddListener(delegate { AssignAsset(button[6].tag, button[6].GetComponent<assetCounter>().Counter); });
        button[7].onClick.AddListener(delegate { AssignAsset(button[7].tag, button[7].GetComponent<assetCounter>().Counter); });
        button[8].onClick.AddListener(delegate { AssignAsset(button[8].tag, button[8].GetComponent<assetCounter>().Counter); });
        button[9].onClick.AddListener(delegate { AssignAsset(button[9].tag, button[9].GetComponent<assetCounter>().Counter); });
        button[10].onClick.AddListener(delegate { AssignAsset(button[10].tag, button[10].GetComponent<assetCounter>().Counter); });
        button[11].onClick.AddListener(delegate { AssignAsset(button[11].tag, button[11].GetComponent<assetCounter>().Counter); });
        button[12].onClick.AddListener(delegate { AssignAsset(button[12].tag, button[12].GetComponent<assetCounter>().Counter); });
        button[13].onClick.AddListener(delegate { AssignAsset(button[13].tag, button[13].GetComponent<assetCounter>().Counter); });
        button[14].onClick.AddListener(delegate { AssignAsset(button[14].tag, button[14].GetComponent<assetCounter>().Counter); });
        button[15].onClick.AddListener(delegate { AssignAsset(button[15].tag, button[15].GetComponent<assetCounter>().Counter); });
        button[16].onClick.AddListener(delegate { AssignAsset(button[16].tag, button[16].GetComponent<assetCounter>().Counter); });
        button[17].onClick.AddListener(delegate { AssignAsset(button[17].tag, button[17].GetComponent<assetCounter>().Counter); });
        button[18].onClick.AddListener(delegate { AssignAsset(button[18].tag, button[18].GetComponent<assetCounter>().Counter); });
        button[19].onClick.AddListener(delegate { AssignAsset(button[19].tag, button[19].GetComponent<assetCounter>().Counter); });
    }

    #endregion

    #region checks for asset placement every frame
    void Update()
    {
        assetSpawner();
    }
    #endregion

    #region assign/select prefab/asset
    public void AssignAsset(string tag, int counter)
    {
        if (counter != 0)
        {
            Debug.Log(counter);
            assetPrefab = GameObject.FindWithTag(tag);
            Debug.Log(assetPrefab + " selected");
            if (assetPrefab == null)
            {
                Debug.Log("not found");
            }

            // placedObjects.Append<GameObject>(assetPrefab);
        }
    }
    #endregion

    #region asset placement and counter
    private void assetSpawner()
    {
        if (PrimaryButtonAction != null && PrimaryButtonAction.action != null && PrimaryButtonAction.action.triggered)
        {
            Ray ray = new Ray(rayInteractor.transform.position, rayInteractor.transform.forward);
            RaycastHit hit;
            Vector3 postion;
            Debug.Log("HIT");
            if (Physics.Raycast(ray, out hit, layermask))
            {
                //+assetPrefab.transform.position.y
                postion = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                for (int i = 0; i < 20; i++)
                {
                    if (assetPrefab.tag == button[i].tag)
                    {
                        if (button[i].GetComponent<assetCounter>().Counter <= 0)
                        {
                            assetPrefab = null;
                            Debug.Log("asset placed");
                            break;
                        }

                        PhotonNetwork.Instantiate(assetPrefab.name, postion, Quaternion.identity);
                        assetPrefab = null;
                        button[i].GetComponent<assetCounter>().Counter -= 1;
                        Debug.Log("TEXT" + button[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text);
                        button[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = button[i].GetComponent<assetCounter>().Counter.ToString();
                    }
                }
            }
        }
    }
    #endregion
}
