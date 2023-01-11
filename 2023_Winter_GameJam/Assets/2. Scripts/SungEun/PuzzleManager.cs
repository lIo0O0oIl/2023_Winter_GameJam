using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] controller_2;
    public GameObject fader, fader2, button1, button2, player1, player2;
    //0.0209, 3.0064 페이더 처음 위치
    //-1.859, 0.662 버튼 처음 위치
    //-354.5, 127 버튼 택스트 처음 위치

    public GameObject[] puzzleArray;

    private void Awake()
    {
        // 씬 시작시 여기서 페이드 인 페이드 아웃
        fader2.SetActive(true);
        fader2.GetComponent<SpriteRenderer>().DOFade(0, 1);
    }

    private void Start()
    {
        player1.transform.position = new Vector2(0, -1.9f);
        player2.transform.position = new Vector2(0, 1.63f);
        fader.SetActive(true);
        puzzleArray[0].SetActive(true);
        for (int i = 1; i < puzzleArray.Length; i++)
        {
            /*if (i == 0)
            {
                fader.SetActive(false);
                continue;
            }*/
            puzzleArray[i].SetActive(false);
        }
    }

    IEnumerator ObjectFalse(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    /*IEnumerator ObjectFade(GameObject obj, int what, int fadetime, int delay)
    {
        yield return new WaitForSeconds(delay);
        obj.GetComponent<SpriteRenderer>().DOFade(what, fadetime);
    }*/

    public void GameStart()
    {
        controller_2[0].gameObject.SetActive(true);
        button1.GetComponent<SpriteRenderer>().DOFade(0, 1.7f);
        button1.GetComponentInChildren<Text>().DOFade(0, 1.7f);
        StartCoroutine(ObjectFalse(button1, 1.7f));
        for (int i = 0; i < controller_2.Length; i++)
        {
            controller_2[i].GetComponent<SpriteRenderer>().DOFade(1, 2);
        }
        fader.GetComponent<SpriteRenderer>().DOFade(0, 2);
    }

    int water_Count = 7;

    public void puzzle_Clear_1()
    {
        water_Count--;
        //Debug.Log(water_Count);

        if (water_Count <= 0)
        {
            fader.transform.position = new Vector2(fader.transform.position.x, 1.2545f);
            fader.transform.localScale = new Vector2(fader.transform.localScale.x, 7.130427f);
            fader.GetComponent<SpriteRenderer>().DOFade(1, 3);
            Invoke("puzzle_Start_2", 3f);
        }
    }

    public void puzzle_Start_2()
    {
            fader.GetComponent<SpriteRenderer>().DOFade(0, 3);
            player1.transform.position = new Vector2(0, -1.9f);
            player2.transform.position = new Vector2(0, 1.63f);
            button2.SetActive(true);
    }

    public void puzzle_Start_2_2()
    {
        button2.GetComponent<SpriteRenderer>().DOFade(0, 1.7f);
        button2.GetComponentInChildren<Text>().DOFade(0, 1.7f);
        StartCoroutine(ObjectFalse(button2, 1.7f));
        puzzleArray[1].SetActive(true);
        SpriteRenderer[] puzzleArray1 = puzzleArray[1].GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in puzzleArray1)
        {
            item.DOFade(1, 2);
        }
    }

    public void puzzle_Clear_2()
    {
        Debug.Log("2단계 퍼즐 깸");
        fader.GetComponent<SpriteRenderer>().DOFade(1, 3);
        Invoke("puzzle_Start_3", 3f);
    }

    public void puzzle_Start_3()
    {
        puzzleArray[1].SetActive(false);
        fader.GetComponent<SpriteRenderer>().DOFade(0, 3);
        player1.transform.position = new Vector2(0, -1.9f);
        player2.transform.position = new Vector2(0, 1.63f);
        //button3.SetActive(true);
        puzzleArray[2].SetActive(true);
        SpriteRenderer[] puzzleArray2 = puzzleArray[2].GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer item in puzzleArray2)
        {
            item.DOFade(1, 2);
        }
    }
}
