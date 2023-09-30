using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFeverText : MonoBehaviour
{
    RectTransform _rT;
    float speed;
    float x,y;

    // Start is called before the first frame update
    void Start()
    {
        _rT = GetComponent<RectTransform>();
        RandPosX();
        RandPosY();
        RandSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        _rT.anchoredPosition = new Vector2(x, y);
        if(y < -1450.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void RandPosY()
    {
        int num = Random.Range(1,10);
        switch (num)
        {
            case 1:
                y = 490;
                break;
            case 2:
                y = 390;
                break;
            case 3:
                y = 290;
                break;
            case 4:
                y = 190;
                break;
            case 5:
                y = 90;
                break;
            case 6:
                y = -10;
                break;
            case 7:
                y = -110;
                break;
            case 8:
                y = -210;
                break;
            case 9:
                y = -310;
                break;
        }
    }

    void RandPosX()
    {
        int num = Random.Range(1,6);
        switch (num)
        {
            case 1:
                x = 1200;
                break;
            case 2:
                x = 1300;
                break;
            case 3:
                x = 1400;
                break;
            case 4:
                x = 1500;
                break;
            case 5:
                x = 1600;
                break;
        }
    }

    void RandSpeed()
    {
        int num = Random.Range(1, 6);
        switch (num)
        {
            case 1:
                speed = 700;
                break;
            case 2:
                speed = 800;
                break;
            case 3:
                speed = 900;
                break;
            case 4:
                speed = 1000;
                break;
            case 5:
                speed = 1050;
                break;
        }
    }
}
