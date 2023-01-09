using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigidbody2D;

    public float speed;
    int x, y;

    private void Awake()
    {
        rigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(x, y).normalized * speed * Time.deltaTime;
    }

    public void Up(bool check)
    {
        //Debug.Log("¾÷");
        if (check)
        {
            //rigidbody2D.velocity = new Vector2(0, 1).normalized * speed;
            y = 1;
        }
        else
        {
            //rigidbody2D.velocity = new Vector2(0, 0).normalized * speed;
            y = 0;
        }
    }

    public void Down(bool check)
    {
        if (check)
        {
            //rigidbody2D.velocity = new Vector2(0, -1).normalized * speed;
            y = -1;
        }
        else
        {
            //rigidbody2D.velocity = new Vector2(0, 0).normalized * speed;
            y = 0;
        }
    }

    public void RIght(bool check)
    {
        if (check)
        {
            //rigidbody2D.velocity = new Vector2(1, 0).normalized * speed;
            x = 1;
        }
        else
        {
            //rigidbody2D.velocity = new Vector2(0, 0).normalized * speed;
            x = 0;
        }
    }

    public void Left(bool check)
    {
        if (check)
        {
            //rigidbody2D.velocity = new Vector2(-1, 0).normalized * speed;
            x = -1;
        }
        else
        {
            //rigidbody2D.velocity = new Vector2(0, 0).normalized * speed;
            x = 0;
        }
    }


}
