using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Spine.Unity;
using Spine;


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
    public static int lifePoint;

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
    public GameObject[] justJump = new GameObject[4];
    float Fade;
    bool stop;
    bool res = false;
    public static bool OnGround;

    int frameCount = 0;
    [SerializeField] int[] scoreFrame = new int[5];
    [SerializeField] int[] scoreUp = new int[5];
    [SerializeField] int[] itemScore = new int[4];
    [SerializeField] int[] scoreDown = new int[5];
    [SerializeField] Text jumpScore;
    [SerializeField] GameObject Ribbon;

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
        jumpScore.text = "";
        Ribbon.SetActive(false);
        score = 0;
        res = false;
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

        for (int i = 0; i < 3; ++i)
        {
            selectCharacter[i].SetActive(false);
        }

        for (int i = 0; i < 4; ++i)
        {
            justJump[i].SetActive(false);
        }

        if (CharaSelect.change == 1)
        {
            selectCharacter[0].SetActive(true);
        }
        else
        if (CharaSelect.change == 2)
        {
            selectCharacter[1].SetActive(true);
        }
        else
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
            if (pos.x > -3)
            {
                pos.x = -3;
            }
            myTransform.position = pos;
        }
        else
        if (pos.x > -3)
        {
            pos.x = -3;
            myTransform.position = pos;
        }


        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1 && jumpCount < 3)
        {
            rb = transform.GetComponent<Rigidbody2D>();
            OnGround=false;
            rb.velocity = new Vector3(0, jumpForce, 0);
            
            PlayerDown.jumpSet = true;
            if (m_enemy != null && EnCount)
            {
                Matrix_Enemy();
            }
            if (m_fire != null && FiCount)
            {
                Matrix_Fire();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;
        }

        if (!stop)
        {
            if (transform.position.y < -10 || lifePoint == 0 || transform.position.x < -12)
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
            ScoreText.text = Mathf.Clamp(score, 0, 99999999).ToString().PadLeft(8,'0');

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

        if (res == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeScene();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnGround=true;
        if (other.gameObject.CompareTag("ground"))
        {
            EnCount = true;
            FiCount = true;
            EnemyHit = false;
            Ribbon.SetActive(false);
            for (int i = 0; i < 4; ++i)
            {
                justJump[i].SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item") && Time.timeScale == 1)
        {
            if (lifePoint < 6)
            {
                if (CharaSelect.change == 2)
                {
                    Heal();
                    HealScore();
                    HealScore();
                    if (lifePoint < 6)
                    {
                        Heal();
                    }
                }
                else
                {
                    Heal();
                    HealScore();
                }
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
        if (other.gameObject.CompareTag("mushroom") && Time.timeScale == 1 && !EnemyHit)
        {
            if (CharaSelect.change == 3)
            {
                return;
            }
            else
            {
                Damage();
                EnemyHit = true;
            }
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
        if (other.gameObject.CompareTag("mushroom") && Time.timeScale == 1)
        {
            if (CharaSelect.change == 3)
            {
                return;
            }
            else
            {
                ScoreDown();
            }
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
        if (!lifeArray[3].activeSelf)
        {
            StartCoroutine(ColorBlinking());
        }
    }

    IEnumerator ColorBlinking()
    {
        bool stop = false;
        Color begin = new Color32(225, 0, 0, 113);
        Color end = new Color32(225, 0, 0, 0);
        PanelResult.GetComponent<Image>().color = begin;
        float nowTime = 0.0f;
        float colorTime = 0.0f;
        float Change = 1.0f;
        yield return null;
        while (!stop)
        {
            yield return null;
            nowTime += Time.deltaTime;
            colorTime = (nowTime % Change) / Change;
            if (nowTime > Change)
            {
                colorTime = 1.0f;
            }
            if (colorTime == 1.0f)
            {
                stop = true;
                PanelResult.GetComponent<Image>().color = new Color(1.0f, 0, 0, 0);
            }
            else
            {
                PanelResult.GetComponent<Image>().color = Color.Lerp(begin, end, Mathf.PingPong(colorTime, 1));
            }
        }
    }

    private void Heal()
    {
        lifePoint++;
        jumpCount--;
        lifeArray[lifePoint - 1].SetActive(true);
    }

    private void HealScore()
    {
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

    private void Matrix_Enemy()
    {
        Vector3 en = m_enemy.transform.position;
        if ((en.x - 1.5f) - (transform.position.x + 0.5f) <= 2.0f &&
            (en.x - 1.5f) - (transform.position.x + 0.5f) >= 0.0f)
        {
            if (transform.position.y - en.y <= 0.75f ||
                (transform.position.y - en.y >= -0.75f))
            {
                Debug.Log("Hit");
                if ((en.x - 1.5f) - (transform.position.x + 0.5f) <= 1.0f &&
            (en.x - 1.5f) - (transform.position.x + 0.5f) >= 0.0f)
                {
                    justJump[0].SetActive(true);
                    if (CharaSelect.change == 1)
                    {
                        Matrix_Score(2.0f);
                    }
                    else
                    {
                        Matrix_Score(1.0f);
                    }
                }
                else
                {
                    justJump[CharaSelect.change].SetActive(true);
                    if (CharaSelect.change == 1)
                    {
                        Matrix_Score(1.5f);
                    }
                    else
                    {
                        Matrix_Score(0.5f);
                    }
                }
                EnCount = false;
            }
        }
    }
    private void Matrix_Fire()
    {
        if (jumpCount > 0)
        {
            Vector3 fi = m_fire.transform.position;
            if ((fi.x - 1.5f) - (transform.position.x + 0.5f) <= 2.0f &&
            (fi.x - 1.5f) - (transform.position.x + 0.5f) >= 0)
            {
                if (transform.position.y - fi.y <= 0.75f ||
                (transform.position.y - fi.y >= -0.75f))
                {
                    Debug.Log("Hit");
                    if ((fi.x - 1.5f) - (transform.position.x + 0.5f) <= 1.0f &&
                     (fi.x - 1.5f) - (transform.position.x + 0.5f) >= 0.0f)
                    {
                        justJump[0].SetActive(true);
                        if (CharaSelect.change == 1)
                        {
                            Matrix_Score(2.0f);
                        }
                        else
                        {
                            Matrix_Score(1.0f);
                        }
                    }
                    else
                    {
                        if (CharaSelect.change == 1)
                        {
                            Matrix_Score(1.5f);
                        }
                        else
                        {
                            Matrix_Score(0.5f);
                        }
                    }
                    FiCount = false;
                }
            }
        }
    }

    void Matrix_Score(float dif)
    {
        int numScore;
        if (score >= 10000000)
        {
            numScore = (int)(5000000 * dif);
        }
        else if (score >= 1000000)
        {
            numScore = (int)(500000 * dif);
        }
        else if (score >= 100000)
        {
            numScore = (int)(100000 * dif);
        }
        else if (score >= 10000)
        {
            numScore = (int)(10000 * dif);
        }
        else if (score >= 1000)
        {
            numScore = (int)(1000 * dif);
        }
        else
        {
            numScore = (int)(100 * dif);
        }
        Ribbon.SetActive(true);
        jumpScore.text = Mathf.Clamp(numScore, 0, 99999999).ToString();
        score += numScore;
    }

    IEnumerator ResultTime()
    {

        bool SL = false;
        int rollScore = 0;
        float walkdis = 0.0f;
        float c = 0.0f;
        res = true;
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
                audioSource.Play();
                SL = false;
            }
            yield return null;
            c += Time.unscaledDeltaTime;
            if (c > 1.0f / 60)
            {
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

        if (walkDis >= 50000)
        {
            num = 31111;
        }
        else if (walkDis >= 10000)
        {
            num = 1111;
        }
        else if (walkDis >= 1000)
        {
            num = 111;
        }
        else if (walkDis >= 100)
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
                audioSource.Play();
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
                Distance.text = Mathf.Clamp(walkdis, 0, 9999).ToString("f2") + "m";
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
