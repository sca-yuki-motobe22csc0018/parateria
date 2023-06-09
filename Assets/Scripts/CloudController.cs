using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public RectTransform Cloud;
    float x;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Right")
        {
            x = 800;
        }
        else if(this.gameObject.tag == "Left")
        {
            x = 0.0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        x -= speed * Time.deltaTime;
        Cloud.anchoredPosition = new Vector2(x,0.0f);
        if(x < -800)
        {
            x = 800.0f;
            Cloud.anchoredPosition = new Vector2(800, 0);
        }
    }
}
