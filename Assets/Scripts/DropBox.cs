using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropBox : MonoBehaviour
{

    public string oldWord;
    public string newWord;
    public TextMeshPro textMesh;

    private void Start()
    {
        textMesh.text = oldWord;
    }


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
