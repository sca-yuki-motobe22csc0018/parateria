using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField]
    public float y=0;
    [SerializeField] public static float space = PlaneStartLeft.space;
    [SerializeField] public static float spawn = PlaneStartLeft.spawn;
    float speed;
    float baseY;

    // Start is called before the first frame update
    void Start()
    {
        x = 66.0f;
        baseY=y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameContoroller.start == true)
        {
            speed = GameContoroller.speed;
        }
        else
        {
            speed = 0;
        }
        y = 0.05f * Mathf.Sin(Time.time * 5.0f);
        Plane.transform.position += new Vector3(0, y, 0);
        if (transform.position.x <= -10)
        {
            y=baseY;
        }
    }
}
