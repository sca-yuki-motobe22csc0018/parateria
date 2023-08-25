using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineMoon : MonoBehaviour
{
    void Start()
    {
        transform.position=new Vector3(0, -5.18f,0);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,0, -5.5f*Time.deltaTime));
    }
}
