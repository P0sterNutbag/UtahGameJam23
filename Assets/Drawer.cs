using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    bool isOpen = false;

    Vector2 originPosition;
    Vector2 openPosition;

    public List<GameObject> contents = new List<GameObject>();
    //public GameObject contents;


    private void Start()
    {
        originPosition = transform.position;
        openPosition = new Vector2(transform.position.x, transform.position.y - 0.25f);
        HideContents();
    }

    private void OnMouseDown()
    {
        if (isOpen)
        {
            HideContents();
            transform.position = originPosition;
            isOpen = false;
            Debug.Log("closed");
        }
        else
        {
            CreateContents();
            transform.position = openPosition;
            isOpen = true;
            Debug.Log("opened");
        }
    }

    private void CreateContents()
    {
        foreach (GameObject child in contents)
        {
            child.GetComponent<SpriteRenderer>().enabled = true;//SetActive(true);
        }
    }

    private void HideContents()
    {
        foreach (GameObject child in contents)
        {
            /*DrawerContent dc = child.GetComponent<DrawerContent>();
            if (dc != null && dc.inDrawer)*/
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
