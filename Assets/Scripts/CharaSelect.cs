using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharaSelect : MonoBehaviour
{
    public static int change;
    public GameObject cf;

    // Start is called before the first frame update
    void Start()
    {
        cf.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGame(int num)
    {
        change = num;
        cf.gameObject.SetActive(true);
    }
    public void StartGame(int num)
    {
        if(num == 1)
        {
            SceneManager.LoadScene("MainGame");
        }
        else if(num == 2)
        {
            cf.gameObject.SetActive(false);
        }
    }
}
