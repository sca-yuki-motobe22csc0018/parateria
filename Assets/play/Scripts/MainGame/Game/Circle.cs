using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Transform _tR;
    private Player _player;
    public static bool Excellent_Pikuru = false;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _tR.position;
        this.transform.localScale = Vector3.one * Player.xc / 1.25f * 2;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("mushroom"))
        {
            Excellent_Pikuru = true;
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("Enemy")
    //        || other.gameObject.CompareTag("mushroom"))
    //    {
    //        Debug.Log("stay");
    //        Excellent_Pikuru = true;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire") || other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("mushroom"))
        {
            Excellent_Pikuru = false;
        }
    }
}
