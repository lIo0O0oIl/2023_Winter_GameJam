using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PlaneRotatePuzzle : MonoBehaviour
{
    public GameObject plane, goal;

    public GameObject rightButton, leftButton, resetButton;

    int turn = 0, turn2 = 3;

    public void RightButton()
    {
        Debug.Log("");

        float z = plane.transform.eulerAngles.z - 90;

        plane.transform.DORotate(new Vector3(0, 0, z), 2f).SetEase(Ease.Linear);

        StartCoroutine(ColliderFalse(true));
    }

    public void LeftButton()
    {
        float z = plane.transform.eulerAngles.z + 90;

        plane.transform.DORotate(new Vector3(0, 0, z), 2f).SetEase(Ease.Linear);

        StartCoroutine(ColliderFalse(true));
    }

    IEnumerator ColliderFalse(bool right)
    {

        if (right)
        {
            rightButton.GetComponent<CircleCollider2D>().enabled = false;
            goal.GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSeconds(2f);
            goal.GetComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(.1f);
            rightButton.GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            leftButton.GetComponent<CircleCollider2D>().enabled = false;
            goal.GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSeconds(2f);
            goal.GetComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(.1f);
            leftButton.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void ReSetButton()
    {
        plane.transform.Rotate(0, 0, 180);
        goal.transform.position = new Vector3(1.197f, 3.054f, 0f);
    }
}
