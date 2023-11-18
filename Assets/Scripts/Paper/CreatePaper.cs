using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.Windows;
using UnityEngine.UIElements;

public class CreatePaper : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public List<string> targetWords = new List<string>();
    public GameObject dropBox;
    string pattern;
    GameController gameController;
    CreateWords createWords;
    public List<string> possibleWords = new List<string>();

    void Start()
    {
        textMeshPro.sortingOrder = -1;
        gameController = FindObjectOfType<GameController>();
        createWords = FindObjectOfType<CreateWords>();
        pattern = @"\[([^\]]+)\]";
        StartCoroutine(LateStart(0.1f));

    }

    private void GetWordLocation(string word)
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro not assigned!");
            return;
        }

        int index = textMeshPro.text.IndexOf(word);

        // Get the RectTransform of the text
        RectTransform rectTransform = textMeshPro.rectTransform;
        CreateDropBox(rectTransform, index, word.Length, word);

    }

    // Helper function to get the RectTransform of a portion of the TextMeshPro text
    private void CreateDropBox(RectTransform parentRectTransform, int startIndex, int length, string word)
    {
        TMP_TextInfo textInfo = textMeshPro.textInfo;


        // Calculate the bounds of the characters in the word
        Bounds bounds = new Bounds(textInfo.characterInfo[startIndex].bottomLeft, Vector3.zero);

        bounds.Encapsulate(textInfo.characterInfo[startIndex + length - 1].bottomRight);
        bounds.Encapsulate(textInfo.characterInfo[startIndex + length - 1].topLeft);
        bounds.Encapsulate(textInfo.characterInfo[startIndex + length - 1].topRight);

        // Create a BoxCollider2D for the word
        Vector3 centerPosition = textMeshPro.transform.TransformPoint(bounds.center);

        // Create a BoxCollider2D for the word
        RectTransform wordRectTransform = new GameObject(word + " Transform").AddComponent<RectTransform>();
        wordRectTransform.SetParent(parentRectTransform);

        // Set the world position of the RectTransform
        wordRectTransform.position = centerPosition;

        // Set the size of the RectTransform based on the bounds
        wordRectTransform.sizeDelta = new Vector2(bounds.size.x, bounds.size.y);

        Vector3 dropBoxPos = new Vector3(wordRectTransform.position.x, wordRectTransform.position.y, 0);

        GameObject currGO = Instantiate(dropBox, dropBoxPos , dropBox.transform.rotation);
        currGO.transform.SetParent(gameObject.transform);

        PopulateDropBox(currGO, word);

        DropBox currDropBox = currGO.GetComponent<DropBox>();
        BoxCollider2D boxCollider = currDropBox.GetComponent<BoxCollider2D>();

        // Set the size and position of the BoxCollider2D based on the RectTransform of the target word
        boxCollider.size = new Vector2(wordRectTransform.rect.width, wordRectTransform.rect.height);
    }

    private void PopulateDropBox(GameObject currGameObject, string word)
    {
        DropBox dropBox = currGameObject.GetComponent<DropBox>();
        dropBox.oldWord = word;
        return;
    }

    private string GetReplacementWord(string wordType)
    {
        possibleWords.Clear();
        // TODO: Add new replacement word to the list
        for (int i = 0; i < createWords.wordList.Count; i++)
        {
            if (createWords.wordList[i].Item2 == wordType)
            {
                possibleWords.Add(createWords.wordList[i].Item1);
            }
        }

        int randInt = Random.Range(0, possibleWords.Count);
        string newWord = possibleWords[randInt];
        targetWords.Add(newWord);
        return newWord;
    }

    private void FindAndReplaceWord()
    {

        Regex regex = new Regex(pattern);
        string sentence = textMeshPro.text;

        // Replace matches using a loop
        while (regex.IsMatch(sentence))
        {
            sentence = regex.Replace(sentence, (match) =>
            {
                string placeholder = match.Groups[1].Value; // Get the text inside the brackets
                int index = match.Index;
                string replacement = GetReplacementWord(placeholder);
                return replacement;
            });
        }

        textMeshPro.text = sentence;


        StartCoroutine(Pause(0.1f));

    }

    private void DropBoxLoop()
    {
        for (int i = 0; i < targetWords.Count; i++)
        {
            GetWordLocation(targetWords[i]);
        }
    }

    IEnumerator Pause(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        DropBoxLoop();
        textMeshPro.sortingOrder = 1;
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        FindAndReplaceWord();

    }
}