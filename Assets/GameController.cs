using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //InitializeFade(false);
    }

    public void InitializeFade(bool fadeIn)
    {
        Fade fade = Instantiate(fadePrefab, new Vector2(0, 0), transform.rotation).GetComponent<Fade>();
        if (fadeIn) 
        {
            fade.fadeIn = fadeIn;
        }
    }

    void NextRound()
    {
        round++;

    }
}
