using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneR : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField] float speed;
    public float space = -15f;
    public float spawn = 20.7f;

    // Start is called before the first frame update
    void Start()
    {
            x = 11.9f;
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
