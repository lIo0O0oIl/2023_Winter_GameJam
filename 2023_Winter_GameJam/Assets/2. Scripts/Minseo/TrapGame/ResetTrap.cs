using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrap : MonoBehaviour
{
    public GameObject player;

    public float x;
    public float y;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = new Vector3(x, y, 0f);
            Debug.Log(player.transform.position);
        }
    }
}
