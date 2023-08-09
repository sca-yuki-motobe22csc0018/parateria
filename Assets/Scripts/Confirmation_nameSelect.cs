using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirmation_nameSelect : MonoBehaviour
{
    private Button button;
    private Name _name;
    public int Select;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(YesNo);
        _name = GameObject.Find("Name").GetComponent<Name>();
    }

    void YesNo()
    {
        _name.CF(Select);
    }
}