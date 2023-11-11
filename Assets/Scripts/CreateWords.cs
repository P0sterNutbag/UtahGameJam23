using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWords : MonoBehaviour
{

    public GameObject newWord;

    public List<(string, string)> words = new List<(string, string)> ();

    private void Start()
    {
        words.Add(("50", "number"));
        words.Add(("kill", "verb"));

        CreateRandomWords();
    }


    private void CreateRandomWords()
    {

        for (int i = 0; i < 10; i++)
        {
            int rand = UnityEngine.Random.Range(0, words.Count);
            GameObject inst = Instantiate(newWord, transform.position, transform.rotation);
            Word wordValues = inst.GetComponent<Word>();

            wordValues.wordValue = words[rand].Item1;
            wordValues.wordType = words[rand].Item2;
            wordValues.textMesh.text = words[rand].Item1;

        }
    }



}
