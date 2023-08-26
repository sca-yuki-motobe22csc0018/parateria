using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneA.speed;
    [SerializeField] float posy = 5.0f;
    [SerializeField] float posx = 30.0f;
    float Timer = PlaneA.Timer;
    float num = 0;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, 2);
        Timer = 0.0f;
        speed = PlaneA.speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlaneA.speed;
        posy = num;
        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime, posy);

        if (posx <= -10)
        {
            Destroy(this.gameObject);
        }
    }
}
