using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newNightColor : MonoBehaviour
{
    public SpriteRenderer sp;
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        sp= GetComponent<SpriteRenderer>();
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BackGroundController.night == true)
        {
            if (a < 0.8f)
            {
                a += 0.1f*Time.deltaTime;
            }
        }
        else
        {
            if (a > 0)
            {
                a -= 0.1f * Time.deltaTime;
            }
        }
        if (Player.excellent == true)
        {
            a = 0;
        }
        sp.color = new Color(0, 0, 0, a);
    }
}
