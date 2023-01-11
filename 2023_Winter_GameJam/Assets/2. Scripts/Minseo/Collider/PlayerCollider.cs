using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Land")
        {
            StartCoroutine(FandInLand(1f));
        }
        else if (collision.tag == "Sea")
        {
            StartCoroutine(FandInSea(1f));
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

        SceneManager.LoadScene("LandTheme");
    }


    IEnumerator FandInSea(float time)
    {
        Color color = image.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / time;
            image.color = color;
            yield return null;
        }

        SceneManager.LoadScene("SeaTheme");
    }
}
