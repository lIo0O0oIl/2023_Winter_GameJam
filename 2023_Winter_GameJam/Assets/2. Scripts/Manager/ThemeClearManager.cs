using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ThemeClearManager : MonoBehaviour
{
    public GameObject land, sea;
    public GameObject landText, seaText;

    public void ThemeStart()
    {
        if (File.Exists(Application.dataPath + "/8. Data/SaveData.txt"))
        {
            //Debug.Log("ºÒ·¯¿Ô½·´ô!");
            DataManager.Instance.Load();
        }
        

        if (DataManager.Instance.playData.landClear == true)
        {
            land.GetComponent<BoxCollider2D>().enabled = false;
            land.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            landText.SetActive(true);
        }

        if (DataManager.Instance.playData.seaClear == true)
        {
            sea.GetComponent<BoxCollider2D>().enabled = false;
            sea.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            seaText.SetActive(true);
        }

        if (DataManager.Instance.playData.landClear && DataManager.Instance.playData.seaClear)
        {
            Debug.Log("Å¬¸®¾î");
        }
    }
}
