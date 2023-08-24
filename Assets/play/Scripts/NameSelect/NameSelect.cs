using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSelect : MonoBehaviour
{
    private Button button;
    private Name _name;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Decision);
        _name = GameObject.Find("Name").GetComponent<Name>();
    }

    void Decision()
    {
        _name.SetName();
    }
}
