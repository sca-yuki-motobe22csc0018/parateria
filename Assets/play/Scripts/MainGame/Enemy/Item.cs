using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    float speed = GameContoroller.speed;

    float posx;



    // Start is called before the first frame update
    void Start()
    {
        speed = GameContoroller.speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameContoroller.speed;

        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime, transform.position.y);

        if (posx <= -35)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && Time.timeScale == 1)
        {
            StartCoroutine(num());
        }
    }
    IEnumerator num()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(this.gameObject);
    }
}
