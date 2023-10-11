using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightColor : MonoBehaviour
{
    SpriteRenderer mr;
    byte a=0;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        a=0;
        mr=GetComponent<SpriteRenderer>();
        mr.material.color = new Color32(255,255,255,255);
        mr.material.color=mr.material.color-new Color32(0,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.color = new Color32(0, 0, 0, a);
        if (BackGroundController.night == true)
        {
            timer+=1;
            if (timer > 3)
            {
                if (a < 220)
                {
                    a += 1;
                }
                timer=0;
            }
        }else
            if (BackGroundController.night == false)
        {
            timer += 1;
            if (timer > 2)
            {
                if (a > 0)
                {
                    a -= 1;
                }
                timer = 0;
            }
        }
        if (Player.excellent==true)
        {
            a=0;
        }
    }
}
