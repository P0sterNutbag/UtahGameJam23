using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    List<DropBox> words = new List<DropBox>();

    private List<string> finalPaper = new List<string>();

    private Envelope envelope;

    bool isInEnvelope = false;


    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("mouse up");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, LayerMask.GetMask("Container"));
            if (hit.collider != null)
            {
                envelope = hit.collider.gameObject.GetComponent<Envelope>();
                if (envelope != null && envelope.isOpen && envelope.GetComponent<SpriteRenderer>().enabled)
                {
                    Debug.Log("close envelope");
                    envelope.Close();
                    Destroy(gameObject);
                }
            }
            /*if (envelope != null && envelope.isOpen && isInEnvelope)
            {
                Debug.Log("close envelope");
                envelope.Close();
                Destroy(envelope.gameObject);
            }*/
        }
    }

    private void Send()
    {

        foreach (DropBox word in words)
        {
            if (word.newWord == null)
            {
                finalPaper.Add(word.oldWord);
            }
            else
            {
                finalPaper.Add(word.newWord);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        envelope = collision.gameObject.GetComponent<Envelope>();
        isInEnvelope = true;
        Debug.Log(isInEnvelope);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isInEnvelope = false;
        Debug.Log(isInEnvelope);
    }

}
