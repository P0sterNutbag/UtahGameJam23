using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class CreatePaper : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public string targetWord;
    public GameObject dropBox;
    string pattern;

    void Start()
    {
        string pattern = @"\[([^\]]+)\]";
        StartCoroutine(LateStart(0.1f));


    }

    private void GetWordLocations()
    {
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro not assigned!");
            return;
        }

        // Find the index of the target word in the text
        int wordIndex = textMeshPro.text.IndexOf(targetWord);

        // Ensure the target word exists in the text
        if (wordIndex != -1)
        {
            // Get the RectTransform of the text
            RectTransform rectTransform = textMeshPro.rectTransform;

            // Get the RectTransform of the target word
            RectTransform wordRectTransform = GetWordRectTransform(rectTransform, wordIndex, targetWord.Length);
        }
        else
        {
            Debug.LogError("Target word not found in the TextMeshPro text.");
        }
    }

    // Helper function to get the RectTransform of a portion of the TextMeshPro text
    RectTransform GetWordRectTransform(RectTransform parentRectTransform, int startIndex, int length)
    {
        TMP_TextInfo textInfo = textMeshPro.textInfo;


        // Calculate the bounds of the characters in the word
        Bounds bounds = new Bounds(textInfo.characterInfo[startIndex].bottomLeft, Vector3.zero);

        for (int i = 1; i < length; i++)
        {
            bounds.Encapsulate(textInfo.characterInfo[startIndex + i].bottomRight);
            bounds.Encapsulate(textInfo.characterInfo[startIndex + i].topLeft);
            bounds.Encapsulate(textInfo.characterInfo[startIndex + i].topRight);
        }

        // Create a BoxCollider2D for the word
        RectTransform wordRectTransform = new GameObject(targetWord + " Transform").AddComponent<RectTransform>();
        wordRectTransform.SetParent(parentRectTransform);
        wordRectTransform.localPosition = bounds.center;
        wordRectTransform.sizeDelta = new Vector2(bounds.size.x, bounds.size.y);

        Vector3 dropBoxPos = new Vector3(wordRectTransform.position.x, wordRectTransform.position.y, 0);

        //Create a DropBox here??
        GameObject currGO = Instantiate(dropBox, dropBoxPos , dropBox.transform.rotation);

        currGO.transform.SetParent(gameObject.transform);

        DropBox currDropBox = currGO.GetComponent<DropBox>();

        // Create a BoxCollider2D
        BoxCollider2D boxCollider = currDropBox.GetComponent<BoxCollider2D>();

        // Set the size and position of the BoxCollider2D based on the RectTransform of the target word
        boxCollider.size = new Vector2(wordRectTransform.rect.width, wordRectTransform.rect.height);

        return wordRectTransform;
    }

    private string GetReplacementWord(string wordType)
    {
        return "Testing";
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
                string replacement = GetReplacementWord(placeholder);
                return replacement;
            });
        }


        textMeshPro.text = sentence;


    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        FindAndReplaceWord();
        GetWordLocations();

    }
}