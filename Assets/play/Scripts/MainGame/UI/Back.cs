using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject back;
    float x;
    float speed=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3(0,0,0);
        if (this.gameObject.tag == "Right")
        {
            x = 28.8f-5;
        }
        else if (this.gameObject.tag == "Left")
        {
            x = 0.0f-5;
        }

    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        back.transform.position = new Vector2(x, 3.0f);
        if (x < -28.8f)
        {
            x = 28.7f;
            back.transform.position = new Vector2(28.8f, 3.0f);
        }
    }
}
