using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    private Camera camMain;
    private int speed = 10;

    private void Awake()
    {
        camMain = Camera.main;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos(); //Vector3.MoveTowards(transform.position, GetMousePos(), speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = camMain.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
