using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSet : MonoBehaviour
{
    public static BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col=gameObject.GetComponent<BoxCollider2D>();
        col.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
