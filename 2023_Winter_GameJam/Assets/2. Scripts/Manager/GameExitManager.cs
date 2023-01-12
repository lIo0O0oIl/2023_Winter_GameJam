using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameExitManager : MonoBehaviour
{
    public GameObject exitWindow, buttonSound;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SeaTheme(true)" || SceneManager.GetActiveScene().name == "SeaTheme(true)_2")
        {
            exitWindow.GetComponentInChildren<Text>().text = "Go Main?";
        }
    }

    public void Click_exitWindow()
    {
        buttonSound.SetActive(true);
        exitWindow.SetActive(true);
        exitWindow.GetComponentsInChildren<Button>()[0].interactable = false;
        exitWindow.GetComponentsInChildren<Button>()[1].interactable = false;
        exitWindow.transform.DOScale(new Vector2(1, 1), 1f).SetEase(Ease.InOutCirc);
        Invoke("time", 1f);
    }

    private void time()
    {
        exitWindow.GetComponentsInChildren<Button>()[0].interactable = true;
        exitWindow.GetComponentsInChildren<Button>()[1].interactable = true;
        Time.timeScale = 0;
    }

    public void OnClickExitExit()
    {
        Time.timeScale = 1;
        exitWindow.GetComponentsInChildren<Button>()[0].interactable = false;
        exitWindow.GetComponentsInChildren<Button>()[1].interactable = false;
        exitWindow.transform.DOScale(new Vector2(0, 0), 1f).SetEase(Ease.InBack);
        Invoke("E_Exit", 1f);

    }

    private void E_Exit()
    {
        exitWindow.GetComponentsInChildren<Button>()[0].interactable = true;
        exitWindow.GetComponentsInChildren<Button>()[1].interactable = true;
        exitWindow.SetActive(false);
        buttonSound.SetActive(false);
    }

    public void Yes()
    {
        if (SceneManager.GetActiveScene().name == "SeaTheme(true)" || SceneManager.GetActiveScene().name == "SeaTheme(true)_2")
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Title");
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
        }
    }
}
