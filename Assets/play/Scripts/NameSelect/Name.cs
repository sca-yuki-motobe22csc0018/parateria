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

    // Start is called before the first frame update
    void Start()
    {
        cf.gameObject.SetActive(false);
        NameText.text = "";
        count++;
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
            Debug.Log(nameKind[count]);
        }
        else if (num == 2)
        {
            cf.gameObject.SetActive(false);
        }
    }
}
