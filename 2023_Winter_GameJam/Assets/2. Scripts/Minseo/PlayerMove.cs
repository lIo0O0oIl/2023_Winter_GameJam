using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum State
//{
//    None,
//    Moving,
//    End
//}

//enum Direction
//{
//    None,
//    Up,
//    Down,
//    Left,
//    Right
//}

public class PlayerMove : MonoBehaviour
{
    public GameObject player2;

    //Animator animator;
    //Rigidbody2D rigidbody2D;
    Rigidbody2D p2_rigidbody2D;

    State state = State.None;
    Direction direction = Direction.None;

    [SerializeField]
    private float speed = 7;
    //float time = 0;
    //int check = 0;
    int x, y;

    public Color changeColor;
    public Color basicColor;


    private void Start()
    {
        //animator = GetComponent<Animator>();
        //rigidbody2D = GetComponent<Rigidbody2D>();
        p2_rigidbody2D = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Move();
        MoveAnimation();

        /*if (state == State.Moving)
        {
            //time += Time.deltaTime;
            StartCoroutine(MovePlayer_2());
            //Invoke("movemove", .3f);
        }*/

        if (state == State.End)
        {
            //time -= Time.deltaTime;

        }

        /*if (time < 0)
        {
            time = 0;
            state = State.None;
            //direction = Direction.None;
            x = 0;
            y = 0;
            p2_rigidbody2D.velocity = new Vector2(0, 0);
        }*/

        p2_rigidbody2D.velocity = new Vector2(x, y).normalized * speed * Time.deltaTime;

    }
    void Move()
    {
        //rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }

    IEnumerator MovePlayer_2()
    {
        yield return new WaitForSeconds(0.3f);

        /*if (direction == Direction.Left)
        {
            p2_rigidbody2D.velocity = new Vector2(-1, 0).normalized * speed;
        }
        else if (direction == Direction.Right)
        {
            p2_rigidbody2D.velocity = new Vector2(1, 0).normalized * speed;
        }
        else if (direction == Direction.Up)
        {
            p2_rigidbody2D.velocity = new Vector2(0, 1).normalized * speed;
        }
        else if (direction == Direction.Down)
        {
            p2_rigidbody2D.velocity = new Vector2(0, -1).normalized * speed;
        }*/

        p2_rigidbody2D.velocity = new Vector2(x, y).normalized * speed * Time.deltaTime;
    }

    void movemove()
    {
        p2_rigidbody2D.velocity = new Vector2(x, y).normalized * speed * Time.deltaTime;

    }


    private void MoveAnimation()
    {
        //animator.SetFloat("InputX", rigidbody2D.velocity.x);
        //animator.SetFloat("InputY", rigidbody2D.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Up" || collision.name == "Right" || collision.name == "Down" || collision.name == "Left")
        {
            state = State.Moving;

            collision.GetComponent<SpriteRenderer>().color = changeColor;

            if (collision.name == "Up")
            {
                //direction = Direction.Up;
                //y = 1;
                StartCoroutine(move(1));
            }
            if (collision.name == "Down")
            {
                //direction = Direction.Down;
                y = -1;
                StartCoroutine(move(2));
            }
            if (collision.name == "Right")
            {
                //Debug.Log("충돌감지-오른쪽");
                //direction = Direction.Right;
                x = 1;
                StartCoroutine(move(3));
            }
            if (collision.name == "Left")
            {
                //direction = Direction.Left;
                //x = -1;
                StartCoroutine(move(4));
            }

        }

    }

    IEnumerator move(int a)
    {
        Debug.Log("움직임 입력감지");
        yield return new WaitForSeconds(1f);
        if (a == 1)
        {
            y = 1;
        }
        if (a == 2)
        {
            y = -1;
        }
        if (a == 3) x = 1;
        if (a == 4) x = -1;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Up" || collision.name == "Right" || collision.name == "Down" || collision.name == "Left")
        {
            collision.GetComponent<SpriteRenderer>().color = basicColor;

            state = State.End;
            //direction = Direction.None;

            if (collision.name == "Up" || collision.name == "Down")
            {
                //direction = Direction.Up;
                //y = 0;
                StartCoroutine(dely(true));
            }
            if (collision.name == "Right" || collision.name == "Left")
            {
                //Debug.Log("충돌안함 오른쪽 왼쪽");
                //direction = Direction.Right;
                //x = 0;
                StartCoroutine(dely(false));
            }
        }
    }

    IEnumerator dely(bool a)
    {
        Debug.Log("안움직임 입력감지");
        yield return new WaitForSeconds(1f);
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
