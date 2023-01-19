using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MoveTest : MonoBehaviour
{
    public GameObject player2;

    Rigidbody2D p2_rigidbody2D;

    [SerializeField]
    private float speed = 3;
    public float upY, downY, leftX, rightX;

    public Color changeColor;
    public Color basicColor;

    public bool up, down, left, right;


    private void Start()
    {
        p2_rigidbody2D = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (p2_rigidbody2D.bodyType != RigidbodyType2D.Static)
        {
            if (up)
            {
                p2_rigidbody2D.velocity = new Vector2(p2_rigidbody2D.velocity.x, upY).normalized * speed/* * Time.deltaTime*/;
            }

            if (down)
            {
                p2_rigidbody2D.velocity = new Vector2(p2_rigidbody2D.velocity.x, downY).normalized * speed;
            }

            if (left)
            {
                p2_rigidbody2D.velocity = new Vector2(leftX, p2_rigidbody2D.velocity.y).normalized * speed;
            }

            if (right)
            {
                p2_rigidbody2D.velocity = new Vector2(rightX, p2_rigidbody2D.velocity.y).normalized * speed;
            }

            if (!up && !down && !left && !right)
            {
                p2_rigidbody2D.velocity = new Vector2(0, 0);
            }
        }

        #region 아좀 사라져
        /*//오른쪽 왼쪽 스케일 변경
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
        }*/
        #endregion
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
        if (a == 1) { upY = 0.3f; up = true; }
        if (a == 2) { downY = -0.3f; down = true; }
        if (a == 3) {rightX = 0.3f; right = true; }
        if (a == 4) {leftX = -0.3f; left = true;}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Up" || collision.name == "Right" || collision.name == "Down" || collision.name == "Left")
        {
            collision.GetComponent<SpriteRenderer>().color = basicColor;

            if (collision.name == "Up")
            {
                StartCoroutine(dely(1));
            }

            if (collision.name == "Down")
            {
                StartCoroutine(dely(2));
            }

            if (collision.name == "Right")
            {
                StartCoroutine(dely(3));
            }

            if (collision.name == "Left")
            {
                StartCoroutine(dely(4));
            }
        }
    }

    IEnumerator dely(int a)
    {
        yield return new WaitForSeconds(0.3f);
        if (a == 1) { up = false; upY = 0; }
        if (a == 2) { down = false; downY = 0; }
        if (a == 3) { right = false; rightX = 0; }
        if (a == 4) { left = false; leftX = 0; }
    }
}
