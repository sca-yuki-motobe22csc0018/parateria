using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleBotton : MonoBehaviour
{
    private Button button;
    private TitleController tc;
    public int set;

    // Start is called before the first frame update
    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(Set);
        tc=GameObject.Find("TitleController").GetComponent<TitleController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Set()
    {
        Debug.Log(set);
        tc.StartGame(set);
    }
}
