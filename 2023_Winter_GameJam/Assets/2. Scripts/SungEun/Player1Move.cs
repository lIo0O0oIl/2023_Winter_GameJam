using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    public GameObject player2;

    Rigidbody2D p2_rigidbody2D;

    [SerializeField]
    private float speed = 7;
    public float x, y;

    public Color changeColor;
    public Color basicColor;


    private void Start()
    {
        p2_rigidbody2D = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (p2_rigidbody2D.bodyType != RigidbodyType2D.Static)
        {
            p2_rigidbody2D.velocity = new Vector2(x, y).normalized * speed/* * Time.deltaTime*/;
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            this.gameObject.transform.localScale = new Vector2(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            this.gameObject.transform.localScale = new Vector2(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y);
        }

        if (x > 0)
        {
            player2.transform.localScale = new Vector2(-Mathf.Abs(player2.transform.localScale.x), player2.transform.localScale.y);
        }
        if (x < 0)
        {
            player2.transform.localScale = new Vector2(Mathf.Abs(player2.transform.localScale.x), player2.transform.localScale.y);
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Up" || collision.name == "Right" || collision.name == "Down" || collision.name == "Left")
        {
            collision.GetComponent<SpriteRenderer>().color = changeColor;

            if (collision.name == "Up")
            {
                StartCoroutine(move(1));
            }
            if (collision.name == "Down")
            {
                StartCoroutine(move(2));
            }
            if (collision.name == "Right")
            {
                StartCoroutine(move(3));
            }
            if (collision.name == "Left")
            {
                StartCoroutine(move(4));
            }

            SoundManager.Instance.Button_Click2();
        }

    }

    IEnumerator move(int a)
    {
        yield return new WaitForSeconds(0.3f);
        if (a == 1) y = 0.3f;
        if (a == 2) y = -0.3f;
        if (a == 3) x = 0.3f;
        if (a == 4) x = -0.3f;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Up" || collision.name == "Right" || collision.name == "Down" || collision.name == "Left")
        {
            collision.GetComponent<SpriteRenderer>().color = basicColor;

            if (collision.name == "Up" || collision.name == "Down")
            {
                StartCoroutine(dely(true));
            }
            if (collision.name == "Right" || collision.name == "Left")
            {
                StartCoroutine(dely(false));
            }
        }
    }

    IEnumerator dely(bool a)
    {
        yield return new WaitForSeconds(0.3f);
        if (a)
        {
            y = 0;
        }
        else
        {
            x = 0;
        }
    }
}
