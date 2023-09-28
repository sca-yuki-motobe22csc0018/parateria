using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnim : MonoBehaviour
{
    public static bool move = false;
    public RectTransform _window;
    public RectTransform _button;
    public GameObject[] CF = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            StartCoroutine(WindowAnimation());
        }
    }

    float startY, startX;
    float endY, endX;
    float y, x;
    float nowTime, moveTime;
    void MoveStart(float toX, float toY, float time)
    {
        if (time == 0.0f)
        {
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            _button.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _button.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            return;
        }
        else
        {
            startX = x;
            startY = y;
            endX = toX;
            endY = toY;
        }
        moveTime = time;
        nowTime = 0.0f;
        return;
    }

    IEnumerator WindowAnimation()
    {
        move = true;
        x = 960;
        y = 540;
        MoveStart(1920, 1080, 0.1f);
        while (x < 1920.0f)
        {
            yield return null;
            nowTime += Time.deltaTime;
            if (nowTime > moveTime)
            {
                nowTime = moveTime;
            }
            x = nowTime / moveTime * (endX - startX) + startX;
            y = nowTime / moveTime * (endY - startY) + startY;
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _window.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            _button.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _button.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
        }
        
        for (int i = 0;i < 2; ++i)
        {
            CF[i].SetActive(true);
        }
    }
}
