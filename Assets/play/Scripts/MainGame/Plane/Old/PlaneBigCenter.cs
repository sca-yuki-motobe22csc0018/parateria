using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBigCenter : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField]
    public float y;
    [SerializeField] public static float space = PlaneStartLeft.space;
    [SerializeField] public static float spawn = PlaneStartLeft.spawn;
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        x = 66.0f;
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
        y = 0.004f * Mathf.Sin(Time.time*2.5f);

        Plane.transform.position+= new Vector3(0,y,0);
    }
}
