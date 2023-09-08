using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterIsTrigger : MonoBehaviour
{
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider=GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharaSelect.change == 3)
        {
            this.collider.isTrigger = true;
        }
        else
        {
            this.collider.isTrigger = false;
        }
    }
}
