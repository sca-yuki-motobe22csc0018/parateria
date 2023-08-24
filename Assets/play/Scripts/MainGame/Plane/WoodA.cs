using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodA : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position=plane.transform.position+ new Vector3(5,-1,0);
    }
}
