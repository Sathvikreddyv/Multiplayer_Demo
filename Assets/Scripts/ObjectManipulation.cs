using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    private Vector3 offset;
    private float distanceToCamera;
    private float yPosition;
    private bool isDragged;
    private bool isRotated;
    private bool isPressed = false;
    public float rotationRate;
    private float yRotation;
    public LayerMask layerMask;
    private GameObject toRotate;


    void Start()
    {
        yPosition = transform.position.y;
    }

    #region asset rotation
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                toRotate = hit.collider.gameObject;
                isPressed= true;
            }
        }

        if(isPressed)
        {
            toRotate.transform.rotation = Quaternion.Euler(0, -Input.mousePosition.x * rotationRate, 0);
        }

        if(Input.GetMouseButtonUp(1))
        {
            isPressed= false;
        }
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
        if (isDragged)
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
}
