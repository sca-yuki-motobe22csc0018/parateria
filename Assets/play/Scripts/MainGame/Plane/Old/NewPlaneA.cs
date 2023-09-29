using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneA : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField]
    public float y;
    [SerializeField] public static float space = -17.7f;
    [SerializeField] public static float spawn = 97.35f;
    public static float Timer = 0.0f;
    float speed;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        x = -17.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            speed = GameContoroller.speed;
        }
        else
        {
            speed=0;
        }
        
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x,y);
        if (x < space)
        {
            x = spawn;
            Plane.transform.position = new Vector2(x,y);
        }
    }
}
