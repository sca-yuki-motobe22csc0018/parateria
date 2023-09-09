using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class asobikata : MonoBehaviour
{
    [SerializeField] Image[] window = new Image[5];
    [SerializeField] GameObject[] button = new GameObject[2];
    int change;
    private TitleController tc;

    // Start is called before the first frame update
    void Start()
    {
        change = 0;
        button[0].SetActive(false);
        window[change].enabled = true;
        for(int i = 1;i < 5; ++i)
        {
            window[i].enabled = false;
        }
        tc = GameObject.Find("TitleController").GetComponent<TitleController>();
    }

    public void Window(int num)
    {
        tc.SE();
        if (num == 1)
        {
            if (change != 4)
            {
                button[0].SetActive(true);
                window[change].enabled = false;
                ++change;
                window[change].enabled = true;
            }
            if(change == 4)
            {
                button[1].SetActive(false);
            }
        }
        else if (num == 2)
        {
            if(change != 0)
            {
                button[1].SetActive(true);
                window[change].enabled = false;
                --change;
                window[change].enabled = true;
            }
            if (change == 0)
            {
                button[0].SetActive(false);
            }
        }
        else if (num == 3)
        {
            gameObject.SetActive(false);
        }
    }
}
