using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    public static bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            //SpawnText();
            stop = false;
            StartCoroutine(SpawnText());
        }
    }

    IEnumerator SpawnText()
    {
        for (int i = 0; i < 21; ++i)
        {
            yield return null;
            FeverStart();
        }
        yield return new WaitForSeconds(1.5f);
        if (Player.excellent == true)
        {
            StartCoroutine(SpawnText());
        }
    }

    public void FeverStart()
    {
        GameObject ui = (GameObject)Resources.Load("FeverText");
        GameObject ui_clone = Instantiate(ui);
        //ui_clone.gameObject.transform.parent = GameObject.Find("Fever").transform;
        ui_clone.transform.SetParent(GameObject.Find("Fever").transform, false);
    }
}
