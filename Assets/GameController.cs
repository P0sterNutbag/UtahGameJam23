using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject fadePrefab;
    public List<GameObject> papers = new List<GameObject>();
    public Transform sendPosition;

    int round = 0;
    public int roundMax = 3;

    public static GameController instance;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {

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
        round++;
        if (round >= roundMax)
        {
            GoodEnding();
            return;
        }
        Instantiate(papers[round], sendPosition.position, sendPosition.rotation);
    }

}
