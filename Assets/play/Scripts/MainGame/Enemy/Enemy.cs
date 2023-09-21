using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = GameContoroller.speed;
    float posy;
    float posx;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameContoroller.speed + 6;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameContoroller.speed+6;
        posy = transform.position.y;
        posx = transform.position.x;
        posx= posx - (speed * Time.deltaTime);

        if (posx <= -10)
        {
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(posx, posy);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            transform.position = new Vector3(posx, posy);
        }
    }
}
