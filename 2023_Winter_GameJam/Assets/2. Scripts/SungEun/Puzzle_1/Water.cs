using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Water : MonoBehaviour
{
    public UnityEvent clear_1;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Bomb", true);
            clear_1.Invoke();
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
