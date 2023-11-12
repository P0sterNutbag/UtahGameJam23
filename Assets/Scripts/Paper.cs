using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    List<GameObject> words = new List<GameObject>();

    [SerializeField]
    int whichSide; // 1 is dict, 0 is resistance??

    private List<string> finalPaper = new List<string>();

    private Envelope envelope;

    bool isInEnvelope = false;


    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            //Debug.Log("mouse up");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 0, LayerMask.GetMask("Container"));
            if (hit.collider != null)
            {
                envelope = hit.collider.gameObject.GetComponent<Envelope>();
                if (envelope != null && envelope.isOpen && envelope.GetComponent<SpriteRenderer>().enabled)
                {
                    //Debug.Log("close envelope");
                    envelope.Close();
                    // Score gameObject
                    Score();

                    for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
                    {
                        Object.Destroy(gameObject.transform.GetChild(i).gameObject);
                    }

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

    private void Score()
    {
        int i = 0;

        foreach (GameObject gameObject in words)
        {
            var word = gameObject.GetComponent<DropBox>();
            /*Debug.Log(word.oldWord);
            Debug.Log(word.newWord);*/
            if (word.newWord == "")
            {
                finalPaper.Add(word.oldWord);
            }
            else
            {
                finalPaper.Add(word.newWord);
            }
            print(finalPaper[i]);
            i++;
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
