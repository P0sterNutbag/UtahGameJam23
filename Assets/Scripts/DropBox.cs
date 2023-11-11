using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{

    public string oldWord;

    public string newWord;


    public void updateNewWord(string word, bool update)
    {
        if (update)
        {
            newWord = word;
        }
        else
        {
            newWord = null;
        }
    }
}
