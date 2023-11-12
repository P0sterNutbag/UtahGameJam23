using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject fadePrefab;

    int round = 0;
    public int roundMax = 10;

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

}
