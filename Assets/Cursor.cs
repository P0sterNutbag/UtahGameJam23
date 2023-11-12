using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
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
                Debug.Log(hit.collider.gameObject.name);
                Drawer drawer = hit.collider.gameObject.GetComponent<Drawer>();
                if (drawer != null)
                {
                    if (drawer.isOpen)
                    {
                        drawer.HideContents();
                        Debug.Log("close");
                    }
                    else
                    {
                        drawer.CreateContents();
                        Debug.Log("open");
                    }
                }
            }
        }
    }
}
