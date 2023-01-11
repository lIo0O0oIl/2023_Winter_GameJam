using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private GameObject theme;
    [SerializeField]
    private GameObject titleTxt;
    [SerializeField]
    private GameObject startBtn;
    [SerializeField]
    private GameObject player;

    public GameObject obj1, obj2;

    //public GameObject settingWindow;

    [SerializeField]
    private SpriteRenderer image;

    public void OnClickStaerBtn()
    {
        startBtn.SetActive(true);
        StartCoroutine(FandIn(1f));    
    }

    /*public void OnClickSetButton()
    {
        settingWindow.SetActive(true);
        settingWindow.transform.DOScale(new Vector2(1, 1), 1.5f).SetEase(Ease.InOutBack);
        Invoke("Setting", 1.5f);
    }

    private void Setting()
    {
        Time.timeScale = 0;
    }

    public void OnClickExitSetting()
    {
        Time.timeScale = 1;
        settingWindow.transform.DOScale(new Vector2(0, 0), 1.5f).SetEase(Ease.InOutBack);
        Invoke("S_Exit", 1.5f);
    }

    private void S_Exit()
    {
        settingWindow.SetActive(false);
    }*/

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
        player.SetActive(false);
        obj1.SetActive(false);
        obj2.SetActive(false);

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
        player.SetActive(true);

        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
