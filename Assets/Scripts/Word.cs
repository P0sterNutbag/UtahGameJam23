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

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "DropBox")
            {
                *//*if (currDropBox != null)
                {
                    currDropBox.updateNewWord("", 0, false);
                    currDropBox = null;
                }*//*
                GameObject tempCurrGameObject = collision.gameObject;
                DropBox tempCurrDropBox = tempCurrGameObject.GetComponent<DropBox>();
                BoxCollider2D tempCurrBoxCollider = tempCurrGameObject.GetComponent<BoxCollider2D>();
                if (wordType == tempCurrDropBox.type && gameObject.GetComponent<BoxCollider2D>().IsTouching(tempCurrBoxCollider))
                {
                    print("HIT");
                    GameObject currGameObject = collision.gameObject;
                    currDropBox = currGameObject.GetComponent<DropBox>();
                    currBoxCollider = currGameObject.GetComponent<BoxCollider2D>();
                }
                else
                {
                    transform.parent = null;
                    tempCurrDropBox.updateNewWord("", 0, false);
                    currDropBox = null;
                    currBoxCollider = null;
                }
            }
        }
        
    }*/

    /*private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "DropBox")
        {
            GameObject currGameObject = collision.gameObject;
            DropBox tempDropBox = currGameObject.GetComponent<DropBox>();
            if (currDropBox == tempDropBox)
            {
                print("OUT");
                transform.parent = null;
                currDropBox.updateNewWord("", 0, false);
                currDropBox = null;
            }
        }
*/
    //}

    private void OnMouseUp()
    {
        ChangeColorsOfType(wordType, originalColor, true);

        /*if (currDropBox != null)
        {
            if (wordType == currDropBox.type && gameObject.GetComponent<BoxCollider2D>().IsTouching(currBoxCollider))
            {

                transform.position = currDropBox.transform.position;
                transform.parent = currDropBox.transform;
                currDropBox.updateNewWord(wordValue, score, true);
            }
            else
            {
                transform.parent = null;
                currDropBox.updateNewWord("", 0, false);
                currDropBox = null;
                currBoxCollider = null;
            }
        }*/

    }

    private void OnMouseDown()
    {
        ChangeColorsOfType(wordType, Color.white, false);
    }


    private void ChangeColorsOfType(string type, Color color, bool place)
    {

        var objects = GameObject.FindGameObjectsWithTag("DropBox");
        foreach (var dropBox in objects)
        {
            var currDropBox = dropBox.GetComponent<DropBox>();
            if (currDropBox.type == type)
            {
                currDropBox.GetComponent<SpriteRenderer>().color = color;

                if (place)
                {
                    BoxCollider2D tempBoxCollider = currDropBox.GetComponent<BoxCollider2D>();
                    if (gameObject.GetComponent<BoxCollider2D>().IsTouching(tempBoxCollider))
                    {
                        transform.position = currDropBox.transform.position;
                        transform.parent = currDropBox.transform;
                        currDropBox.updateNewWord(wordValue, score, true);
                        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
                        break;
                    }
                    else
                    {
                        transform.parent = null;
                        currDropBox.updateNewWord("", 0, false);
                        currDropBox = null;
                        currBoxCollider = null;
                        gameObject.GetComponent<SpriteRenderer>().sortingOrder= 3;
                    }
                }
            }
        }
    }
}


