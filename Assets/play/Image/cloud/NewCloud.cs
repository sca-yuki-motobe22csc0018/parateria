using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCloud : MonoBehaviour
{
    private float speed = 4;
    int num;
    [SerializeField] public float x;
    // Start is called before the first frame update
    void Start()
    {
        num=Random.Range(2,8);
        speed=num;
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime / 4;
        this.transform.position = new Vector2(x, -0.4f);
        if (x <= -19.20f)
        {
            x = 40.0f;
            this.transform.position = new Vector2(x, -0.4f);
            num = Random.Range(3, 8);
            speed = num;
        }
    }
}
