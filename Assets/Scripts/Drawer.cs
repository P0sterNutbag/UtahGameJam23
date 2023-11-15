using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public bool isOpen = false;

    public Vector2 originPosition;
    public Vector2 openPosition;

    public List<GameObject> contents = new List<GameObject>();
    //public GameObject contents;


    private void Start()
    {
        originPosition = transform.position;
        openPosition = new Vector2(transform.position.x, transform.position.y - 0.3f);
        HideContents();
    }

    /*private void OnMouseDown()
    {
        if (isOpen)
        {
            HideContents();
            transform.position = originPosition;
            isOpen = false;
        }
        else
        {
            CreateContents();
            transform.position = openPosition;
            isOpen = true;
        }
    }*/

    public void CreateContents()
    {
        transform.position = openPosition;
        isOpen = true;
        foreach (GameObject child in contents)
        {
            child.GetComponent<SpriteRenderer>().enabled = true;//SetActive(true);
        }
    }

    public void HideContents()
    {
        transform.position = originPosition;
        isOpen = false;
        foreach (GameObject child in contents)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
