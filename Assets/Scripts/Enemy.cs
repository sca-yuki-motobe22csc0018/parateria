using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneScript.speed;
    [SerializeField] float posy = -3.5f;
    [SerializeField] float posx = 30.0f;
    float Timer = PlaneScript.Timer;

    // Start is called before the first frame update
    void Start()
    {
        //speed += 1.2f * (Time.time / 5);
        if (Timer % 60 == 0)
        {
            if (speed >= 12)
            {
                return;
            }
            speed += 0.25f;
        }
        if (speed >= 12)
        {
            speed = 12;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer % 60 == 0)
        {
            if (speed >= 12)
            {
                return;
            }
            speed += 0.25f;
        }
        if (speed >= 12)
        {
            speed = 12;
        }

        posy = transform.position.y;
        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime,posy);

        if(posx <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
