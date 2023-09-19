using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneA : MonoBehaviour
{
    public GameObject Plane;
    [SerializeField] public static float x;
    [SerializeField] public static float speed = 7.0f;
    float space;
    [SerializeField] public static float spawn;
    public static float Timer = 0.0f;
    public static float speedPlus = 0.4f;
    private float speedTimer = 0f;
    private bool size;

    // Start is called before the first frame update
    void Start()
    {
        speed=7.0f;
        if (Plane = GameObject.FindGameObjectWithTag("GroundBig"))
        {
            x=34.5f;
        }
        else if (Plane = GameObject.FindGameObjectWithTag("GroundSmall"))
        {
            x=-30.7f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        Plane.transform.position=new Vector3(x,-1.8f);
        if (x < -35.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
