using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneC : MonoBehaviour
{
    public GameObject Plane;
    float x;
    public static float speed = PlaneA.speed;
    float space = -17.7792f;
    float spawn = PlaneA.spawn;
    public static float Timer = PlaneA.Timer;

    // Start is called before the first frame update
    void Start()
    {
        x = 17.7792f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlaneA.speed;
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.7f);
        if (x < space)
        {
            x = spawn;

            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }
}
