using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthwormMove : MonoBehaviour
{
    public int move_delay;	
    public int move_time;	

    float speed_x;
    float speed_y;	
    bool isWandering;
    bool isWalking;

    SpriteRenderer sprite;
    Animator anim;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        isWandering = false;
        isWalking = false;
    }

    void FixedUpdate()
    {
        if (!isWandering)
            StartCoroutine(Wander());	
        if (isWalking)
            Move();
    }

    void Move()
    {
        if (speed_x != 0)
            sprite.flipX = speed_x < 0;  

        transform.Translate(speed_x, speed_y, speed_y);	
    }

    IEnumerator Wander()
    {
        speed_x = Random.Range(-0.8f, 0.8f) * Time.deltaTime;
        speed_y = Random.Range(-0.8f, 0.8f) * Time.deltaTime;

        isWandering = true;

        yield return new WaitForSeconds(move_delay);

        isWalking = true;
        anim.SetBool("isWalk", true);	

        yield return new WaitForSeconds(move_time);

        isWalking = false;
        anim.SetBool("isWalk", false);

        isWandering = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BorderY") 
            speed_y = -speed_y;
        else if (collision.tag == "BorderX")
            speed_x = -speed_x;
    }
}
