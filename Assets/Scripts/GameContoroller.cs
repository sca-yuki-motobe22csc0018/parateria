using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoroller : MonoBehaviour
{
    float Timer = PlaneScript.Timer;
    int num = 0;
    [SerializeField] float speed;
    public Text StartText;
    private float textTime;
    private float countTime;
    bool start = false;

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

        if (Timer >= 5)
        {
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
            Timer = 0.0f;
        }
    }

    void SpawnDraw1()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("1");
        return;
    }

    void SpawnDraw2()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("2");
        return;
    }

    void SpawnDraw3()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("3");
        return;
    }

    void SpawnDraw4()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("4");
        return;
    }

    void SpawnDraw5()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("5");
        return;
    }

    private void ObjectEnemy()
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
        GameObject Enemy = Instantiate(Enemy_prefab);
        return;
    }

    private void ObjectFire()
    {
        GameObject Fire_prefab = Resources.Load<GameObject>("Fire");
        GameObject Fire = Instantiate(Fire_prefab);
        return;
    }

    private void ObjectItem()
    {
        GameObject Item_prefab = Resources.Load<GameObject>("Item");
        GameObject Item = Instantiate(Item_prefab);
        return;
    }

    Color GetAlphaColor(Color color)
    {
        textTime += Time.unscaledDeltaTime * 5.0f * speed;
        color.a = Mathf.Sin(textTime);
        return color;
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoroller : MonoBehaviour
{
    float Timer = PlaneScript.Timer;
    int num = 0;
    [SerializeField] float speed;
    public Text StartText;
    private float textTime;
    private float countTime;


    // Start is called before the first frame update
    void Start()
    {
        StartText.text = "";
        Time.timeScale = 0;
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

        if (Timer >= 5)
        {
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
            Timer = 0.0f;
        }
    }

    void SpawnDraw1()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("1");
        return;
    }

    void SpawnDraw2()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("2");
        return;
    }

    void SpawnDraw3()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("3");
        return;
    }

    void SpawnDraw4()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("4");
        return;
    }

    void SpawnDraw5()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("5");
        return;
    }

    private void ObjectEnemy()
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
        GameObject Enemy = Instantiate(Enemy_prefab);
        return;
    }

    private void ObjectFire()
    {
        GameObject Fire_prefab = Resources.Load<GameObject>("Fire");
        GameObject Fire = Instantiate(Fire_prefab);
        return;
    }

    private void ObjectItem()
    {
        GameObject Item_prefab = Resources.Load<GameObject>("Item");
        GameObject Item = Instantiate(Item_prefab);
        return;
    }

    Color GetAlphaColor(Color color)
    {
        textTime += Time.unscaledDeltaTime * 5.0f * speed;
        color.a = Mathf.Sin(textTime);
        return color;
    }
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoroller : MonoBehaviour
{
    float Timer = PlaneScript.Timer;
    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 5)
        {
            num = Random.Range(1, 6);// ※ 1～5の範囲でランダムな整数値が返る
            switch (num)
            {
                case 1:
                    EnemyDraw1();
                    break;
                case 2:
                    EnemyDraw2();
                    break;
                case 3:
                    EnemyDraw3();
                    break;
                case 4:
                    EnemyDraw4();
                    break;
                case 5:
                    EnemyDraw5();
                    break;
            }
            Timer = 0.0f;
        }
    }

    void EnemyDraw1()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("1");
        return;
    }

    void EnemyDraw2()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("2");
        return;
    }

    void EnemyDraw3()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("3");
        return;
    }

    void EnemyDraw4()
    {
        ObjectEnemy();
        ObjectItem();
        Debug.Log("4");
        return;
    }

    void EnemyDraw5()
    {
        ObjectEnemy();
        ObjectFire();
        Debug.Log("5");
        return;
    }

    private void ObjectEnemy()
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("Enemy");
        GameObject Enemy = Instantiate(Enemy_prefab);
        return;
    }

    private void ObjectFire()
    {
        GameObject Fire_prefab = Resources.Load<GameObject>("Fire");
        GameObject Fire = Instantiate(Fire_prefab);
        return;
    }

    private void ObjectItem()
    {
        GameObject Item_prefab = Resources.Load<GameObject>("Item");
        GameObject Item = Instantiate(Item_prefab);
        return;
    }
}
*/