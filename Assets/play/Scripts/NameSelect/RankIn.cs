using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankIn : MonoBehaviour
{
    private RectTransform myRect;
    float startY, startX;
    float endY, endX;
    float y, x;
    float nowTime, moveTime;
    void MoveStart(float toX, float toY, float time) {
        if(time == 0.0f) {
            return;
        } else {
            startX = x;
            startY = y;
            endX = toX;
            endY = toY;
        }
        moveTime = time;
        nowTime = 0.0f;
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    private void Update() {
        myRect.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.unscaledTime * 2) * 5);
    }
}
