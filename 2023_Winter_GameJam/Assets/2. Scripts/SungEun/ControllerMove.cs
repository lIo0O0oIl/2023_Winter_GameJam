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
        //Debug.Log(rigidbody2D);
    }

    private void Update()
    {
        if (x > 0)
        {
            player.transform.localScale = new Vector2(-Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y);
        }
        if (x < 0)
        {
            player.transform.localScale = new Vector2(Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y);
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log(rigidbody2D.velocity);
        rigidbody2D.velocity = new Vector2(x, y).normalized * speed/* * Time.deltaTime*/;
    }

    public void Up(bool check)
    {
        if (check)
        {
        //Debug.Log("¾÷");
            y = 1;
        }
        else
        {
            y = 0;
        }
    }

    public void Down(bool check)
    {
        if (check)
        {
            y = -1;
        }
        else
        {
            y = 0;
        }
    }

    public void RIght(bool check)
    {
        if (check)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }
    }

    public void Left(bool check)
    {
        if (check)
        {
            x = -1;
        }
        else
        {
            x = 0;
        }
    }


}
