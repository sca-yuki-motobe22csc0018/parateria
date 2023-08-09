using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{
    public InputField inputField;
    public List<string> _name = new List<string>();
    public GameObject cf;
    public Text NameText;
    int count = -1;

    // Start is called before the first frame update
    void Start()
    {
        cf.gameObject.SetActive(false);
        NameText.text = "";
        count++;
}

    public void SetName()
    {
        cf.gameObject.SetActive(true);
        NameText.text = inputField.text;
    }
    public void CF(int num)
    {
        if (num == 1)
        {
            _name.Add(inputField.text);
            SceneManager.LoadScene("CharaSelect");
            Debug.Log(_name[count]);
        }
        else if (num == 2)
        {
            cf.gameObject.SetActive(false);
        }
    }
}
