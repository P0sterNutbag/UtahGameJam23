using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    private Camera camMain;

    [HideInInspector] public bool isDragging = false;


    private void Awake()
    {
        camMain = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            if (isDragging)
            {
                isDragging = false;
            }
        }    
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos(); //Vector3.MoveTowards(transform.position, GetMousePos(), speed * Time.deltaTime);
        isDragging = true;
    }

    Vector3 GetMousePos()
    {
        var mousePos = camMain.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
