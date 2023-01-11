using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class fish : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    //4.43393

    int count = 5;

    public SpriteRenderer fader;

    public UnityEvent clear;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        fader.DOFade(0, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            //collision.transform.position = Vector2.zero;
            collision.transform.position = new Vector2(boxCollider2D.bounds.center.x, boxCollider2D.bounds.center.y);
            //collision.transform.parent = gameObject.transform;
            StartCoroutine(Fishing(collision));
        }
    }

    IEnumerator Fishing(Collider2D collision)
    {
        gameObject.transform.DOMove(new Vector2(0, gameObject.transform.position.y + 2), 3f);
        collision.transform.DOMove(new Vector2(0, collision.transform.position.y + 2), 3f);
        yield return new WaitForSeconds(3f);
        collision.transform.localScale = new Vector2(0, 0);
        collision.gameObject.SetActive(false);
        gameObject.transform.DOMove(new Vector2(0, 4.43393f), 3f);
        yield return new WaitForSeconds(3f);

        count--;
        if (count <= 0)
        {
            // ÀÌº¥Æ®? ¾îÂ¼±¸·Î ÇÏ±ë
            clear?.Invoke();
        }
        else
        {
            Debug.Log("lqkf ?");
            collision.gameObject.SetActive(true);
            collision.transform.position = new Vector2(1.463f, 3.73f);
            collision.transform.DOScale(new Vector2(0.5f, 0.5f), 1).SetEase(Ease.InOutBack);
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
