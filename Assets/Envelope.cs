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

    [HideInInspector] public bool isOpen = false;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    Vector2 force;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        force = new Vector3(Random.Range(0.1f, 0.2f), Random.Range(-0.05f, 0.05f));
        //rigidBody.AddForce(new Vector3(Random.Range(200, 400), Random.Range(-100, 100)));
    }

    private void FixedUpdate()
    {
        //rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector2(0, 0), 3f * Time.deltaTime);
        rigidBody.position += force;
        force = Vector2.Lerp(force, Vector2.zero, 3f * Time.deltaTime);
    }

    public void Open()
    {
        if (!isOpen)
        {
            spriteRenderer.sprite = closedSprite;
            Instantiate(paper, openPosition.position, openPosition.rotation);
            isOpen = true;
        }
    }

}
