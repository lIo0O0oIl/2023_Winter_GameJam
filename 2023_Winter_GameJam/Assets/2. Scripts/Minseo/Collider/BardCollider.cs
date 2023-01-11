using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BardCollider : MonoBehaviour
{
    [SerializeField]
    private Image image;

    int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Prass")
        {
            count++;
            Check();
        }
        else if (collision.tag == "Prass1")
        {
            count++;
            Check();
        }
        else if (collision.tag == "Prass2")
        {
            count++;
            Check();
        }
        else if (collision.tag == "Prass3")
        {
            count++;
            Check();
        }
        else if (collision.tag == "Prass4")
        {
            count++;
            Check();
        }
    }

    private void Check()
    {
        if (count == 5)
        {
            StartCoroutine(FandIn(1f));
        }
    }

    IEnumerator FandIn(float time)
    {
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
        SceneManager.LoadScene("LandTheme4");
    }
}
