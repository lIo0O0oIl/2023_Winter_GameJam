using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PressButtonGame : MonoBehaviour
{
    [Header("눌러야 할 것")]
    public List<GameObject> button = new List<GameObject>();

    [Header("밝아져야 하는 것")]
    public List<GameObject> light = new List<GameObject>();

    [SerializeField]
    private Image image;

    int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Prass")
        {
            Debug.Log("!");
            button[0].SetActive(false);
            light[0].SetActive(true);

            count++;
            Check();
        }
        else if(collision.tag == "Prass1")
        {
            button[1].SetActive(false);
            light[1].SetActive(true);

            count++;
            Check();
        }
        else if(collision.tag == "Prass2")
        {
            button[2].SetActive(false);
            light[2].SetActive(true);

            count++;
            Check();
        }
        else if(collision.tag == "Prass3")
        {
            button[3].SetActive(false);
            light[3].SetActive(true);

            count++;
            Check();
        }
        else if(collision.tag == "Prass4")
        {
            button[4].SetActive(false);
            light[4].SetActive(true);

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

        StartCoroutine(FandOut(1f));
    }
    IEnumerator FandOut(float time)
    {
        SceneManager.LoadScene("LandTheme1");

        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
