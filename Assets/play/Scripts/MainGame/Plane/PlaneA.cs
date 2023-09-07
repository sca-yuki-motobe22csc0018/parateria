using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneA : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField] public static float speed = 5.0f;
    float space = -17.7792f;
    [SerializeField] public static float spawn = 180.7f;
    public static float Timer = 0.0f;
    //private float speedPlus=2.0f;
    public static float speedPlus = 0.8f;
    private float speedTimer=0f;

    // Start is called before the first frame update
    void Start()
    {
        x = -17.7792f;
        speed=5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 20)
        {
            speedTimer += Time.deltaTime;
            if (speedTimer >= 5)
            {
                speed += speedPlus;
                if (speed > 20)
                {
                    speed = 20;
                }
                speedTimer = 0;
            }
        }

        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x,-1.7f);
        if (x < space)
        {
            x = spawn;

            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }
}
