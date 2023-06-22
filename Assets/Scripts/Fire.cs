using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneScript.speed;
    [SerializeField] float posy = -2.0f;
    [SerializeField] float posx = 30.0f;
    float Timer = PlaneScript.Timer;
    float num = 0;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(-2, 2);

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

        posy = num;
        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime, posy);

        if (posx <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
