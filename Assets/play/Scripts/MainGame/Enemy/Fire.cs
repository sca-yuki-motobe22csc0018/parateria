using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneA.speed;
    
    [SerializeField] float posx;
    float Timer = PlaneA.Timer;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Timer = 0.0f;
        speed = PlaneA.speed+8;
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlaneA.speed + 8;
        
        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime,transform.position.y);

        if (posx <= -17)
        {
            Destroy(this.gameObject);
        }
    }
}
