using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneA : MonoBehaviour
{
    public GameObject Plane;
    float x;
    [SerializeField] public static float space = -17.7f;
    [SerializeField] public static float spawn = 17.7f;
    public static float Timer = 0.0f;
    float speed;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        x = -17.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            speed = GameContoroller.speed;
        }
        else
        {
            speed=0;
        }
        
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.7f);
        if (x < space)
        {
            x = spawn;
            Plane.transform.position = new Vector2(x, -1.7f);
        }
    }

    /*[SerializeField] public GameObject Plane;
    float x;
    float BigDefaultX=34.5f-0.1f;
    float SmallDefaultX=30.7f-0.1f;
    [SerializeField] public float BigGenerateX=-3.84f;
    [SerializeField] public static float SmallGenerateX = 0.0f;
    [SerializeField] public static float speed = GameContoroller.speed;

    public static bool spawnStage;

    // Start is called before the first frame update
    void Start()
    {
        Plane=this.gameObject;
        speed = GameContoroller.speed;
        if(Plane.tag == "GroundBig") {
            x = BigDefaultX;
        } else if(Plane.tag == "GroundSmall") {
            x =SmallDefaultX;
        }else if(Plane.tag == "GroundStart") {
            x=0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed=GameContoroller.speed;
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.8f);
        if (x <= -35.0f)
        {
            Debug.Log("Destroy"+this);
           Destroy(this.gameObject);
        }
    }
    */
}
