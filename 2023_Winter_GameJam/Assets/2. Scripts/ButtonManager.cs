using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStaerBtn()
    {
        
    }

    public void OnClickSetButton()
    {

    }

    public void OnClickExitBtn()
    {

#if UNITY_EDITOR
        //����Ƽ ������ ���� ����
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }
}
