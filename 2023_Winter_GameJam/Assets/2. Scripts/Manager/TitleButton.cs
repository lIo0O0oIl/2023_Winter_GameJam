using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;

public class TitleButton : MonoBehaviour
{
    [SerializeField]
    private GameObject theme, themeManager;
    [SerializeField]
    private GameObject titleTxt;
    [SerializeField]
    private GameObject startBtn;
    [SerializeField]
    private GameObject player;

    public GameObject obj1, obj2;

    public GameObject gameReset;

    //public GameObject settingWindow;

    [SerializeField]
    private SpriteRenderer image;

    public void OnClickStaerBtn()
    {
        startBtn.SetActive(true);
        StartCoroutine(FandIn(1f));
        Invoke("StartBtn", 1f);
    }

    private void StartBtn()
    {
        themeManager.GetComponent<ThemeClearManager>().ThemeStart();
    }


    public void GameReset()
    {
        gameReset.SetActive(true);
    }

    public void Click_GameReset()
    {
        File.Delete(Application.dataPath + "/8. Data/SaveData.txt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
