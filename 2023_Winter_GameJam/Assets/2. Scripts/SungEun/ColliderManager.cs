using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderManager : MonoBehaviour
{
    public UnityEvent run;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ö‘∂Û");
            run.Invoke();
        }
        else if (collision.name == "Goal")
        {
            run.Invoke();
        }
    }
}
