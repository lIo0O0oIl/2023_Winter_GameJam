using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player2Move : MonoBehaviour
{
    public UnityEvent right, left, reset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹��");

        if (collision.name == "Next")
        {
            // ���� �߱�
        }


        if (collision.name == "RightRotate")
        {
            right.Invoke();
        }

        if (collision.name == "LeftRotate")
        {
            left.Invoke();
        }

        if (collision.name == "reset")
        {
            reset.Invoke();
        }
    }
}
