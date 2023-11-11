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
    public Vector2 sendPosition;

    public bool isOpen = false;
    public bool sendIn = false;
    public bool sendAway = false;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    Vector2 force;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        if (sendIn)
        {
            force = new Vector3(Random.Range(0.1f, 0.2f), Random.Range(-0.05f, 0.05f));
        }
        //rigidBody.AddForce(new Vector3(Random.Range(200, 400), Random.Range(-100, 100)));
    }

    private void FixedUpdate()
    {
        //rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector2(0, 0), 3f * Time.deltaTime);
        if (force.x != 0 && force.y != 0)
        {
            rigidBody.position += force;
            force = Vector2.Lerp(force, Vector2.zero, 3f * Time.deltaTime);
        }
        else if (sendAway)
        {
            rigidBody.position = Vector2.Lerp(rigidBody.position, sendPosition, 3f * Time.deltaTime);
            if (Vector2.Distance(rigidBody.position, sendPosition) < 0.1f)
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
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            spriteRenderer.sprite = closedSprite;
            isOpen = false;
            sendAway = true;
        }
    }

}
