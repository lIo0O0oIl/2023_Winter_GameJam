using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question1 : MonoBehaviour
{
    public static Question1 Instance { get; private set; }

    public GameObject[] question;

    public int level = 1;

    private void Start()
    {
        Instance = this;
        level = 1;
    }

    public void Qusetion(bool a)
    {
        if (a)
        {
            if (level == 1)
            {
                question[0].SetActive(true);
            }
            else if (level == 2)
            {
                question[1].SetActive(true);
            }
            else
            {
                question[2].SetActive(true);
            }
        }
        else
        {
            if (level == 1)
            {
                question[0].SetActive(false);
            }
            else if (level == 2)
            {
                question[1].SetActive(false);
            }
            else
            {
                question[2].SetActive(false);
            }
        }
    }
}
