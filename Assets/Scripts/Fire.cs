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

        speed += 1.2f * (Time.time / 5);
        if (speed >= 20)
        {
            speed = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= 5)
        {
            if (speed >= 21.2)
            {
                speed = 21.2f;
                return;
            }
            speed += 1.2f;
            Timer = 0.0f;
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
