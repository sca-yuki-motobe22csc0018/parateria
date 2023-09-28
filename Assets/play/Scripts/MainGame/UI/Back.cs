using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject back;
    float x;
    public float speed=1.0f;
    public float plusX;
    public float y=4.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3(0,0,0);
        if (this.gameObject.tag == "Right")
        {
            x = 24.5f+plusX;
        }
        else if (this.gameObject.tag == "Left")
        {
            x = 0.0f+plusX;
        }

    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        back.transform.position = new Vector2(x, y);
        if (x <= -10.5f)
        {
            x = 38.5f;
            back.transform.position = new Vector2(38.5f, y);
        }
    }
}
