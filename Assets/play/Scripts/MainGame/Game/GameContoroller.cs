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

    // Start is called before the first frame update
    void Start()
    {
        StartText.text = "";
        Time.timeScale = 0;
        countTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime > 0.0f)
        {
            countTime -= Time.unscaledDeltaTime;
            if (countTime <= 0.0f)
            {
                countTime = 0.0f;
                Time.timeScale = 1;
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
        Timer += Time.deltaTime;
    }

    void SpawnDraw1()
    {
        ObjectEnemy(25,-1);
        Debug.Log("1");
        return;
    }

    void SpawnDraw2()
    {
        ObjectFire(25,0);
        Debug.Log("2");
        return;
    }

    void SpawnDraw3()
    {
        ObjectEnemy(25,-1);
        ObjectEnemy(17,-1);
        Debug.Log("3");
        return;
    }

    void SpawnDraw4()
    {
        ObjectEnemy(17,-1);
        ObjectFire(25,0);
        Debug.Log("4");
        return;
    }

    void SpawnDraw5()
    {
        int num = Random.Range(0,2);
        if (num == 0)
        {
            ObjectWater(30, 2);
        }else
        if (num == 1)
        {
            ObjectWater(30, -1);
        }

        Debug.Log("5");
        return;
    }

    private void ObjectEnemy(float x,float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
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

    Color GetAlphaColor(Color color)
    {
        textTime += Time.unscaledDeltaTime * 5.0f * speed;
        color.a = Mathf.Sin(textTime);
        return color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objName = other.gameObject.name;
        if ((objName == "地面1-1" || objName == "地面2-1" || objName == "地面3-1"
            || objName == "地面4-1" || objName == "地面5-1") && Time.timeScale == 1)
        {
            Debug.Log(objName);
            num = Random.Range(1, 6);// ※ 1～5の範囲でランダムな整数値が返る
            switch (num)
            {
                case 1:
                    SpawnDraw1();
                    break;
                case 2:
                    SpawnDraw2();
                    break;
                case 3:
                    SpawnDraw3();
                    break;
                case 4:
                    SpawnDraw4();
                    break;
                case 5:
                    SpawnDraw5();
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        string objName = other.gameObject.name;
        if ((objName == "地面5-3")&& Time.timeScale == 1)
        {
            PlaneA.speed += PlaneA.speedPlus;
        }
    }
}