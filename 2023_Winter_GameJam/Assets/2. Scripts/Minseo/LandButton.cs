using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandButton : MonoBehaviour
{
    [SerializeField]
    private GameObject question
        ;

    public void OnClickQuestion()
    {
        question.SetActive(true);
    }

    public void OnClickSet()
    {

    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }
}
