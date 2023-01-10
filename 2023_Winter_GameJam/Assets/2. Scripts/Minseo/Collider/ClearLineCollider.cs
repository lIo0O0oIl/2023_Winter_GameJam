using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearLineCollider : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Goal")
        {
            StartCoroutine(FandInL(1f));
        }
    }

    IEnumerator FandInL(float time)
    {
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }

        StartCoroutine(FandOut(1f));
    }
    IEnumerator FandOut(float time)
    {
        SceneManager.LoadScene("LandTheme2");

        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
