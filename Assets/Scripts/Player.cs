using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    [SerializeField] private float jumpForce = 350f;

    private int jumpCount = 0;

    public Text ScoreText;
    public Text ResultScore;
    int score = 0;
    int i = 0;
    float timecount;
    bool EnCount;
    bool FiCount;
    bool Reset;

    public GameObject[] lifeArray = new GameObject[6];
    private int lifePoint;

    [SerializeField] GameObject m_enemy = null;
    [SerializeField] GameObject m_fire = null;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        ScoreText.text = "";
        ResultScore.text = "";
        EnCount = true;
        FiCount = true;
        Reset = false;
        timecount = 0.0f;
        lifePoint = 5;
        lifeArray[lifePoint].SetActive(false);
    }

    void Update()
    {
        Transform myTransform = this.transform;

        //
        Vector3 pos = myTransform.position;
        if (pos.x < -6 && Time.timeScale == 1)
        {
            pos.x += 0.002f;
            myTransform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && jumpCount < 2)
        {
            if (jumpCount == 1)
            {
                this.rbody2D.AddForce(transform.up * 0);
            }
            this.rbody2D.AddForce(transform.up * jumpForce*1.5f);
            jumpCount++;
        }

        if (transform.position.y < -10 || lifePoint == 0)
        {
            PlaneScript.speed = 5.0f;
            Time.timeScale = 0;
            timecount += Time.unscaledDeltaTime;
            ScoreText.text = "";
            ResultScore.text = "SCORE: " + Mathf.Clamp(score, 0, 99999999).ToString();
            GameOver(timecount);
            if (Reset)
            {
                if(Input.GetKey(KeyCode.Space))
                SceneManager.LoadScene("Title");
            }
        }

        if (Time.timeScale == 1)
        {
            i++;
            ScoreText.text = Mathf.Clamp(score, 0, 99999999).ToString();
        }

        if (Time.timeSinceLevelLoad >= 50 && Time.timeScale == 1)
        {
            score += 51;
        }
        else if (Time.timeSinceLevelLoad >= 25 && i == 3 && Time.timeScale == 1)
        {
            score += 11;
            i = 0;
        }
        else if (Time.timeScale == 1 && i == 100)
        {
            score++;
            i = 0;
        }

        if (m_enemy == null)
        {
            var enemy = GameObject.FindObjectOfType<Enemy>();
            if (enemy != null)
            {
                m_enemy = enemy.gameObject;
            }
        }

        if (m_fire == null)
        {
            var fire = GameObject.FindObjectOfType<Fire>();
            if (fire != null)
            {
                m_fire = fire.gameObject;
            }
        }

        if (m_enemy != null && EnCount)
        {
            Matrix_Enemy();
        }
        if (m_fire != null && FiCount)
        {
            Matrix_Fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
            EnCount = true;
            FiCount = true;
        }

        if (other.gameObject.CompareTag("Enemy") && Time.timeScale == 1)
        {
            ScoreDown();
            Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item") && Time.timeScale == 1)
        {
            if (lifePoint < 6)
            {
                Heal();
            }
            score += 150000;
        }
        if (other.gameObject.CompareTag("Fire") && Time.timeScale == 1)
        {
            Damage();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire") && Time.timeScale == 1)
        {
            ScoreDown();
        }
    }

    private void ScoreDown()
    {
        if (Time.timeSinceLevelLoad >= 50)
        {
            score -= 150000;
        }
        if (Time.timeSinceLevelLoad >= 25)
        {
            score -= 100000;
        }
        score -= 100;

        if (score < 0)
        {
            score = 0;
        }
    }

    private void Damage()
    {
        lifeArray[lifePoint - 1].SetActive(false);
        lifePoint--;
    }

    private void Heal()
    {
        lifePoint++;
        lifeArray[lifePoint - 1].SetActive(true);
    }

    private void Matrix_Enemy()
    {
        if (jumpCount > 0)
        {
            Vector3 en = m_enemy.transform.position;
            if ((en.x - 0.5) - (transform.position.x + 0.25) < 0.35f &&
                (en.x - 0.5) - (transform.position.x + 0.25) > 0)
            {
                if ((transform.position.y + 0.25) - (en.y + 0.5) < 1.25f &&
                    (transform.position.y + 0.25) - (en.y + 0.5) > 0)
                {
                    if (Time.timeSinceLevelLoad >= 50)
                    {
                        score += 500000;
                    }
                    if (Time.timeSinceLevelLoad >= 25)
                    {
                        score += 100000;
                    }
                    score += 1000;
                    EnCount = false;
                }
            }
        }
    }
    private void Matrix_Fire()
    {
        if (jumpCount > 0)
        {
            Vector3 fi = m_fire.transform.position;
            if ((fi.x - 1) - (transform.position.x + 0.25) < 0.35f &&
                (fi.x - 1) - (transform.position.x + 0.25) > 0)
            {
                if ((fi.y - 0.25) - (transform.position.y + 0.25) < 1.25f &&
                    (fi.y - 0.25) - (transform.position.y + 0.25) > 0)
                {//transform.position.y - fi.y < 0.01f || 
                    if (Time.timeSinceLevelLoad >= 50)
                    {
                        score += 500000;
                    }
                    if (Time.timeSinceLevelLoad >= 25)
                    {
                        score += 100000;
                    }
                    score += 1000;
                    FiCount = false;
                }
            }
        }
    }

    void GameOver(float num)
    {
        while (num > 4.0f)
        {
            if (timecount >= 3.0f)
            {
                Reset = true;
            }
            break;
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;

    [SerializeField] private float jumpForce = 350f;

    private int jumpCount = 0;
    bool end=false;

    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        jumpCount = 2;
    }

    void Update()
    {
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        if (pos.x < -3)
        {
            pos.x += 0.002f;
            myTransform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 2)
        {
            this.rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
        }
    }
}
*/
