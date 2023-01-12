using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class BreathingGame : MonoBehaviour
{
    public GameObject breathingObj;
    public UnityEvent clear, gameOver;
    public SpriteRenderer fader, fader2;

    public bool breathing = false;
    public bool gameClear = false;
    public bool gameOverBool = false;
    int count = 4;

    private void OnEnable()
    {
        breathing = false; 
        gameClear = false;
        gameOverBool = false;
        count = 4;

        StartCoroutine(Breating());
        StartCoroutine(faderFade());

    }

    IEnumerator Breating()
    {
        while (true)
        {
            if (!gameClear && !gameOverBool)
            {
                yield return new WaitForSeconds(2f);
                Debug.Log(count);
                Instantiate(breathingObj, new Vector2(Random.Range(-1.91f, 1.9741f), Random.Range(1.89f, 4.128f)), Quaternion.identity);
                count--;
                yield return new WaitForSeconds(3f);
            }
            else
            {
                //StopCoroutine(Breating());
                yield return null;
            }

            if (count <= 0)
            {
                break;
            }
        }
        StartCoroutine(Clear());
    }

    IEnumerator faderFade()
    {
        float a = 0f;
        //yield return new WaitForSeconds(3f);
        while (true)
        {
            if (breathing)
            {
                a -= 0.01f;
                fader2.color = new Color(1, 0, 0, a);
                yield return new WaitForSeconds(0.2f);
            }

            if (!breathing)
            {
                a += 0.01f;
                fader2.color = new Color(1, 0, 0, a);
                yield return new WaitForSeconds(0.2f);
            }

            /*if (a > 0.85f || gameClear)
            {
                break;
            }*/
            if (a > 0.75f)
            {
                break;
            }

            if (gameClear)
            {
                break;
            }
        }
        Debug.Log("½Ê¶ø¤© ¹þ¾î³²");
        //yield return new WaitForSeconds(3f);
        if (!gameClear)
        {
            StartCoroutine(GameOver());
        }

        //StopCoroutine(faderFade());
    }

    IEnumerator GameOver()
    {
        gameOverBool = true;

        fader2.DOColor(new Color(0, 0, 0, 1), 1f);
        fader.DOFade(1, 2f);
        yield return new WaitForSeconds(2.5f);
        gameOver.Invoke();
    }

    IEnumerator Clear()
    {
        if (!gameOverBool)
        {
            gameClear = true;

            fader2.DOColor(new Color(1, 0, 0, 0), 1.5f);
            yield return new WaitForSeconds(1f);
            clear.Invoke();
            gameObject.SetActive(false);
            //Debug.Log("dÀÌ¼­ÂïÈ÷³¶?");
        }
    }

    public void TouchBreath(bool exix)
    {
        Debug.Log(exix);
        if (exix)
        {
            breathing = true;
        }

        if (!exix)
        {
            breathing = false;
        }
    }
}
