using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSmallLeft : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField]
    public float y;
    [SerializeField] public static float space = PlaneStartLeft.space;
    [SerializeField] public static float spawn = PlaneStartLeft.spawn;
    float StartSet = PlaneStartLeft.StartSet;
    float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        x = 17.7f+StartSet;
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

        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, y);
        if (x < space)
        {
            x = spawn;
            Plane.transform.position = new Vector2(x, y);
        }
    }
}
