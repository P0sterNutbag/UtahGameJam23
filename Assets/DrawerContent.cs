using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerContent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drawer"))
        {
            Drawer drawer = collision.transform.parent.GetComponent<Drawer>();
            if (!drawer.contents.Contains(gameObject)) 
                drawer.contents.Add(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drawer"))
        {
            Drawer drawer = collision.transform.parent.GetComponent<Drawer>();
            if (drawer.contents.Contains(gameObject))
                drawer.contents.Remove(gameObject);
        }
    }
}
