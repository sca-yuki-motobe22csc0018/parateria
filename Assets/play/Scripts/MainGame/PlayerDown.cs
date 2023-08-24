using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDown : MonoBehaviour
{
    private int jumpCount = 0;
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)  
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Player.jumpCount = 0;
        }
    }
}
