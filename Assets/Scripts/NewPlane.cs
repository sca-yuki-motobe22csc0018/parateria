using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlane : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField] float speed;
    public int space=20;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Right")
        {
            x = space;
        }
        else if (this.gameObject.tag == "Left")
        {
            x = 0.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, 0.0f);
        if (x < -space)
        {
            x = space;
            Plane.transform.position = new Vector2(space, 0);
        }
    }
}
