using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstClear : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private GameObject prassButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(FandInLand(1f));
        }

    }

    IEnumerator FandInLand(float time)
    {
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }

        StartCoroutine(FandOutLand(1f));
    }
    IEnumerator FandOutLand(float time)
    {
        prassButton.SetActive(true);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
        
    }
}
