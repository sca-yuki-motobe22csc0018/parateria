using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlaneA : MonoBehaviour
{
    GameObject Plane;
    [SerializeField] public static float x;
    [SerializeField] public static float BigDefaultX=34.5f;
    [SerializeField] public static float SmallDefaultX=30.7f;
    [SerializeField] public static float speed = 7.0f;
    [SerializeField] public static float BigGenerateX=-3.84f;
    [SerializeField] public static float SmallGenerateX = 0.0f;
    float space;
    int num = 0;
    public static float Timer = 0.0f;
    public static float speedPlus = 0.4f;
    [SerializeField] float maxSpeed = 18.0f;
    [SerializeField] float changeTime = 4.0f;
    private float speedTimer = 0f;
    bool play;
    private bool size;
    bool big;
    bool spawnStage;

    // Start is called before the first frame update
    void Start()
    {
        Plane=this.gameObject;
        speed=7.0f;
        if (Plane = GameObject.FindGameObjectWithTag("GroundBig"))
        {
            x=BigDefaultX;
            big=true;
        }
        else if (Plane = GameObject.FindGameObjectWithTag("GroundSmall"))
        {
            x=SmallDefaultX;
            big=false;
        }else if(Plane = GameObject.FindGameObjectWithTag("GroundStart")) {
            x=0;
            big=false;
        }
        play = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameContoroller.start) 
        {
            speed = 0.0f;
        } 
        else 
        {
            if(!play) 
            {
                speed = 7.0f;
                play = true;
            }

            if(speed < maxSpeed) 
            {
                speedTimer += Time.deltaTime;
                if(speedTimer >= changeTime) 
                {
                    speed += speedPlus;
                    Player.xc = 2.0f + 1 / (maxSpeed - speed);
                    if(speed > maxSpeed) 
                    {
                        speed = maxSpeed;
                        Player.xc = 3.0f;
                    }
                    speedTimer = 0;
                }
            }

            x -= speed * Time.deltaTime;
            Plane.transform.position = new Vector2(x, -1.8f);
        }
        if (x < -35.0f)
        {
            Destroy(this.gameObject);
        }
        num = Random.Range(1, 1);
        if(spawnStage == false) {
            if(big == true) {
                if(x <= BigGenerateX) {
                    SpawnDrawStage1();
                    spawnStage=true;
                }
            } else {
                if(big == false) {
                    if(x <= SmallGenerateX) {
                        SpawnDrawStage1();
                        spawnStage = true;
                    }
                }
            }
        }
    }

    private void StageOne() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_1");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(SmallDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    void SpawnDrawStage1() {
        StageOne();
        Debug.Log("Stage_1");
        return;
    }
}
