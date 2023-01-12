using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMove : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rigidbody2D;

    public float speed;
    int x, y;

    bool touch = false;

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
        if (!touch)
        {
            x = (int)Input.GetAxisRaw("Horizontal");
            y = (int)Input.GetAxisRaw("Vertical");
        }

        if (x > 0)
        {
            GameObject.Find("Right").GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 1);
        }
        else
        {
            GameObject.Find("Right").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (x < 0)
        {
            GameObject.Find("Left").GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 1);
        }
        else
        {
            GameObject.Find("Left").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (y > 0)
        {
            GameObject.Find("Up").GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 1);
        }
        else
        {
            GameObject.Find("Up").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        if (y < 0)
        {
            GameObject.Find("Down").GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 1);
        }
        else
        {
            GameObject.Find("Down").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }



        rigidbody2D.velocity = new Vector2(x, y).normalized * speed/* * Time.deltaTime*/;
    }

    public void Up(bool check)
    {
        Debug.Log("À¸¾Ç");
        if (check)
        {
            touch = true;
        //Debug.Log("¾÷");
            y = 1;
        }
        else
        {
            touch = false;
            y = 0;
        }
    }

    public void Down(bool check)
    {
        if (check)
        {
            touch = true;
            y = -1;
        }
        else
        {
            touch = false;
            y = 0;
        }
    }

    public void RIght(bool check)
    {
        if (check)
        {
            touch = true;
            x = 1;
        }
        else
        {
            touch = false;
            x = 0;
        }
    }

    public void Left(bool check)
    {
        if (check)
        {
            touch = true;
            x = -1;
        }
        else
        {
            touch = false;
            x = 0;
        }
    }


}
