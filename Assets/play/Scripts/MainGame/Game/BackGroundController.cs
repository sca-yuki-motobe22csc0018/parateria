using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackGroundController : MonoBehaviour
{
    float colorTime;
    float nowTime;
    int changeTime;
    Color Morning = new Color32(105, 178, 201, 1);
    Color Noon = new Color32(101, 178, 206, 1);
    Color Evening = new Color32(60, 110, 133, 1);
    Color Night = new Color32(26, 41, 59, 1);
    Camera backGround;
    [SerializeField] float Change;
    void Start()
    {
        colorTime = 0.0f;
        nowTime = 0.0f;
        changeTime = 1;
        backGround = Camera.main;
        backGround.backgroundColor = Noon;
    }

    void Update()
    {
        if(nowTime <= 60)
        {
            nowTime += Time.deltaTime;
            colorTime = (nowTime % Change) / Change;
            if (nowTime > Change)
            {
                colorTime = 1.0f;
            }

            switch (changeTime)
            {
                case 1:
                    backGround.backgroundColor = Color.Lerp(Morning, Noon,  Mathf.PingPong(colorTime, 1));
                    break;
                case 2:
                    backGround.backgroundColor = Color.Lerp(Noon, Evening, Mathf.PingPong(colorTime, 1));
                    break;
                case 3:
                    backGround.backgroundColor = Color.Lerp(Evening, Night, Mathf.PingPong(colorTime, 1));
                    break;
                case 4:
                    backGround.backgroundColor = Color.Lerp(Night, Night, Mathf.PingPong(colorTime, 1));
                    break;
                case 5:
                    backGround.backgroundColor = Color.Lerp(Night, Night, Mathf.PingPong(colorTime, 1));
                    break;
                case 6:
                    backGround.backgroundColor = Color.Lerp(Night, Morning, Mathf.PingPong(colorTime, 1));
                    break;
            }
            if(nowTime >= Change)
            {
                nowTime = 0.0f;
                ++changeTime;
                if(changeTime == 7)
                {
                    changeTime = 1;
                }
            }
        }
    }
}