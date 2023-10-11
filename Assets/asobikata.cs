using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asobikata : MonoBehaviour
{
    [SerializeField] Image[] window = new Image[5];
    [SerializeField] GameObject[] button = new GameObject[2];
    int change;
    private TitleController tc;
    public static bool move=false;
    private RectTransform _rT;

    // Start is called before the first frame update
    void Start()
    {
        change = 0;
        button[0].SetActive(false);
        window[change].enabled = true;
        for(int i = 1;i < 5; ++i)
        {
            window[i].enabled = false;
        }
        tc = GameObject.Find("TitleController").GetComponent<TitleController>();
    }

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
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
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
        _rT=window[change].GetComponent<RectTransform>();
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
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
        }
    }


    public void Window(int num)
    {
        tc.SE();
        if (num == 1)
        {
            if (change != 4)
            {
                button[0].SetActive(true);
                window[change].enabled = false;
                ++change;
                window[change].enabled = true;
            }
            if(change == 4)
            {
                button[1].SetActive(false);
            }
        }
        else if (num == 2)
        {
            if(change != 0)
            {
                button[1].SetActive(true);
                window[change].enabled = false;
                --change;
                window[change].enabled = true;
            }
            if (change == 0)
            {
                button[0].SetActive(false);
            }
        }
        else if (num == 3)
        {
            change = 0;
            button[0].SetActive(false);
            button[1].SetActive(true);
            window[change].enabled = true;
            for (int i = 1; i < 5; ++i)
            {
                window[i].enabled = false;
            }
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 960);
            _rT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 540);
            gameObject.SetActive(false);
        }
    }
}
