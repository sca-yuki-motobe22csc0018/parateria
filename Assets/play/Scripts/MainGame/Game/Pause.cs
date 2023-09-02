using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameContoroller.start == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 0;
                PauseScreen.gameObject.SetActive(true);
            }
        }
    }

    public void StartGame(int num)
    {
        if (num == 1)
        {
            SceneManager.LoadScene("Title");
        }
        else if (num == 2)
        {
            PauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
