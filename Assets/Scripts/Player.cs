using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    [SerializeField] private float jumpForce = 350f;

    private int jumpCount = 0;
    bool end=false;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        jumpCount = 2;
    }

    void Update()
    {
        Transform myTransform = this.transform;

        // ç¿ïWÇéÊìæ
        Vector3 pos = myTransform.position;
        if (pos.x < -3)
        {
            pos.x += 0.002f;
            myTransform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 2)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
        }
    }
}

