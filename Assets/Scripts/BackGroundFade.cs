using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackGroundFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 10);
    }
}
