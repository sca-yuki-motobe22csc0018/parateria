using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject Cloud;
    float x;
    private float speed=7;
    

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Right")
        {
            x = 19.20f;
        }
        else if(this.gameObject.tag == "Left")
        {
            x = 0.0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime/4;
        Cloud.transform.position = new Vector2(x,-0.4f);
        if(x <= -19.20f)
        {
            x = 19.19f;
            Cloud.transform.position = new Vector2(x, -0.4f);
        }
    }
}
