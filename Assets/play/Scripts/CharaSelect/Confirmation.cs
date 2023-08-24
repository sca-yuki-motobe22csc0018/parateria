using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    private Button button;
    private CharaSelect charaSelect;
    public int Select;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(YesNo);
        charaSelect = GameObject.Find("CharaSelect").GetComponent<CharaSelect>();
    }

    void YesNo()
    {
        charaSelect.StartGame(Select);
    }
}
