using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject theme;
    [SerializeField]
    private GameObject titleTxt;
    [SerializeField]
    private GameObject startBtn;
    [SerializeField]
    private Image image;

    public void OnClickStaerBtn()
    {
        startBtn.SetActive(true);
        StartCoroutine(FandIn(1f));    
    }

    public void OnClickSetButton()
    {

    }

    public void OnClickExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }

    IEnumerator FandIn(float time)
    {
        titleTxt.SetActive(false);

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
        theme.SetActive(true);

        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
