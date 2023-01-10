using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject question;
    [SerializeField]
    private GameObject point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            point.SetActive(true);
            question.SetActive(false);
        }
    }
}
