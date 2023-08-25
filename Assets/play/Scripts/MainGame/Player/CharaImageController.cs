using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaImageController : MonoBehaviour
{
    public GameObject run;
    public GameObject jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDown.jumpSet == true)
        {
            run.SetActive(false);
            jump.SetActive(true);
        }
        if (PlayerDown.jumpSet == false)
        {
            run.SetActive(true);
            jump.SetActive(false);
        }
    }
}
