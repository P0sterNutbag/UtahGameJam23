using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentenceManager : MonoBehaviour
{
    public List<string> sentenceTemplates = new List<string>
    {
        "The [adjective] [noun] [verb] over the [adjective] [noun].",
        "The [noun] is [verb] by the [adjective] [noun]."
    };

    private List<string> inventory = new List<string>();

    void Start()
    {
        //GenerateSentence();
    }

    void GenerateSentence()
    {
        // TODO: need to add these generated words to the CreatePaper so they can get a drop box on them
        string sentenceTemplate = GetRandomSentenceTemplate();
        List<string> placeholders = GetPlaceholders(sentenceTemplate);

        // Replace placeholders with actual words from the inventory
        string sentence = sentenceTemplate;
        foreach (string placeholder in placeholders)
        {
            string replacement = GetReplacementWordFromInventory();
            sentence = sentence.Replace(placeholder, replacement);
        }

        Debug.Log(sentence);
    }

    string GetRandomSentenceTemplate()
    {
        return sentenceTemplates[Random.Range(0, sentenceTemplates.Count)];
    }

    List<string> GetPlaceholders(string sentence)
    {
        List<string> placeholders = new List<string>();
        // Implement logic to extract placeholders from the sentence
        // For example, using regex or a custom parsing mechanism
        // In this example, we're assuming placeholders are enclosed in square brackets.
        // You might need a more robust parsing logic depending on your needs.
        string pattern = @"\[([^\]]+)\]";
        System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(sentence, pattern);

        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            placeholders.Add(match.Value);
        }

        return placeholders;
    }

    string GetReplacementWordFromInventory()
    {
        // Implement logic to get a replacement word from the player's inventory
        // For example, you could have a UI that displays available words for selection
        // and return the selected word.
        return inventory[Random.Range(0, inventory.Count)];
    }
}
