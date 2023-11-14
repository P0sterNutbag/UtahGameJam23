using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    float alpha;
    float alphaChange = 1f;
    //float changeTimer = 0.0f;
    //float changeTimerMax = 1f;

    public string nextRoom;
    public bool fadeIn = true;

    private void Start()
    {
        if (fadeIn)
        {
            alpha = 0.0f;
        }
        else
        {
            alpha = 1.0f;
        }
    }

    void FixedUpdate()
    {
        if (fadeIn)
        {
            if (alpha < 1f)
            {
                ChangeAlpha(GetComponent<Renderer>().material, alpha);
                alpha += alphaChange * Time.deltaTime;
            }
            else
            {
                GameController.instance.ChangeScene(nextRoom);
                /*changeTimer += Time.deltaTime;
                if (changeTimer >= changeTimerMax)
                {
                    fadeIn = false;
                }*/
            }
        } 
        else
        {
            if (alpha > 0f)
            {
                ChangeAlpha(GetComponent<Renderer>().material, alpha);
                alpha -= alphaChange * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
