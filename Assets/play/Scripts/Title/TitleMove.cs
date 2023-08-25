using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMove : MonoBehaviour
{
    public RectTransform Title;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        y= 30 * Mathf.Sin(Time.time);
        Title.anchoredPosition = new Vector2(0,y+100);
    }
}
