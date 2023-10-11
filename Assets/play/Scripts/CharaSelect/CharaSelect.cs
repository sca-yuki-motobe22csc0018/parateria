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

    public RectTransform[] _window;
    public RectTransform[] _button;

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
        WindowAnim.move=false;
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
            _window[change - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 960);
            _window[change - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 540);
            _button[change - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 960);
            _button[change - 1].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 540);
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
