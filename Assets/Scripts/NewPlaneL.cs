using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane11 : MonoBehaviour
{
    public GameObject Plane;
    float x;
    float y = -1.7f;
    float yy;
    [SerializeField] public float speed = PlaneA.speed;
    float space=-17.8f;
    float spawn = 23.7f;
    float Timer = PlaneA.Timer;

    // Start is called before the first frame update
    void Start()
    {
        x = -11.9f;
        y = -1.7f;
    }

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            yy = -2.2f;
        }
        else
        {
            yy = -1.7f;
        }
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, y);
        if (x < space)
        {
            x = spawn;
            y = yy;
            Plane.transform.position = new Vector2(x, y);
        }
    }
}
