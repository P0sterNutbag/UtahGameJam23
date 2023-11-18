using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class Paper : MonoBehaviour
{
    [SerializeField]
    List<GameObject> words = new List<GameObject>();

    [SerializeField]
    int whichSide; // -1 is dict, 1 is resistance??

    private List<string> finalPaper = new List<string>();
    string[] crudWordList;
    List<(string, string, int)> wordList;

    [SerializeField]
    GameController gameController;

    private Envelope envelope;

    bool isInEnvelope = false;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();

    }


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

    private void GetDropBox()
    {
        foreach (Transform child in transform)
        {
            GameObject childGameObject = child.gameObject;

            if (childGameObject.tag == "DropBox")
            {
                words.Add(childGameObject);
            }
        }
    }

    public void Score()
    {
        GetDropBox();

        int score = 0;

        int score1 = 0;
        int score2 = 0;
        int score3 = 0;

        for (int i = 0; i < words.Count; i++)
        {
            if (words[i] == null)
            {
                return;
            }
            var word = words[i].GetComponent<DropBox>();

            score1 = GetScore(word);

            if (word.type == "verb")
            {
                var word2 = words[i+1].GetComponent<DropBox>();

                score2 = GetScore(word2);

                score = score + ( score1 * score2);

                var word3 = words[i + 2].GetComponent<DropBox>();

                score3 = GetScore(word3);

                if (score1 > 0)
                {
                    score = score +  score3;
                }
                else
                {
                    score = score - score3;
                }

                i++;
                i++;
            }
            else
            {
                score = score + score1;
            }

        }
        //print(score);

        score = score / 2;
        Player player = gameController.GetComponent<Player>();

        if (whichSide == -1)
        {
            //Go to Dictator
            player.ChangeDictator(score);
        }
        else
        {
            player.ChangeResistance(score); 
        }

        /*int i = 0;
        foreach (GameObject gameObject in words)
        {
            var word = gameObject.GetComponent<DropBox>();
            *//*Debug.Log(word.oldWord);
            Debug.Log(word.newWord);*//*
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
        }*/
    }

    private int GetScore(DropBox word)
    {
        int score = 0;  
        if (word.newWord == "")
        {
            //finalPaper.Add(word.oldWord);
            score = word.score;
        }
        else
        {
            //finalPaper.Add(word.newWord);
            score = word.newScore;
        }


        return score;
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
