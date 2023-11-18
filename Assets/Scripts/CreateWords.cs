using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWords : MonoBehaviour
{

    public GameObject newWord;
    public GameObject range;

    public List<(string, string, int)> words = new List<(string, string, int)> ();
    //private Dictionary<string, GameObject> gameObjectMap = new Dictionary<string, GameObject>();
    private Drawer drawer;

    string[] crudWordList;
    public List<(string, string, int)> wordList = new List<(string, string, int)>();

    private void Start()
    {

        string path = "Assets/words.txt"; // Adjust the path based on the location of your file
        crudWordList = File.ReadAllLines(path);
        FilterWordList();

        drawer = FindObjectOfType<Drawer>();

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
            int rand = UnityEngine.Random.Range(0, wordList.Count);

            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(minX, maxX), UnityEngine.Random.Range(minY, maxY), 0);



            GameObject inst = Instantiate(newWord, spawnPos, transform.rotation);

            PutWordsInDrawer(inst);

            Word wordValues = inst.GetComponent<Word>();

            wordValues.wordValue = wordList[rand].Item1;
            wordValues.wordType = wordList[rand].Item2;
            wordValues.score = wordList[rand].Item3;
            wordValues.textMesh.text = wordList[rand].Item1;

        }

        //drawer.HideContents();
    }

    private void PutWordsInDrawer(GameObject inst)
    {
        drawer.contents.Add(inst);
    }


    private void FilterWordList()
    {
        foreach (string line in crudWordList)
        {
            string[] word = line.Split(' ');

            //print(word[0] + word[1] + int.Parse(word[2]));

            // Display each word in the console
            wordList.Add((word[0], word[1], int.Parse(word[2])));   
        } 
    }



}
