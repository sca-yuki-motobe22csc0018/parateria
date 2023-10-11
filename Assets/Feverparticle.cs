using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feverparticle : MonoBehaviour
{
    public GameObject[] ParticleEffect; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.excellent == true)
        {
            ParticleEffect[0].gameObject.SetActive(true);
            ParticleEffect[1].gameObject.SetActive(true);
            ParticleEffect[2].gameObject.SetActive(true);
        }
        else
        {
            ParticleEffect[0].gameObject.SetActive(false);
            ParticleEffect[1].gameObject.SetActive(false);
            ParticleEffect[2].gameObject.SetActive(false);
        }
    }
}
