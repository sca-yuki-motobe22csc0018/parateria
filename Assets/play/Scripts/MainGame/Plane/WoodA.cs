using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodA : MonoBehaviour
{
    public GameObject plane;
    [SerializeField]
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.position=plane.transform.position+ new Vector3(x,y,0);
    }
}
