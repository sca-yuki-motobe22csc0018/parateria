using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStart : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField]
    public float y = -1.8f;
    [SerializeField] public float space = -17.7f;
    [SerializeField] public float spawn = 97.2f;
    float StartSet = PlaneStartLeft.StartSet;
    float speed;
    [SerializeField] float startPosX;


    // Start is called before the first frame update
    void Start()
    {
        x = startPosX + StartSet;
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
