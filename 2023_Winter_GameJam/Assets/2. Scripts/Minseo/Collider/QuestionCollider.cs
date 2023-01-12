using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestionCollider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject question;
    [SerializeField]
    private GameObject point;

    public void OnPointerDown(PointerEventData eventData)
    {
        point.SetActive(false);
        question.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        point.SetActive(true);
        question.SetActive(false);
    }
}
