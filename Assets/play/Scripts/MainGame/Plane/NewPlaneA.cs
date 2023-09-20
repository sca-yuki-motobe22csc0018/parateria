using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneA : MonoBehaviour
{
    GameObject Plane;
    [SerializeField] public static float x;
    [SerializeField] public static float BigDefaultX=34.5f;
    [SerializeField] public static float SmallDefaultX=30.7f;
    [SerializeField] public static float BigGenerateX=-3.84f;
    [SerializeField] public static float SmallGenerateX = 0.0f;
    [SerializeField] public static float speed = GameContoroller.speed;

    public static bool spawnStage;

    // Start is called before the first frame update
    void Start()
    {
        Plane=this.gameObject;
        speed=GameContoroller.speed;
        if (Plane = GameObject.FindGameObjectWithTag("GroundBig"))
        {
            x=BigDefaultX;
        }
        else if (Plane = GameObject.FindGameObjectWithTag("GroundSmall"))
        {
            x=SmallDefaultX;
        }else if(Plane = GameObject.FindGameObjectWithTag("GroundStart")) {
            x=0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        speed=GameContoroller.speed;
        x -= speed * Time.deltaTime;
        Plane.transform.position = new Vector2(x, -1.8f);
        if (x < -35.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
