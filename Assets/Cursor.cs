using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Cursor : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero, 0, LayerMask.GetMask("Interactable"));
            foreach (RaycastHit2D hit in hits)
            {
                Drawer drawer = hit.collider.gameObject.GetComponent<Drawer>();
                if (drawer != null)
                {
                    if (drawer.isOpen)
                    {
                        drawer.HideContents();
                        Debug.Log("close");
                        return;
                    }
                    else
                    {
                        drawer.CreateContents();
                        Debug.Log("open");
                        return;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits2 = Physics2D.RaycastAll(mousePosition, Vector2.zero, 0);
            foreach (RaycastHit2D hit in hits2)
            {
                GrabableObject grabable = hit.collider.gameObject.GetComponent<GrabableObject>();
                if (grabable != null)
                {
                    if (!grabable.isDragging)
                    {
                        grabable.isDragging = true;
                        return;
                    }
                }
            }
        }
    }
}
