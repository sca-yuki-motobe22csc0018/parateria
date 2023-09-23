using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float speed = GameContoroller.speed;
    
    float posx;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = GameContoroller.speed+8;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameContoroller.speed + 8;
        
        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime,transform.position.y);

        if (posx <= -35)
        {
            Destroy(this.gameObject);
        }
    }
}
