using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public static float speed = PlaneA.speed;

    [SerializeField] float posx;
    float Timer = PlaneA.Timer;


    // Start is called before the first frame update
    void Start()
    {

        Timer = 0.0f;
        speed = PlaneA.speed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlaneA.speed;

        posx = transform.position.x;
        transform.position = new Vector3(posx - speed * Time.deltaTime, transform.position.y);

        if (posx <= -10)
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
