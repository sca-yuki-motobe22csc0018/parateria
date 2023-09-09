using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    int rank = 10;
    public static int[] scoreRank = new int[10];
    public static string[] nameRank = new string[10];
    bool change;
    int newScore;
    string newName;
    string name;
    public Text[] RankText = new Text[10];
    public Text[] ScoreText = new Text[10];
    int numScore;
    float wait = 2.0f;
    public Image fade;
    [SerializeField] float FadeTime;
    float count;
    float num = 0.0f;
    float Fade = 1.0f;
    public static bool Default=false;

    public RectTransform RankingPanel;
    float y, startY ,endY;
    float moveTime;
    float nowTime;
    public AudioClip drumRoll1;
    public AudioClip drumRoll2;
    public AudioClip drumRollEnd;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (!Default)
        {
            for (int i = 0; i < 9; ++i)
            {
                if (i == 0)
                {
                    nameRank[i] = "Pikuru";
                }
                else if (i == 1)
                {
                    nameRank[i] = "Iroa";
                }
                else if (i == 2)
                {
                    nameRank[i] = "Bisuke";
                }
                else
                {
                    nameRank[i] = "Guest";
                }
            }
            for (int i = 0; i < 9; ++i)
            {
                if (i == 0)
                {
                    scoreRank[i] = 9980760;
                }
                else if (i == 1)
                {
                    scoreRank[i] = 4097818;
                }
                else if (i == 2)
                {
                    scoreRank[i] = 3730061;
                }
                else
                {
                    scoreRank[i] = 100000;
                }
            }
            Default = true;
        }
        Time.timeScale = 1;
        change = false;
        count = 0.0f;
        y=1000;
        RankingPanel.anchoredPosition = new Vector2(0, y);
        MoveStart(0, 0.0f, 3.0f);
        StartCoroutine(RankTime());
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Return))
        {
            Skip();
        }
    }

    IEnumerator RankTime()
    {
        if (Name._rank == true)
        {
            RankChange(Player.score);
        }


        for (int i = 0; i < 10; ++i)
        {
            RankText[i].text = nameRank[i];
        }
        for (int i = 0; i < 10; ++i)
        {
            ScoreText[i].text = scoreRank[i].ToString();
        }

        while (Fade > 0.0f)
        {
            yield return null;
            count += Time.deltaTime;
            num = (count % FadeTime) / FadeTime;
            Fade -= num;
            if (Fade < 0.1f)
            {
                Fade = 0.0f;
            }
            fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade);
            if (Fade > 0.0f)
            {
                Fade = 1.0f;
            }
        }
        count = 0.0f;
        Fade = 0.0f;
        fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade);

        yield return new WaitForSecondsRealtime(wait);
        bool SL = false;
        if (!SL)
        {
            audioSource.PlayOneShot(drumRoll1);
            audioSource.loop = !audioSource.loop;
            SL = true;
        }
        while (y > 0.0f)
        {
            if (SL)
            {
                audioSource.Play();
                SL = false;
            }
            yield return null;
            nowTime += Time.deltaTime;
            if (nowTime > moveTime)
            {
                nowTime = moveTime;
            }
            y = nowTime / moveTime * (endY - startY) + startY;
            RankingPanel.anchoredPosition = new Vector2(0.0f, y);

        }
        audioSource.loop = !audioSource.loop;
        audioSource.PlayOneShot(drumRollEnd);
        yield return new WaitForSecondsRealtime(3.0f);

        while (Fade < 1.0f)
        {
            yield return null;
            count += Time.deltaTime;
            Fade = (count % FadeTime) / FadeTime;
            if (Fade > 0.9f)
            {
                Fade = 1.0f;
            }
            fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade);
        }
        yield return new WaitForSecondsRealtime(1.0f);
        Title();
    }

    void Title()
    {
        SceneManager.LoadScene("Title");
    }

    void RankChange(int score)
    {
        if (score > scoreRank[rank - 1])
        {
            for (int i = 0; i < rank; ++i)
            {
                if (scoreRank[i] < score)
                {
                    if (!change)
                    {
                        change = true;
                        newName = nameRank[i];
                        nameRank[i] = Name.nameKind[Name.count];
                        name = newName;
                    }
                    else
                    {
                        newName = nameRank[i];
                        nameRank[i] = name;
                        name = newName;
                    }
                    newScore = scoreRank[i];
                    scoreRank[i] = score;
                    score = newScore;
                }
            }
        }
    }

    void MoveStart(float toX, float toY, float time)
    {
        if (time == 0.0f)
        {
            RankingPanel.anchoredPosition = new Vector2(toX, toY);
            return;
        }
        else
        {
            startY = y;
            endY = toY;
        }
        moveTime = time;
        nowTime = 0.0f;
        return;
    }

    public void Skip()
    {
        y = 0;
        RankingPanel.anchoredPosition = new Vector2(0, y);
        audioSource.Stop();
        audioSource.PlayOneShot(drumRollEnd);
        Invoke("Title", 0.5f);
    }
}
