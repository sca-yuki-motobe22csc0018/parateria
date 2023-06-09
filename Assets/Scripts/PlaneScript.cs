using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneScript : MonoBehaviour
{
    public GameObject Plane;
    public GameObject PlaneImage;
    public GameObject player;
    GameObject[] step = new GameObject[7];
    public static float speed = 5.0f;
    [SerializeField] float disappear = -10;
    [SerializeField] float respawn = 15;
    [SerializeField] float High = -5;
    public static float Timer = 0.0f;
    bool end = false;
    private int stopcount=0;

    void Start()
    {
        for (int i = 0; i < step.Length; i++)
        {
            step[i] = Instantiate(Plane, new Vector3(4 * i, High, 0), Quaternion.identity);
        }
        end = false;
        speed = 5.0f;
        Timer = 0.0f;
        stopcount=0;
    }

    void Update()
    {
        


        for (int i = 0; i < step.Length; i++)
        {
            step[i].gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (step[i].gameObject.transform.position.x < disappear)
            {
                ChangeScale(i);
                step[i].gameObject.transform.position = new Vector3(respawn, High, 0);
            }
        }

        Timer += Time.deltaTime;

        if (Timer > 1)
        {
            if (speed >= 12)
            {
                return;
                Timer = 0;
            }
            speed += 0.25f;
            Timer = 0;
        }
    }
    /*
    void ChangeScale(int i)
    {
        
        int x = (i + 9) % 10; //(i+9)を10で割った余りをxとする。
        if (step[x].transform.localScale.y <= 0.5)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(0,4), 0);
        }
        else
        if (step[x].transform.localScale.y >= 12)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-5, -1), 0);
        }
        else
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-5, 4), 0);
        }
    }
    */


    void ChangeScale(int i)
    {

        int x = (i + 6) % 7; //(i+9)を10で割った余りをxとする。
        if (step[x].transform.localScale.y <= 0.5)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(0, 2), 0);
        }
        else
        if (step[x].transform.localScale.y >= 4)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-2, 0), 0);
        }
        else
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-1, 1), 0);
        }
    }
}
