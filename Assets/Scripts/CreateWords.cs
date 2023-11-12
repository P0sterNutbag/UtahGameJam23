using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWords : MonoBehaviour
{

    public GameObject newWord;
    public GameObject range;

    public List<(string, string, int)> words = new List<(string, string, int)> ();

    private void Start()
    {
        words.Add(("10", "number", 1));
        words.Add(("20", "number", 2));
        words.Add(("30", "number", 3));
        words.Add(("40", "number", 4));
        words.Add(("50", "number", 5));
        words.Add(("60", "number", 6));
        words.Add(("70", "number", 7));
        words.Add(("80", "number", 8));
        words.Add(("90", "number", 9));
        words.Add(("100", "number", 10));

        words.Add(("kills", "verb", -5));
        words.Add(("hurts", "verb", -3));
        words.Add(("took", "verb", -1));
        words.Add(("saves", "verb", 5));
        words.Add(("heals", "verb", 3));
        words.Add(("gives", "verb", 1));

        words.Add(("destoryed", "verb", -5));
        words.Add(("damaged", "verb", -2));
        words.Add(("built", "verb", 5));
        words.Add(("rebuilt", "verb", 2));

        words.Add(("tanks", "building", -5));
        words.Add(("police", "building", -3));
        words.Add(("hospital", "building", 5));
        words.Add(("homes", "building", 3));

        words.Add(("civilians", "people", 3));
        words.Add(("people", "people", 2));
        words.Add(("millitary", "people", 1));




        CreateRandomWords();
    }


    private void CreateRandomWords()
    {
        float maxX = range.transform.position.x + (range.transform.localScale.x/2);
        float minX = range.transform.position.x - (range.transform.localScale.x / 2);
        float maxY = range.transform.position.y - (range.transform.localScale.y / 2);
        float minY = range.transform.position.y + (range.transform.localScale.y / 2);


        for (int i = 0; i < 8; i++)
        {
            int rand = UnityEngine.Random.Range(0, words.Count);

            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), 0);



            GameObject inst = Instantiate(newWord, spawnPos, transform.rotation);
            Word wordValues = inst.GetComponent<Word>();

            wordValues.wordValue = words[rand].Item1;
            wordValues.wordType = words[rand].Item2;
            wordValues.score = words[rand].Item3;
            wordValues.textMesh.text = words[rand].Item1;

        }
    }



}
