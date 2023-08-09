using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaNumber : MonoBehaviour
{

    private Button button;
    private CharaSelect charaSelect;
    public int Select;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectNum);
        charaSelect = GameObject.Find("CharaSelect").GetComponent<CharaSelect>();
    }

    void SelectNum()
    {
        charaSelect.SetGame(Select);
    }
}
