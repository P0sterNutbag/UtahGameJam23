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
                if (currDropBox != null)
                {
                    currDropBox.updateNewWord("", 0, false);
                    currDropBox = null;
                }
                GameObject currGameObject = collision.gameObject;
                currDropBox = currGameObject.GetComponent<DropBox>();
                if (wordType == currDropBox.type)
                {
                    currBoxCollider = currGameObject.GetComponent<BoxCollider2D>();
                }
                else
                {
                    transform.parent = null;
                    currDropBox.updateNewWord("", 0, false);
                    currDropBox = null;
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            
            if (collision.tag == "DropBox" && !gameObject.GetComponent<BoxCollider2D>().IsTouching(currBoxCollider) && currDropBox != null) 
            {
                transform.parent = null;
                currDropBox.updateNewWord("", 0, false);
                currDropBox = null;
            }
 
    }

    private void OnMouseUp()
    {
        ChangeColorsOfType(wordType, Color.red);

        if (currDropBox != null)
        {
            if (wordType == currDropBox.type)
            {

                transform.position = currDropBox.transform.position;
                transform.parent = currDropBox.transform;
                currDropBox.updateNewWord(wordValue, score, true);
                // UPDATE PAPER
            }
            else
            {
                currDropBox.updateNewWord("", 0, false);
            }
        }
    }

    private void OnMouseDown()
    {
        ChangeColorsOfType(wordType, Color.white);
    }


    private void ChangeColorsOfType(string type, Color color)
    {

        var objects = GameObject.FindGameObjectsWithTag("DropBox");
        foreach (var dropBox in objects)
        {
            var currDropBox = dropBox.GetComponent<DropBox>();
            if (currDropBox.type == type)
            {
                currDropBox.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
        

}
