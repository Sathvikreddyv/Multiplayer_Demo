using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodView : MonoBehaviour
{
    [SerializeField]
    private bool _enableTranslation = true;

    [SerializeField]
    private float _translationSpeed = 55f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enableTranslation)
        {
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * Time.deltaTime * _translationSpeed);
        }
    }
}
