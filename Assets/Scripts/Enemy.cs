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
        speed = 10.0f;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 1)
        {
            if (speed >= 24)
            {
                return;
                Timer = 0;
            }
            speed += 0.5f;
            Timer = 0;
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
