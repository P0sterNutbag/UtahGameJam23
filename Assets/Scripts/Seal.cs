using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Seal : MonoBehaviour
{
    public Envelope envelope;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            GrabableObject grabable = collision.gameObject.GetComponent<GrabableObject>();
            if (grabable != null && grabable.isDragging) 
                envelope.Open();
        }
    }
}
