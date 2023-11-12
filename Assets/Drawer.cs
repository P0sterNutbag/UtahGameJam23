using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
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

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
<<<<<<< Updated upstream
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePos);
        }
=======
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject != null)
            {

            }
        }*/
>>>>>>> Stashed changes
    }

    private void OnMouseDown()
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
    }

    private void CreateContents()
    {
        foreach (GameObject child in contents)
        {
            child.GetComponent<SpriteRenderer>().enabled = true;//SetActive(true);
            /*foreach (Transform c in child.transform)
            {
                TextMeshPro text = c.GetComponent<TextMeshPro>();
                if (text != null)
                    text.enabled = true;
            }*/
        }
    }

    private void HideContents()
    {
        foreach (GameObject child in contents)
        {
            /*DrawerContent dc = child.GetComponent<DrawerContent>();
            if (dc != null && dc.inDrawer)*/
            child.GetComponent<SpriteRenderer>().enabled = false;
            /*foreach (Transform c in child.transform)
            {
                TextMeshPro text = c.GetComponent<TextMeshPro>();
                if (text != null)
                    text.enabled = false;
            }*/
        }
    }
}
