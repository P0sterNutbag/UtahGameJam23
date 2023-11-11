using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField]
    string wordValue;

    [SerializeField]
    string wordType;

    private DropBox currDropBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "DropBox")
            {
                GameObject currGameObject = collision.gameObject;
                currDropBox = currGameObject.GetComponent<DropBox>();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            if (collision.tag == "DropBox")
            {
                currDropBox.updateNewWord(wordValue, true);
                currDropBox = null;
            }
 
    }

    private void OnMouseUp()
    {
        if (currDropBox != null)
        {
            transform.position = currDropBox.transform.position;
            currDropBox.updateNewWord(wordValue, true);
            // UPDATE PAPER
        }
    }
}
