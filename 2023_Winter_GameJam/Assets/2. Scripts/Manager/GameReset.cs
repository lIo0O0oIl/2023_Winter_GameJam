using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using DG.Tweening;
using UnityEngine.UI;

public class GameReset : MonoBehaviour
{
    public GameObject gameResetWindow, buttonSound;
    public void Click_exitWindow()
    {
        buttonSound.SetActive(true);
        gameResetWindow.SetActive(true);
        gameResetWindow.GetComponentsInChildren<Button>()[0].interactable = false;
        gameResetWindow.GetComponentsInChildren<Button>()[1].interactable = false;
        gameResetWindow.transform.DOScale(new Vector2(1, 1), 1f).SetEase(Ease.InOutCirc);
        Invoke("time", 1f);
    }

    private void time()
    {
        gameResetWindow.GetComponentsInChildren<Button>()[0].interactable = true;
        gameResetWindow.GetComponentsInChildren<Button>()[1].interactable = true;
        Time.timeScale = 0;
    }

    public void OnClickExitExit()
    {
        Time.timeScale = 1;
        gameResetWindow.GetComponentsInChildren<Button>()[0].interactable = false;
        gameResetWindow.GetComponentsInChildren<Button>()[1].interactable = false;
        gameResetWindow.transform.DOScale(new Vector2(0, 0), 1f).SetEase(Ease.InBack);
        Invoke("E_Exit", 1f);
    }

    private void E_Exit()
    {
        gameResetWindow.GetComponentsInChildren<Button>()[0].interactable = true;
        gameResetWindow.GetComponentsInChildren<Button>()[1].interactable = true;
        gameResetWindow.SetActive(false);
        buttonSound.SetActive(false);
    }

    public void Yes()
    {
        Time.timeScale = 1;
        File.Delete(Application.dataPath + "/8. Data/SaveData.txt");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
        //StartCoroutine(YesYes());
    }

    IEnumerator YesYes()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        while (!operation.isDone) yield return null;


    }
}
