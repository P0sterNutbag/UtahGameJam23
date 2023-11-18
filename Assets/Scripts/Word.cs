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
    private SpriteRenderer spriteRenderer;



    private void Start()
    {
        originalColor = new Color(184,194,185,255);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUp()
    {
        ChangeColorsOfType(wordType, originalColor, true);

    }

    private void OnMouseDown()
    {
        ChangeColorsOfType(wordType, Color.white, false);
        //spriteRenderer.enabled = true;
    }


    private void ChangeColorsOfType(string type, Color color, bool place)
    {

        var objects = GameObject.FindGameObjectsWithTag("DropBox");
        foreach (var dropBox in objects)
        {
            
            var currDropBox = dropBox.GetComponent<DropBox>();
            print(currDropBox.type);
            if (currDropBox.type == type)
            {
                print("HERE");
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
                        spriteRenderer.sortingOrder = 10;
                        //spriteRenderer.enabled = false;

                        print("I TOUCH");

                        break;
                    }
                    else
                    {
                        transform.parent = null;
                        currDropBox.updateNewWord("", 0, false);
                        currDropBox = null;
                        spriteRenderer.sortingOrder= 3;
                    }
                }
            }
        }
    }
}


