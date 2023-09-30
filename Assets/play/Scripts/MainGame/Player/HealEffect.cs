using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    int timer=0;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.heal == true)
        {
            //this.gameObject.SetActive(true);
            timer+=1;
            if (timer>60)
            {
                timer = 0;
                Player.heal=false;
                Debug.Log("Player"+Player.heal);
                this.gameObject.SetActive(false);
            }
        }
        if (Player.healcount == true)
        {
            timer = 0;
            Player.healcount=false;
        }
    }
}
