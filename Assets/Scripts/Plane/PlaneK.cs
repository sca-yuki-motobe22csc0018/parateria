using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneK : MonoBehaviour
{
    public GameObject Plane;
    float x;
    public static float speed = PlaneA.speed;
    float space = -17.7792f;
    float spawn = 188.7792f;
    public static float Timer = PlaneA.Timer;

    // Start is called before the first frame update
    void Start()
    {
        x = 156;
    }

    // Update is called once per frame
    void Update()
    {

        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.7f);
        if (x < space)
        {
            x = spawn;

            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }
}
