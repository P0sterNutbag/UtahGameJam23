using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{

    private Camera camMain;
    private SpriteRenderer spriteRenderer;
    private int previousSorting;

    [HideInInspector] public bool isDragging = false;

    Vector3 offset;


    private void Awake()
    {
        camMain = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousSorting = GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            if (isDragging)
            {
                isDragging = false;
                spriteRenderer.sortingOrder = previousSorting;
            }
        }    
        if (Input.GetButtonDown("Fire1"))
        {
            offset = transform.position - GetMousePos();
        }
        if (isDragging)
        {
            transform.position = GetMousePos() + offset;
            spriteRenderer.sortingOrder = 9;
        }
    }

    /*private void OnMouseDrag()
    {
        transform.position = GetMousePos() + offset; //Vector3.MoveTowards(transform.position, GetMousePos(), speed * Time.deltaTime);
        isDragging = true;
        spriteRenderer.sortingOrder = 9;
    }*/

    Vector3 GetMousePos()
    {
        var mousePos = camMain.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    Vector3 GetMouseOffset()
    {
        var mousePos = camMain.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 offset = mousePos - transform.position;
        return offset;
    }
}
