using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearSceneColor : MonoBehaviour
{
    SpriteRenderer scolor;

    public GameObject background;

    public List<Color> colors = new List<Color>();

    public float t = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        scolor = background.GetComponent<SpriteRenderer>();
        StartCoroutine(Color());
    }

    IEnumerator Color()
    {
        while (true)
        {
            scolor.color = colors[0];
            yield return new WaitForSeconds(t);
            scolor.color = colors[1];
            yield return new WaitForSeconds(t);
            scolor.color = colors[2];
            yield return new WaitForSeconds(t);
            scolor.color = colors[3];
            yield return new WaitForSeconds(t);
            scolor.color = colors[4];
            yield return new WaitForSeconds(t);
            scolor.color = colors[5];
            yield return new WaitForSeconds(t);
            scolor.color = colors[6];
            yield return new WaitForSeconds(t);
            scolor.color = colors[7];
            yield return new WaitForSeconds(t);
            scolor.color = colors[8];
            yield return new WaitForSeconds(t);
            scolor.color = colors[9];
            yield return new WaitForSeconds(t);
            scolor.color = colors[10];
            yield return new WaitForSeconds(t);
        }
    }
}
