using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed = PlaneA.speed;
    [SerializeField] float posy = -3.5f;
    [SerializeField] float posx = 35.0f;
    float Timer = PlaneA.Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlaneA.speed+6;
        posy = transform.position.y;
        posx = transform.position.x;

        if (posx <= -10)
        {
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(posx - speed * Time.deltaTime, posy);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            transform.position = new Vector3(posx, posy);
        }
    }
}
