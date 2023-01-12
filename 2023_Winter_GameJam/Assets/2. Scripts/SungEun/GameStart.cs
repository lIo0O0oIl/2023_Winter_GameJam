using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameStart : MonoBehaviour
{
    public SpriteRenderer start;

    private void Start()
    {
        //Debug.Log("∏ﬁ¿Œæ¿¿Ãà‘!");
        //Debug.Log(start.name);
        start.DOFade(0, 1);
    }
}
