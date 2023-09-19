using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoroller : MonoBehaviour
{
    float Timer = PlaneA.Timer;
    int num = 0;
    [SerializeField] float speed;
    public Text StartText;
    private float textTime;
    private float countTime;
    public static bool start = false;
    private BigShark _SharkUp;
    private BigShark _SharkDown;
    private BigShark _Fox;



    // Start is called before the first frame update
    void Start()
    {
        StartText.text = "";
        Time.timeScale = 0;
        countTime = 4.0f;
        _SharkUp = GameObject.Find("BigSharkUP").GetComponent<BigShark>();
        _SharkDown = GameObject.Find("BigSharkDown").GetComponent<BigShark>();
        _Fox = GameObject.Find("BigFox").GetComponent<BigShark>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
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
        textTime += Time.unscaledDeltaTime * 5.0f * speed;
        color.a = Mathf.Sin(textTime);
        return color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (start)
        {
            string objName = other.gameObject.name;
            if ((objName == "地面1-1" || objName == "地面2-1" || objName == "地面3-1"
                || objName == "地面4-1" || objName == "地面5-1") && Time.timeScale >= 1)
            {
                Debug.Log(objName);
                num = Random.Range(1, 101);// ※ 1～5の範囲でランダムな整数値が返る
                if (num < 41)
                {
                    SpawnDraw1();
                }
                else if (num < 61)
                {
                    SpawnDraw2();
                }
                else if (num < 76)
                {
                    SpawnDraw3();
                }
                else if (num < 89)
                {
                    SpawnDraw4();
                }
                else if (num < 90)
                {
                    SpawnDraw5();
                }
                else if (num < 91)
                {
                    SpawnDraw6();
                }
                else if (num < 96)
                {
                    SpawnDraw7();
                }
                else if (num < 101)
                {
                    SpawnDraw8();
                }
            }
        }
    }
}