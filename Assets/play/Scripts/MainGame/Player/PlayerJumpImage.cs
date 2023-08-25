using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpImage : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (PlayerDown.jumpSet == true)
        {
            Debug.Log("jumpset");
            jump.SetActive(true);
            run.SetActive(false);
        }
        if (PlayerDown.jumpSet == false)
        {
            Debug.Log("not jumpset");
            jump.SetActive(false);
            run.SetActive(true);
        }
        */
        transform.position = player.transform.position + new Vector3(0, -0.6f, 0);
    }
}
