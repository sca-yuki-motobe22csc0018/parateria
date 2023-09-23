using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneA : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField] public static float space = -17.7f - 2;
    [SerializeField] public static float spawn = 177.0f - 2;
    public static float Timer = 0.0f;
    float speed = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        x = -17.7f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameContoroller.speed;
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.7f);
        if (x < space)
        {
            x = spawn;
            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }
}
