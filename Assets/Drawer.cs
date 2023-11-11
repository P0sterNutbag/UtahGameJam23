using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    bool isOpen = false;

    Vector2 originPosition;
    Vector2 openPosition;

    private void Start()
    {
        originPosition = transform.position;
        openPosition = new Vector2(0f, transform.position.y - 0.25f);
    }


    private void OnMouseDown()
    {
        Debug.Log("opened");
        if (isOpen)
        {
            transform.position = originPosition;
            isOpen = false;
        }
        else
        {
            transform.position = openPosition;
            isOpen = true;
        }
    }
}
