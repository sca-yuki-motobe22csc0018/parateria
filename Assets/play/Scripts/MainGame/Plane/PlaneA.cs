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
    public static float speedPlus = 2.0f;
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
        /*
        speedTimer+=1;
        if (speed < 12)
        {
            if (speedTimer >= 10000)
            {
                speed+=speedPlus;
                speedTimer=0;
            }
        }
        */
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x,-1.7f);
        if (x < space)
        {
            x = spawn;

            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }
}
