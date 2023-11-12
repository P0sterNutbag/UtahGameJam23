using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    
    public string wordValue;
    public string wordType;
    public int score;
    private DropBox currDropBox;
    public TextMeshPro textMesh;

    private BoxCollider2D currBoxCollider;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "DropBox")
            {
                GameObject currGameObject = collision.gameObject;
                currBoxCollider = currGameObject.GetComponent<BoxCollider2D>();
                currDropBox = currGameObject.GetComponent<DropBox>();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            if (collision.tag == "DropBox" && !gameObject.GetComponent<BoxCollider2D>().IsTouching(currBoxCollider) && currDropBox != null)
            {
                currDropBox.updateNewWord(wordValue, 0, false);
                currDropBox = null;
            }
 
    }

    private void OnMouseUp()
    {
        if (currDropBox != null)
        {
            transform.position = currDropBox.transform.position;
            currDropBox.updateNewWord(wordValue, score, true);
            // UPDATE PAPER
        }
    }
}
