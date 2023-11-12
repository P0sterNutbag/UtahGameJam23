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
    private Color originalColor;

    private BoxCollider2D currBoxCollider;


    private void Start()
    {
        originalColor = Color.gray; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "DropBox")
            {
                /*if (currDropBox != null)
                {
                    currDropBox.updateNewWord("", 0, false);
                    currDropBox = null;
                }*/
                GameObject currGameObject = collision.gameObject;
                currDropBox = currGameObject.GetComponent<DropBox>();
                currBoxCollider = currGameObject.GetComponent<BoxCollider2D>();
                if (wordType != currDropBox.type || !gameObject.GetComponent<BoxCollider2D>().IsTouching(currBoxCollider))
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

        if (collision.tag == "DropBox")
        {
            GameObject currGameObject = collision.gameObject;
            DropBox tempDropBox = currGameObject.GetComponent<DropBox>();
            if (currDropBox == tempDropBox)
            {
                transform.parent = null;
                currDropBox.updateNewWord("", 0, false);
                currDropBox = null;
            }
        }

    }

    private void OnMouseUp()
    {
        ChangeColorsOfType(wordType, originalColor, true);

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
        ChangeColorsOfType(wordType, Color.white, false);
    }


    private void ChangeColorsOfType(string type, Color color, bool enable)
    {

        var objects = GameObject.FindGameObjectsWithTag("DropBox");
        foreach (var dropBox in objects)
        {
            var currDropBox = dropBox.GetComponent<DropBox>();
            if (currDropBox.type == type)
            {
                currDropBox.GetComponent<SpriteRenderer>().color = color;
            }
            /*else
            {
                if (enable)
                {
                    currDropBox.GetComponent<BoxCollider2D>().enabled = true;
                }
                else
                {
                    currDropBox.GetComponent<BoxCollider2D>().enabled = false;
                }
            }*/
        }
    }
        

}
