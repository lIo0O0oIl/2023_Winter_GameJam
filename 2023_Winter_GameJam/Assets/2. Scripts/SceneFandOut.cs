using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneFandOut : MonoBehaviour
{
    [SerializeField]
    private Image image;

    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        StartCoroutine(FandOut(1f));
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }*/

    void Start()
    {
        image.DOFade(0, 1f);
    }

    IEnumerator FandOut(float time)
    {
        Color color = image.color;
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            image.color = color;
            yield return null;
        }
    }
}
