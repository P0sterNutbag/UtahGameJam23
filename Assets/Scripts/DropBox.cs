using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropBox : MonoBehaviour
{

    public string oldWord;
    public string newWord;
    public string type;
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
            newWord = word;
            newScore = score;
        }
        else
        {
            newWord = "";
            newScore = score;
        }
    }
}
