using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
        }
    }
}
