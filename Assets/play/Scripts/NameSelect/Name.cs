using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{
    public InputField inputField;
    public static List<string> nameKind = new List<string>();
    public GameObject cf;
    public Text NameText;
    public static int count = -1;
    public static bool _rank = false;

    // Start is called before the first frame update
    void Start()
    {
        cf.gameObject.SetActive(false);
        NameText.text = "";
        count++;
        inputField.text="";
    }

    public void SetName()
    {
        if (inputField.text!="")
        {
            cf.gameObject.SetActive(true);
            NameText.text = inputField.text;
        }
    }
    public void CF(int num)
    {
        if (num == 1)
        {
            nameKind.Add(inputField.text);
            SceneManager.LoadScene("Ranking");
            _rank = true;
        }
        else if (num == 2)
        {
            cf.gameObject.SetActive(false);
        }
    }
}
