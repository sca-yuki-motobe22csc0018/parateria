using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneScript.speed;
    [SerializeField] float posy = 5.0f;
    [SerializeField] float posx = 30.0f;
    float Timer = PlaneScript.Timer;
    float num = 0;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 2);
        speed = 5.0f;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 1)
        {
            if (speed >= 18)
            {
                return;
                Timer = 0;
            }
            speed += 0.5f;
            Timer = 0;
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
