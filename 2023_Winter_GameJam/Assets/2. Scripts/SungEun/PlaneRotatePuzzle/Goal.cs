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
            // Ŭ���� ��¼��������
            Debug.Log("�� ������ Ŭ�����");
        }
    }
}
