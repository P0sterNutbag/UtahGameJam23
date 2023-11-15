using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject fadePrefab;
    public List<GameObject> envelopes = new List<GameObject>();
    public Transform sendPosition;
    public List<int> papersChosen = new List<int>();

    int round = 0;
    public int roundMax = 3;

    private int numOfPapers;
    private bool firstPaper;

    public static GameController instance;

    public GameObject envelope;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        firstPaper = true;
        numOfPapers = Resources.LoadAll("Papers/").Length;
    }

    public void InitializeFade(string room)
    {
        Fade fade = Instantiate(fadePrefab, new Vector2(0, 0), transform.rotation).GetComponent<Fade>();
        fade.fadeIn = true;
        fade.nextRoom = room;
    }

    void NextRound()
    {
        round++;
    }

    public void ChangeScene(string room)
    {
        SceneManager.LoadScene(room);
    }

    public void GoodEnding()
    {
        InitializeFade("GoodEnding");
    }

    public void BadEnding()
    {
        InitializeFade("BadEnding");
    }

    public void SendNewPaper()
    {
        Player player = gameObject.GetComponent<Player>();


        round++;


        if (round >= roundMax)
        {
            if (player.dictator <= player.resistance)
            {
                GoodEnding();
                return;
            }
            else
            {
                BadEnding();
                return;
            }
        }

        GameObject nextPaper = GetNextPaper();

        GameObject nextEnvelopeGO = Instantiate(envelope, sendPosition.position, sendPosition.rotation);

        Envelope nextEnvelope = nextEnvelopeGO.GetComponent<Envelope>();
        nextEnvelope.sendIn = true;

        nextEnvelope.paper = nextPaper;

        //Instantiate(envelopes[round], sendPosition.position, sendPosition.rotation);
    }


    private GameObject GetNextPaper()
    {

        GameObject paper;

        // May need to skip if we keep everything in place
        if (firstPaper) {
            // Maybe Make instructions here
            paper = Resources.Load<GameObject>("Intro");
            firstPaper = false;
        }
        else
        {
            int whichPaper;

            int i = numOfPapers;

            do
            {
                whichPaper = Random.Range(0, numOfPapers);
                i--;
            } while (papersChosen.Contains(whichPaper) && i > 0);

            paper = Resources.Load<GameObject>("Papers/" +whichPaper + "Paper");
            papersChosen.Add(whichPaper);

        }

        return paper;
    }
}
