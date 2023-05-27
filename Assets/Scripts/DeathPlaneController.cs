using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public GameObject DeathPlane;
    GameObject[] step = new GameObject[1];
    [SerializeField] float speed = 5.0f;
    [SerializeField] float disappear = -10;
    [SerializeField] float respawn = 30;
    [SerializeField] int High = -5;
    float Timer = 0.0f;

    void Start()
    {
        for (int i = 0; i < step.Length; i++)
        {
            step[i] = Instantiate(DeathPlane, new Vector3(4 * i, High, 0), Quaternion.identity);
        }
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

        Timer += Time.time;

        if (Timer % 60 == 0)
        {
            if (speed >= 13)
            {
                return;
            }
            speed += 0.2f;
        }


    }
    void ChangeScale(int i)
    {
        int x = (i) % 1; //(i+9)Ç10Ç≈äÑÇ¡ÇΩó]ÇËÇxÇ∆Ç∑ÇÈÅB
        if (step[x].transform.localScale.y <= 3)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(0, 2), 0);
        }
        else
        if (step[x].transform.localScale.y >= 6)
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-2, -0), 0);
        }
        else
        {
            step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-2, 2), 0);
        }
    }

}
