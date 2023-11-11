using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    List<DropBox> words = new List<DropBox>();

    private List<string> finalPaper = new List<string>();

    
    private void Send()
    {

        foreach (DropBox word in words)
        {
            if (word.newWord == null)
            {
                finalPaper.Add(word.oldWord);
            }
            else
            {
                finalPaper.Add(word.newWord);
            }
        }
    }



}
