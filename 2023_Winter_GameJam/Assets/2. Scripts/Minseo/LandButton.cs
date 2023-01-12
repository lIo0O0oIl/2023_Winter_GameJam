using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LandButton : MonoBehaviour
{
    [SerializeField]
    private GameObject question;
    [SerializeField]
    private GameObject point;

    public void dkdkdk(bool a)
    {
        if (a)
        {
            point.SetActive(false);
            question.SetActive(true);
        }
        else
        {
            point.SetActive(true);
            question.SetActive(false);
        }
    }

    /*public void OnClickSet()
    {

    }*/

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }
}
