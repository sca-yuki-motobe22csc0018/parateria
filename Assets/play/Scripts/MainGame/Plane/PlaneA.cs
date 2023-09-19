using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneA : MonoBehaviour
{
    public GameObject Plane;
    float x;
    float space = -17.7792f;
    [SerializeField] public static float spawn = 180.7f;
    public static float Timer = 0.0f;
    [SerializeField] public static float speed = 7.0f;
    [SerializeField] float speedPlus = 0.4f;
    [SerializeField] float maxSpeed = 18.0f;
    [SerializeField] float changeTime = 4.0f;
    private float speedTimer = 0.0f;
    bool play;

    // Start is called before the first frame update
    void Start()
    {
        x = -17.7792f;
        play = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameContoroller.start)
        {
            speed = 0.0f;
        }
        else
        {
            if (!play)
            {
                speed = 7.0f;
                play = true;
            }

            if (speed < maxSpeed)
            {
                speedTimer += Time.deltaTime;
                if (speedTimer >= changeTime)
                {
                    speed += speedPlus;
                    Player.xc = 2.0f + 1 / (maxSpeed - speed);
                    if (speed > maxSpeed)
                    {
                        speed = maxSpeed;
                        Player.xc = 3.0f;
                    }
                    speedTimer = 0;
                }
            }

            x -= speed * Time.deltaTime;
            Plane.transform.position = new Vector2(x, -1.7f);
            if (x < space)
            {
                x = spawn;
                Plane.transform.position = new Vector2(x, -1.7f);
            }
        }
    }
}
