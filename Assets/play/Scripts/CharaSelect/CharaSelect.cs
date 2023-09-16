using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public static int change;
    public GameObject cf1;
    public GameObject cf2;
    public GameObject cf3;

    // Start is called before the first frame update
    void Start()
    {
        cf1.gameObject.SetActive(false);
        cf2.gameObject.SetActive(false);
        cf3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGame(int num)
    {
        change = num;
        if(change == 1)
        {
            cf1.gameObject.SetActive(true);
        }
        else if (change == 2)
        {
            cf2.gameObject.SetActive(true);
        }
        else if (change == 3)
        {
            cf3.gameObject.SetActive(true);
        }
    }

    public void StartGame(int num)
    {
        if(num == 1)
        {
            SceneManager.LoadScene("MainGame");
        }
        else if(num == 2)
        {
            if (change == 1)
            {
                cf1.gameObject.SetActive(false);
            }
            else if (change == 2)
            {
                cf2.gameObject.SetActive(false);
            }
            else if (change == 3)
            {
                cf3.gameObject.SetActive(false);
            }
        }
        if (num == 3)
        {
            SceneManager.LoadScene("Title");
        }
    }
}
