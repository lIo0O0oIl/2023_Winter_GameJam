using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    public int tlqkf = 0;

    public void dkssud()
    {
        tlqkf = tlqkf + 1;
        gkdl();
    }

    public void dkssud1()
    {
        tlqkf = tlqkf - 1;
        gkdl1();
    }

    void gkdl()
    {
        switch (tlqkf)
        {
            case 1:
                transform.Rotate(0, 0, 90); // 입구 아래쪽
                break;
            case 2:
                transform.Rotate(0, 0, 90); // 입구 오른쪽
                break;
            case 3:
                transform.Rotate(0, 0, 90); // 입구 위쪽
                break;
            case 4:
                transform.Rotate(0, 0, 90); // 입구 왼쪽
                break;
            case 5:
                tlqkf = 1;
                goto case 1;
        }
    }

    void gkdl1()
    {
        switch (tlqkf)
        {
            case 1:
                transform.Rotate(0, 0, -90); // 입구 아래쪽
                break;
            case 2:
                transform.Rotate(0, 0, -90); // 입구 오른쪽
                break;
            case 3:
                transform.Rotate(0, 0, -90); // 입구 위쪽
                break;
            case 4:
                transform.Rotate(0, 0, -90); // 입구 왼쪽
                break;
            case 0:
                tlqkf = 1;
                goto case 1;
        }
    }

    bool rotate = false;

    public void test()
    {
        transform.DORotate(new Vector3(0, 0, 90), 2f).SetEase(Ease.InOutCubic);
    }

    int rotatee = 0;

    private void Update()
    {
        //transform.Rotate(0f, 0f, 90f * Time.deltaTime);
    }
}
