using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSelect : MonoBehaviour
{
    private Button button;
    public int set;
    asobikata asobi;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeWindow);
        asobi = GameObject.Find("asobikata").GetComponent<asobikata>();
    }

    void ChangeWindow()
    {
        asobi.Window(set);
    }
}
