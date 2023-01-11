using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Breathing : MonoBehaviour
{
    public BreathingGame touch;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Disappear());

        gameObject.transform.DOScale(1.5f, 1.5f).SetEase(Ease.OutBack);

        touch = FindObjectOfType<BreathingGame>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touch.TouchBreath(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            touch.TouchBreath(false);
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("Bomb", true);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (touch.gameClear || touch.gameOverBool)
        {
            DestroyMe();
        }
    }
}
