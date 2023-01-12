using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameExitManager : MonoBehaviour
{
    public GameObject exitWindow;
    public void Click_exitWindow()
    {
        exitWindow.SetActive(true);
        exitWindow.transform.DOScale(new Vector2(1, 1), 1.5f).SetEase(Ease.InOutCirc);
        Invoke("time", 1.5f);
    }

    private void time()
    {
        Time.timeScale = 0;
    }

    public void OnClickExitSetting()
    {
        Time.timeScale = 1;
        exitWindow.GetComponentInChildren<Button>().interactable = false;
        exitWindow.transform.DOScale(new Vector2(0, 0), 1.5f).SetEase(Ease.InBack);
        Invoke("E_Exit", 1.5f);
    }

    private void E_Exit()
    {
        exitWindow.GetComponentInChildren<Button>().interactable = true;
        exitWindow.SetActive(false);
    }
}
