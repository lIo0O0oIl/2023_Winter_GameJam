using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    None,
    Moving,
    End
}

public class Player2Move : MonoBehaviour
{
    public GameObject player2;

    //Animator animator;
    Rigidbody2D rigidbody2D;

    State state = State.None;

    [SerializeField]
    private float speed = 7;
    float time = 0;
    //int check = 0;

    private void Start()
    {
        //animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        MoveAnimation();

        if (state == State.Moving)
        {
            time += Time.deltaTime;
            StartCoroutine(right());
        }

        if (state == State.End)
        {
            time -= Time.deltaTime;

        }

        if (time <= 0)
        {
            time = 0;
            state = State.None;
            player2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }

    IEnumerator right()
    {
        yield return new WaitForSeconds(0.5f);
        player2.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0).normalized * speed;
    }


    private void MoveAnimation()
    {
        //animator.SetFloat("InputX", rigidbody2D.velocity.x);
        //animator.SetFloat("InputY", rigidbody2D.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("toto"))
        {
            state = State.Moving;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("toto"))
        {
            state = State.End;
        }
    }
}
