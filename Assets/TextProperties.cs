using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextProperties : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    TextMeshPro text;

    private void FixedUpdate()
    {
        spriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        text = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        text.enabled = spriteRenderer.enabled;
        text.sortingOrder = spriteRenderer.sortingOrder;
    }
}
