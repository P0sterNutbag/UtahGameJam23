using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    List<GameObject> words = new List<GameObject>();

    [SerializeField]
    int whichSide; // -1 is dict, 1 is resistance??

    private List<string> finalPaper = new List<string>();

    public GameObject gameManager;

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

    public void Score()
    {
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

            

            if (word.newWord == "")
            {
                //finalPaper.Add(word.oldWord);
                score1 = word.score;
                
            }
            else
            {
                //finalPaper.Add(word.newWord);
                score1 = word.newScore;
            }

            if (word.type == "verb")
            {
                var word2 = words[i+1].GetComponent<DropBox>();

                if (word2.newWord == "")
                {
                    //finalPaper.Add(word.oldWord);
                    score2 = word2.score;
                }
                else
                {
                    //finalPaper.Add(word.newWord);
                    score2 = word2.newScore;
                }
                score = score + ( score1 * score2);

                var word3 = words[i + 2].GetComponent<DropBox>();

                /*if (score1 < 0)
                {
                    if (word2.newWord == "")
                    {
                        //finalPaper.Add(word.oldWord);
                        score3 = word3.score;
                    }
                    else
                    {
                        //finalPaper.Add(word.newWord);
                        score3 = word3.newScore;
                    }
                    score = score - score3;
                }
                else
                {
                    if (word2.newWord == "")
                    {
                        //finalPaper.Add(word.oldWord);
                        score3 = word3.score;
                    }
                    else
                    {
                        //finalPaper.Add(word.newWord);
                        score3 = word3.newScore;
                    }
                    score = score + score3;
                }*/
                i++;
                i++;
            }
            else
            {
                score = score + score1;
            }

        }
        print(score);
        Player player = gameManager.GetComponent<Player>();

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
