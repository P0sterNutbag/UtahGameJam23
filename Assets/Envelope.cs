using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;
    public GameObject paper;
    public Transform openPosition;

    public bool isOpen = false;
    public bool sendIn = false;
    public bool sendAway = false;
    private bool sendBack = false;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    Vector2 force;
    Vector2 sendPosition = new Vector2(4f, 0f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        if (sendIn)
        {
            paper = Resources.Load<GameObject>("0IntroPaperPaper"); 
            force = new Vector2(Random.Range(0.1f, 0.2f), Random.Range(-0.05f, 0.05f));
        }
    }

    private void FixedUpdate()
    {
        if (force.x != 0 && force.y != 0)
        {
            rigidBody.position += force;
            force = Vector2.Lerp(force, Vector2.zero, 3f * Time.deltaTime);
        }
        if (sendAway)
        {
            rigidBody.position = Vector2.Lerp(rigidBody.position, sendPosition, 3f * Time.deltaTime);
            if (Vector2.Distance(rigidBody.position, sendPosition) < 0.1f)
            {
                GameController.instance.SendNewPaper();
                Destroy(gameObject);
            }
        }
        if (sendBack)
        {
            Vector2 target = GameController.instance.sendPosition.position;
            rigidBody.position = Vector2.Lerp(rigidBody.position, target, 3f * Time.deltaTime);
            if (Vector2.Distance(rigidBody.position, target) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Open()
    {
        if (!isOpen)
        {
            spriteRenderer.sprite = openSprite;
            Instantiate(paper, openPosition.position, openPosition.rotation);
            isOpen = true;
            sendBack = true;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            spriteRenderer.sprite = closedSprite;
            sendAway = true;
            isOpen = false;
        }
    }

}
