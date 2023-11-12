using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropBox : MonoBehaviour
{

    public string oldWord;
    public int score;
    public string type;
    public string newWord;
    public int newScore;
    
    public TextMeshPro textMeshPro;

    private void Start()
    {
        textMeshPro.text = oldWord;
        newWord = "";
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
