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

    void Start()
    {
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
        RectTransform wordRectTransform = new GameObject(word + " Transform").AddComponent<RectTransform>();
        wordRectTransform.SetParent(parentRectTransform);
        wordRectTransform.localPosition = bounds.center;
        wordRectTransform.sizeDelta = new Vector2(bounds.size.x, bounds.size.y);

        Vector3 dropBoxPos = new Vector3(wordRectTransform.position.x, wordRectTransform.position.y, 0);

        GameObject currGO = Instantiate(dropBox, dropBoxPos , dropBox.transform.rotation);
        currGO.transform.SetParent(gameObject.transform);

        //currGO.transform = 

        DropBox currDropBox = currGO.GetComponent<DropBox>();
        BoxCollider2D boxCollider = currDropBox.GetComponent<BoxCollider2D>();

        // Set the size and position of the BoxCollider2D based on the RectTransform of the target word
        boxCollider.size = new Vector2(wordRectTransform.rect.width, wordRectTransform.rect.height);
    }

    private string GetReplacementWord(string wordType)
    {

        // TODO: Add new replacement word to the list
        string newWord = "te" + wordType;
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

        for (int i = 0; i < targetWords.Count; i++)
        {
            GetWordLocation(targetWords[i]);
        }

    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        FindAndReplaceWord();

    }
}