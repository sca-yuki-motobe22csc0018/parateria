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

    [SerializeField] public static float speed = 7.0f;
    public static float speedPlus = 0.4f;
    [SerializeField] float maxSpeed = 18.0f;
    [SerializeField] float changeTime = 4.0f;
    private float speedTimer = 0f;
    bool play;
    [SerializeField] public float speedmater=0;

    float brinkSpeed=1.1f;


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
    }

    // Update is called once per frame
    void Update()
    {
        speedmater=speed;
        if (!start)
        {
            speed = 0.0f;
            if (countTime > 0.0f)
            {
                countTime -= Time.unscaledDeltaTime;
                if (countTime <= 0.0f)
                {
                    countTime = 0.0f;
                    StartText.text = "";
                    start = true;
                }
                else if (countTime <= 0.9f)
                {
                    StartText.text = "GO!!!";
                    StartText.color = GetAlphaColor(StartText.color);

                }
                else
                {
                    int num = (int)countTime;
                    StartText.text = Mathf.Clamp(num, 0, 100).ToString();
                    StartText.color = GetAlphaColor(StartText.color);
                }
            }
        }else {
            if(!play) {
                speed = 7.0f;
                play = true;
            }

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
        textTime += Time.unscaledDeltaTime * 5.0f * brinkSpeed;
        color.a = Mathf.Sin(textTime);
        return color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (start)
        {
            string objName = other.gameObject.name;
            if (spawn == false)
            {
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
                        //stage8
                        //SpawnDrawStage8();
                        SpawnDrawStage3();
                    }
                }
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
                 if ((objName == "Stage_11" || objName == "Stage_Small_Left" 
                    || objName == "Stage_Big_Left") && Time.timeScale >= 1)
                 {
                     spawn=false;
                 }
             }
        }
    }

    private void Stage1() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_1");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(SmallDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage2() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_2");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(SmallDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage3() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_3");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(BigDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage4() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_4");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(SmallDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage5() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_5");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(BigDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage6() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_6");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(BigDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage7() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_7");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(BigDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage8() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_8");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(BigDefaultX, -1.8f, 0), Quaternion.identity);
        return;
    }
    private void Stage9() {
        GameObject Stage_prefab = Resources.Load<GameObject>("Stage_9");
        GameObject Stage = Instantiate(Stage_prefab, new Vector3(SmallDefaultX, -1.8f, 0), Quaternion.identity);
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
        Stage6();
        Debug.Log("Stage_6");
        return;
    }
    void SpawnDrawStage7() {
        Stage7();
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