using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrap : MonoBehaviour
{
    public Vector3 playerPos;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.transform.position = playerPos;
        }
    }
}
