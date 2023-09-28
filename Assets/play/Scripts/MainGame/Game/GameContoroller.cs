using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoroller : MonoBehaviour
{
    float BigDefaultX = 34.5f-0.5f;
    float SmallDefaultX = 30.7f-0.5f;
    int num = 0;
    int stagenum;
    public Text StartText;
    private float textTime;
    private float countTime;
    public static bool start = false;
    private BigShark _SharkUp;
    private BigShark _SharkDown;
    private BigShark _Fox;
    private bool spawn;
    private bool spawn2;

    [SerializeField] public static float speed = 7.0f;
    public static float speedPlus = 0.4f;
    [SerializeField] float maxSpeed = 18.0f;
    [SerializeField] float changeTime = 4.0f;
    private float speedTimer = 0f;
    bool play;
    [SerializeField] public float speedmater=0;
    [SerializeField] public GameObject[] Stage = new GameObject[20];

    float brinkSpeed=1.5f;

    public static bool stage1set;
    public static bool stage2set;
    public static bool stage3set;
    public static bool stage4set;
    public static bool stage5set;
    public static bool stage6set;
    public static bool stage7set;
    public static bool stage8set;
    public static bool stage9set;


    // Start is called before the first frame update
    void Start() 
    {
        start = false;
        StartText.text = "";
        countTime = 4.0f;
        _SharkUp = GameObject.Find("BigSharkUP").GetComponent<BigShark>();
        _SharkDown = GameObject.Find("BigSharkDown").GetComponent<BigShark>();
        _Fox = GameObject.Find("BigFox").GetComponent<BigShark>();
        play = false;
        Stage[0].SetActive(false);
        Stage[1].SetActive(false);
        Stage[2].SetActive(false);
        Stage[3].SetActive(false);
        Stage[4].SetActive(false);
        Stage[5].SetActive(false);
        Stage[6].SetActive(false);
        Stage[7].SetActive(false);
        Stage[8].SetActive(false);
        Stage[9].SetActive(false);
        stage1set = false;
        stage2set = false;
        stage3set = false;
        stage4set = false;
        stage5set = false;
        stage6set = false;
        stage7set = false;
        stage8set = false;
        stage9set = false;
        speed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        speedmater=speed;
        if (!start||play)
        {
            if (countTime > 0.0f)
            {
                countTime -= Time.deltaTime;
                if (countTime <= 0.0f)
                {
                    countTime = 0.0f;
                    StartText.text = "";
                    play=false;
                    
                }
                else if (countTime <= 0.999f)
                {
                    StartText.fontSize=300;
                    StartText.text = "GO!!!";
                    StartText.color = GetAlphaColor(StartText.color);
                    start = true;
                    speed = 7.0f;
                    play = true;
                }
                else
                {
                    int num = (int)countTime;
                    StartText.text = Mathf.Clamp(num, 0, 100).ToString();
                    StartText.color = GetAlphaColor(StartText.color);
                }
            }
        }else {
            if(speed < maxSpeed) {
                speedTimer += Time.deltaTime;
                if(speedTimer >= changeTime) {
                    speed += speedPlus;
                    Player.xc = 2.0f + 1 / (maxSpeed / speed);
                    if(speed > maxSpeed) {
                        speed = maxSpeed;
                        Player.xc = 3.0f;
                    }
                    speedTimer = 0;
                }
            }
        }
    }

    void SpawnDraw1()
    {
        _Fox.cf();
        ObjectItem(17, 0);
        ObjectEnemy(25, -2.5f);
        Debug.Log("1");
        return;
    }

    void SpawnDraw2()
    {
        ObjectFire(25, 0);
        Debug.Log("2");
        return;
    }

    void SpawnDraw3()
    {
        _Fox.cf();
        ObjectEnemy(25, -2.5f);
        ObjectItem(21, 0);
        ObjectTiger(17, -1.5f);
        Debug.Log("3");
        return;
    }

    void SpawnDraw4()
    {
        _Fox.cf();
        ObjectEnemy(17, -2.5f);
        ObjectItem(21, 0.5f);
        ObjectFire(25, 0);
        Debug.Log("4");
        return;
    }

    void SpawnDraw5()
    {
        _SharkDown.cf();
        ObjectWater(30, -1);
        Debug.Log("5");
        return;
    }

    void SpawnDraw6()
    {
        _SharkUp.cf();
        ObjectWater(30, 2);
    }

    void SpawnDraw7()
    {
        _SharkDown.cf();
        ObjectWaterSlashDown(30, -1);
        return;
    }

    void SpawnDraw8()
    {
        _SharkUp.cf();
        ObjectWaterSlashUp(30, 2);
    }

    private void ObjectEnemy(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    private void ObjectTiger(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Tiger");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    private void ObjectFire(float x, float y)
    {
        GameObject Fire_prefab = Resources.Load<GameObject>("Fire");
        GameObject Fire = Instantiate(Fire_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    private void ObjectItem(float x, float y)
    {
        GameObject Item_prefab = Resources.Load<GameObject>("Item");
        GameObject Item = Instantiate(Item_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }
    private void ObjectWater(float x, float y)
    {
        GameObject Water_prefab = Resources.Load<GameObject>("Water");
        GameObject Water = Instantiate(Water_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    private void ObjectWaterSlashUp(float x, float y)
    {
        GameObject Water_prefab = Resources.Load<GameObject>("WaterSlashUp");
        GameObject Water = Instantiate(Water_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    private void ObjectWaterSlashDown(float x, float y)
    {
        GameObject Water_prefab = Resources.Load<GameObject>("WaterSlashDown");
        GameObject Water = Instantiate(Water_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    Color GetAlphaColor(Color color)
    {
        textTime += Time.deltaTime * brinkSpeed;
        color.a = Mathf.Cos(textTime);
        if (color.a<=0)
        {
            textTime=0.0f;
            color.a = Mathf.Cos(textTime);
        }
        return color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (start)
        {

            string objName = other.gameObject.name;
            if (objName == "Stage_12")
            {
                Debug.Log(objName);
                stagenum = Random.Range(1, 4);
                if (stagenum == 1)
                {
                    SpawnDrawStage2();
                }
                if (stagenum == 2)
                {
                    SpawnDrawStage4();
                }
                if (stagenum == 3)
                {
                    SpawnDrawStage9();
                }
            }
            if (objName == "Stage_Small_Right")
            {

                Debug.Log(objName);
                stagenum = Random.Range(1, 6);
                if (stagenum == 1)
                {
                    SpawnDrawStage3();
                }
                if (stagenum == 2)
                {
                    SpawnDrawStage5();
                }
                if (stagenum == 3)
                {
                    SpawnDrawStage6();
                }
                if (stagenum == 4)
                {
                    SpawnDrawStage7();
                }
                if (stagenum == 5)
                {
                    SpawnDrawStage8();
                }
            }
            if (spawn == false)
            {
                
                if ((objName == "Stage_11" || objName == "Stage_Small_Left"
                    || objName == "Stage_Big_Left") && Time.timeScale >= 1)
                {
                    Debug.Log(objName);
                    num = Random.Range(1, 101);// Å¶ 1Å`5ÇÃîÕàÕÇ≈ÉâÉìÉ_ÉÄÇ»êÆêîílÇ™ï‘ÇÈ

                    if (num < 41)
                    {
                        SpawnDraw1();
                        spawn = true;
                    }
                    else if (num < 61)
                    {
                        SpawnDraw2();
                        spawn = true;
                    }
                    else if (num < 76)
                    {
                        SpawnDraw3();
                        spawn = true;
                    }
                    else if (num < 89)
                    {
                        SpawnDraw4();
                        spawn = true;
                    }
                    else if (num < 90)
                    {
                        SpawnDraw5();
                        spawn = true;
                    }
                    else if (num < 91)
                    {
                        SpawnDraw6();
                        spawn = true;
                    }
                    else if (num < 96)
                    {
                        SpawnDraw7();
                        spawn = true;
                    }
                    else if (num < 101)
                    {
                        SpawnDraw8();
                        spawn = true;
                    }
                }
            }else 
             if (spawn == true)
             {
                 if ((objName == "Stage_12" || objName == "Stage_Small_Right" 
                    || objName == "Stage_Big_Right") && Time.timeScale >= 1)
                 {
                     spawn=false;
                 }
             }

            if (spawn2 == false)
            {

                if ((objName == "Stage_12" || objName == "Stage_Small_Right"
                    || objName == "Stage_Big_Right") && Time.timeScale >= 1)
                {
                    Debug.Log(objName);
                    num = Random.Range(1, 101);// Å¶ 1Å`5ÇÃîÕàÕÇ≈ÉâÉìÉ_ÉÄÇ»êÆêîílÇ™ï‘ÇÈ

                    if (num < 41)
                    {
                        SpawnDraw1();
                        spawn2 = true;
                    }
                    else if (num < 61)
                    {
                        SpawnDraw2();
                        spawn2 = true;
                    }
                    else if (num < 76)
                    {
                        SpawnDraw3();
                        spawn2 = true;
                    }
                    else if (num < 89)
                    {
                        SpawnDraw4();
                        spawn2 = true;
                    }
                    else if (num < 90)
                    {
                        SpawnDraw5();
                        spawn2 = true;
                    }
                    else if (num < 91)
                    {
                        SpawnDraw6();
                        spawn2 = true;
                    }
                    else if (num < 96)
                    {
                        SpawnDraw7();
                        spawn2 = true;
                    }
                    else if (num < 101)
                    {
                        SpawnDraw8();
                        spawn2 = true;
                    }
                }
            }
            else
             if (spawn2 == true)
            {
                if ((objName == "Stage_11" || objName == "Stage_Small_Left"
                    || objName == "Stage_Big_Left") && Time.timeScale >= 1)
                {
                    spawn2 = false;
                }
            }
        }
    }

    private void Stage1() {
        //Stage[1].SetActive(true);
        return;
    }
    private void Stage2() {
        Stage[0].SetActive(true);
        Stage[1].SetActive(true);
        Stage[2].SetActive(false);
        Stage[3].SetActive(false);
        return;
    }
    private void Stage3() {
        Stage[4].SetActive(true);
        Stage[5].SetActive(true);
        Stage[6].SetActive(false);
        Stage[7].SetActive(false);
        Stage[8].SetActive(false);
        Stage[9].SetActive(false);
        return;
    }
    private void Stage4() {
        Stage[0].SetActive(false);
        Stage[1].SetActive(false);
        Stage[2].SetActive(true);
        Stage[3].SetActive(false);
        return;
    }
    private void Stage5() {
        Stage[4].SetActive(false);
        Stage[5].SetActive(false);
        Stage[6].SetActive(true);
        Stage[7].SetActive(false);
        Stage[8].SetActive(false);
        Stage[9].SetActive(false);
        return;
    }
    private void Stage6() {
        Stage[4].SetActive(false);
        Stage[5].SetActive(false);
        Stage[6].SetActive(false);
        Stage[7].SetActive(true);
        Stage[8].SetActive(false);
        Stage[9].SetActive(false);
        return;
    }
    private void Stage7() {
        Stage[4].SetActive(false);
        Stage[5].SetActive(false);
        Stage[6].SetActive(false);
        Stage[7].SetActive(false);
        Stage[8].SetActive(true);
        Stage[9].SetActive(false);
        return;
    }
    private void Stage8() {
        Stage[4].SetActive(false);
        Stage[5].SetActive(false);
        Stage[6].SetActive(false);
        Stage[7].SetActive(false);
        Stage[8].SetActive(false);
        Stage[9].SetActive(true);
        return;
    }
    private void Stage9() {
        Stage[0].SetActive(false);
        Stage[1].SetActive(false);
        Stage[2].SetActive(false);
        Stage[3].SetActive(true);

        return;
    }
    void SpawnDrawStage1() {
        Stage1();
        Debug.Log("Stage_1");
        return;
    }
    void SpawnDrawStage2() {
        Stage2();
        Debug.Log("Stage_2");
        return;
    }
    void SpawnDrawStage3() {
        Stage3();
        Debug.Log("Stage_3");
        return;
    }
    void SpawnDrawStage4() {
        Stage4();
        Debug.Log("Stage_4");
        return;
    }
    void SpawnDrawStage5() {
        Stage5();
        Debug.Log("Stage_5");
        return;
    }
    void SpawnDrawStage6() {
        Stage8();
        Debug.Log("Stage_6");
        return;
    }
    void SpawnDrawStage7() {
        Stage8();
        Debug.Log("Stage_7");
        return;
    }
    void SpawnDrawStage8() {
        Stage8();
        Debug.Log("Stage_8");
        return;
    }
    void SpawnDrawStage9() {
        Stage9();
        Debug.Log("Stage_9");
        return;
    }
}