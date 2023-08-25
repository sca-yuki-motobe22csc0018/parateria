using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDown : MonoBehaviour
{
    private int jumpCount = 0;
    public GameObject player;
    public GameObject playerRunIm;
    public GameObject playerJumpIm;


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
            playerJumpIm.SetActive(false);
            playerRunIm.SetActive(true);
        }
    }
}
