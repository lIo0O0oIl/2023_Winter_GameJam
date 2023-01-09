using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Animator animator;
    Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed = 7;


    private void Start()
    {
        //animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        MoveAnimation();
    }

    void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }

    private void MoveAnimation()
    {
        //animator.SetFloat("InputX", rigidbody2D.velocity.x);
        //animator.SetFloat("InputY", rigidbody2D.velocity.y);
    }

}
