using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    
    public string wordValue;
    public string wordType;
    public int score;
    //private DropBox currDropBox;
    public TextMeshPro textMesh;
    private Color originalColor;



    private void Start()
    {
        originalColor = new Color(184,194,185,255); 
    }

    private void OnMouseUp()
    {
        ChangeColorsOfType(wordType, originalColor, true);

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
                originalColor = currDropBox.GetComponent<SpriteRenderer>().color;
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
                        gameObject.GetComponent<SpriteRenderer>().sortingOrder= 3;
                    }
                }
            }
        }
    }
}


