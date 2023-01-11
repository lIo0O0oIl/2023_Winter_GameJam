using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "GoalLine")
        {
            // 클리어 어쩌구구국구
            Debug.Log("판 돌리기 클리어욥");
        }
    }
}
