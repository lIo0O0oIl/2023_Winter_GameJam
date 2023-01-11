using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlaneRotatePuzzle : MonoBehaviour
{
    public GameObject plane, goal;

    public GameObject rightButton, leftButton, resetButton;

    public Vector3 goalVector;
    public Vector3 planeVector;

    int turn = 0, turn2 = 3;

    public void RightButton()
    {
        float z = plane.transform.eulerAngles.z - 90;

        plane.transform.DORotate(new Vector3(0, 0, z), 2f).SetEase(Ease.InCubic);

        StartCoroutine(ColliderFalse());
    }

    public void LeftButton()
    {
        float z = plane.transform.eulerAngles.z + 90;

        plane.transform.DORotate(new Vector3(0, 0, z), 2f).SetEase(Ease.InCubic);

        StartCoroutine(ColliderFalse());
    }

    IEnumerator ColliderFalse()
    {
        rightButton.GetComponent<CircleCollider2D>().enabled = false;
        leftButton.GetComponent<CircleCollider2D>().enabled = false;
        resetButton.GetComponent<CircleCollider2D>().enabled = false;
        //goal.GetComponent<Rigidbody2D>().gravityScale = 0;
        yield return new WaitForSeconds(2.5f);
        //goal.GetComponent<Rigidbody2D>().gravityScale = 1;
        //yield return new WaitForSeconds(.1f);
        rightButton.GetComponent<CircleCollider2D>().enabled = true;
        leftButton.GetComponent<CircleCollider2D>().enabled = true;
        resetButton.GetComponent<CircleCollider2D>().enabled = true;
        //yield return null;
    }

    public void ReSetButton()
    {
        //plane.transform.Rotate(0, 0, 180);
        //goal.transform.position = new Vector3(1.197f, 3.054f, 0f);
        plane.transform.rotation = Quaternion.Euler(planeVector);
        goal.transform.position = goalVector;
    }
}
