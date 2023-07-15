using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSelect : MonoBehaviour
{
    private Button button;
    private Pause pause;
    public int Select;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectNum);
        pause = GameObject.Find("Pause").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectNum()
    {
        pause.StartGame(Select);
    }
}
