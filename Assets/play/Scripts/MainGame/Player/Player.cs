using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] public float jumpForce = 12f;

    [SerializeField] public static int jumpCount = 0;

    public Text ScoreText;
    public Text ResultScore;
    public float count = 0.0f;
    public GameObject result;
    public Text Distance;
    public static int score = 0;
    float timecount;
    bool EnCount;
    bool FiCount;
    bool EnemyHit;

    public GameObject[] lifeArray = new GameObject[6];
    public GameObject[] selectCharacter = new GameObject[3];
    private int lifePoint;

    [SerializeField] GameObject m_enemy = null;
    [SerializeField] GameObject m_fire = null;
    [SerializeField] GameObject m_item = null;

    [SerializeField] float StopTime;//死んでからステージ等が止まる時間
    [SerializeField] float WaitTime;//リザルト表示から待つ時間
    [SerializeField] int ChangeFrame;//表示後にフェードアウトするフレーム数
    [SerializeField] float ChangeColor;//ステージが止まるまでに変わるフェードの数値
    [SerializeField] float PanelColor;//パネルの透明度調整

    public Image PanelResult;
    float Panel;
    public Image FadeResult;
    float Fade;
    bool stop;

    int frameCount = 0;
    [SerializeField] int[] scoreFrame = new int[5];
    [SerializeField] int[] scoreUp = new int[5];
    [SerializeField] int[] itemScore = new int[4];
    [SerializeField] int[] scoreDown = new int[5];

    float walkDis;

    public AudioClip drumRoll1;
    public AudioClip drumRoll2;
    public AudioClip drumRollEnd;

    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScoreText.text = "";
        ResultScore.text = "";
        Distance.text = "";
        score = 0;
        EnCount = true;
        FiCount = true;
        EnemyHit = false;
        timecount = 0.0f;
        lifePoint = 5;
        lifeArray[lifePoint].SetActive(false);
        PanelResult.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        FadeResult.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        FadeResult.enabled = false;
        Panel = 0.0f;
        Fade = 0.0f;
        stop = false;
        result.gameObject.SetActive(false);
        walkDis = 0.0f;
        audioSource = GetComponent<AudioSource>();
        selectCharacter[0].SetActive(false);
        selectCharacter[1].SetActive(false);
        selectCharacter[2].SetActive(false);
        if (CharaSelect.change == 1)
        {
            selectCharacter[0].SetActive(true);
        }else
        if(CharaSelect.change == 2)
        {
            selectCharacter[1].SetActive(true);
        }else
        if (CharaSelect.change == 3)
        {
            selectCharacter[2].SetActive(true);
        }
    }

    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        if (pos.x < -3 && Time.timeScale == 1)
        {
            pos.x += 0.002f;
            if (pos.x>-3)
            {
                pos.x = -3;
            }
            myTransform.position = pos;
        }
        else
        {
            pos.x=-3;
            myTransform.position = pos;
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && jumpCount < 3)
        {
            rb=transform.GetComponent<Rigidbody2D>();
            rb.velocity=new Vector3(0,jumpForce,0);
            jumpCount++;
            PlayerDown.jumpSet=true;
        }

        if (!stop)
        {
            if (transform.position.y < -10 || lifePoint == 0)
            {
                PlaneA.speed = 8.0f;
                ScoreText.text = "";
                timecount += Time.unscaledDeltaTime;
                if (timecount > StopTime)
                {
                    timecount = StopTime;
                }
                Panel = (timecount % StopTime) / StopTime * PanelColor;
                PanelResult.GetComponent<Image>().color = new Color(0, 0, 0, Panel);
                if (Time.timeScale == 0)
                {
                    if (timecount >= StopTime)
                    {
                        stop = true;
                        Panel = PanelColor;
                        result.gameObject.SetActive(true);
                        StartCoroutine(ResultTime());
                    }
                }
                else if (Time.timeScale > Time.unscaledDeltaTime / StopTime)
                {
                    Time.timeScale -= Time.unscaledDeltaTime / StopTime;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }

        if (Time.timeScale == 1)
        {
            count += Time.deltaTime;
            walkDis += Time.deltaTime * PlaneA.speed;
            if (count > 1.0f / 60)
            {
                frameCount++;
                count = 0.0f;
            }
            ScoreText.text = Mathf.Clamp(score, 0, 99999999).ToString();

            if (Time.timeSinceLevelLoad >= 180 && frameCount == scoreFrame[4])
            {
                score += scoreUp[4];
                frameCount = 0;
            }
            else if (Time.timeSinceLevelLoad >= 120 && frameCount == scoreFrame[3])
            {
                score += scoreUp[3];
                frameCount = 0;
            }
            else if (Time.timeSinceLevelLoad >= 50 && frameCount == scoreFrame[2])
            {
                score += scoreUp[2];
                frameCount = 0;
            }
            else if (Time.timeSinceLevelLoad >= 25 && frameCount == scoreFrame[1])
            {
                score += scoreUp[1];
                frameCount = 0;
            }
            else if (frameCount == scoreFrame[0])
            {
                score += scoreUp[0];
                frameCount = 0;
            }
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

        if (m_item == null)
        {
            var item = GameObject.FindObjectOfType<Item>();
            if (item != null)
            {
                m_item = item.gameObject;
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
            EnCount = true;
            FiCount = true;
            EnemyHit = false;
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
            if (Time.timeSinceLevelLoad >= 180)
            {
                score += itemScore[3];
            }
            else if (Time.timeSinceLevelLoad >= 120)
            {
                score += itemScore[2];
            }
            else if (Time.timeSinceLevelLoad >= 60)
            {
                score += itemScore[1];
            }
            else
            {
                score += itemScore[0];
            }
            
        }

        if (other.gameObject.CompareTag("Fire") && Time.timeScale == 1)
        {
            Damage();
        }

        if (other.gameObject.CompareTag("Enemy") && Time.timeScale == 1 && !EnemyHit)
        {
            Damage();
            EnemyHit = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire") && Time.timeScale == 1)
        {
            ScoreDown();
        }

        if (other.gameObject.CompareTag("Enemy") && Time.timeScale == 1)
        {
            ScoreDown();
        }
    }

    private void ScoreDown()
    {
        if (Time.timeSinceLevelLoad >= 180)
        {
            score -= scoreDown[4];
        }
        else if (Time.timeSinceLevelLoad >= 120)
        {
            score -= scoreDown[3];
        }
        else if (Time.timeSinceLevelLoad >= 50)
        {
            score -= scoreDown[2];
        }
        else if (Time.timeSinceLevelLoad >= 25)
        {
            score -= scoreDown[1];
        }
        else
        {
            score -= scoreDown[0];
        }

        if (score < 0)
        {
            score = 1;
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
        jumpCount--;
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
                    if (score >= 10000000)
                    {
                        score += 10000000;
                    }
                    else if (score >= 1000000)
                    {
                        score += 1000000;
                    }
                    else if (score >= 100000)
                    {
                        score += 100000;
                    }
                    else if (score >= 10000)
                    {
                        score += 10000;
                    }
                    else if (score >= 1000)
                    {
                        score += 1000;
                    }
                    else
                    {
                        score += 100;
                    }
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
                {
                    if (score >= 10000000)
                    {
                        score += 5000000;
                    }
                    else if (score >= 1000000)
                    {
                        score += 500000;
                    }
                    else if (score >= 100000)
                    {
                        score += 100000;
                    }
                    else if (score >= 10000)
                    {
                        score += 10000;
                    }
                    else if (score >= 1000)
                    {
                        score += 1000;
                    }
                    else
                    {
                        score += 100;
                    }
                    FiCount = false;
                }
            }
        }
    }

    IEnumerator ResultTime()
    {
        bool SL = false;
        int rollScore = 0;
        float walkdis = 0.0f;
        float c = 0.0f;
        ResultScore.text = Mathf.Clamp(rollScore, 0, 99999999).ToString();
        Distance.text = Mathf.Clamp(walkdis, 0, 9999).ToString("f2") + "m";

        int num = 0;
        if (score >= 10000000)
        {
            num = 511111;
        }
        else if (score >= 1000000)
        {
            num = 51111;
        }
        else if (score >= 100000)
        {
            num = 5111;
        }
        else if (score >= 10000)
        {
            num = 511;
        }
        else if (score >= 1000)
        {
            num = 31;
        }
        else if (score >= 100)
        {
            num = 11;
        }
        else if (score >= 1)
        {
            num = 1;
        }

        if (!SL)
        {
            audioSource.PlayOneShot(drumRoll1);
            audioSource.loop = !audioSource.loop;
            SL = true;
        }

        while (rollScore < score)
        {
            if (SL)
            {
                audioSource.PlayOneShot(drumRoll2);
                SL = false;
            }
            yield return null;
            c += Time.unscaledDeltaTime;
            Debug.Log(c);
            if (c > 1.0f / 60)
            {
                Debug.Log(c);
                rollScore += num;
                if (rollScore > score)
                {
                    rollScore = score;
                }
                ResultScore.text = Mathf.Clamp(rollScore, 0, 99999999).ToString();
                c = 0.0f;
            }
        }
        c = 0.0f;
        audioSource.loop = !audioSource.loop;
        audioSource.PlayOneShot(drumRollEnd);
        yield return new WaitForSecondsRealtime(1.0f);

        if (walkDis >= 100000)
        {
            num = 11111;
        }
        else if (walkDis >= 10000)
        {
            num = 1111;
        }
        else if (walkDis >= 10000)
        {
            num = 111;
        }
        else if (walkDis >= 1000)
        {
            num = 11;
        }

        if (!SL)
        {
            audioSource.PlayOneShot(drumRoll1);
            audioSource.loop = !audioSource.loop;
            SL = true;
        }

        while (walkdis < walkDis)
        {
            if (SL)
            {
                audioSource.PlayOneShot(drumRoll2);
                SL = false;
            }
            yield return null;
            c += Time.unscaledDeltaTime;
            if (c > 1.0f / 60)
            {
                walkdis += num;
                if (walkdis > walkDis)
                {
                    walkdis = walkDis;
                }
                Distance.text = Mathf.Clamp(walkdis , 0, 9999).ToString("f2") + "m";
                c = 0.0f;
            }
        }
        audioSource.loop = !audioSource.loop;
        audioSource.PlayOneShot(drumRollEnd);
        yield return new WaitForSecondsRealtime(WaitTime);
        FadeResult.enabled = true;

        for (int i = 0; i < ChangeFrame; ++i)
        {
            yield return null;
            Fade += 1.0f / ChangeFrame;
            if (Fade > 1.0f)
            {
                Fade = 1.0f;
            }
            FadeResult.GetComponent<Image>().color = new Color(0, 0, 0, Fade);
        }
        ChangeScene();
    }

    public void ChangeScene()
    {
        if (score > Ranking.scoreRank[9])
        {
            RunkUp();
        }
        else
        {
            GameOver();
        }
    }
    
    void GameOver()
    {
        SceneManager.LoadScene("Ranking");
    }
    void RunkUp()
    {
        SceneManager.LoadScene("NameSelect");
    }
}
