using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropBox : MonoBehaviour
{

    public string oldWord;
    public string newWord;
    public int newScore;
    public int score;
    public TextMeshPro textMeshPro;

    private void Start()
    {
        textMeshPro.text = oldWord; 
    }


    public void updateNewWord(string word, int score, bool update)
    {
        if (update)
        {
            Debug.Log("1");
            newWord = word;
            newScore = score;
        }
        else
        {
            Debug.Log("2");
            newWord = null;
        }
    }
}
