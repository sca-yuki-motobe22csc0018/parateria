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
    int numScore;
    float wait = 2.0f;
    public Image fade;
    [SerializeField] float FadeTime;
    float count;
    float num = 0.0f;
    float Fade = 1.0f;

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
        Time.timeScale = 1;
        change = false;
        count = 0.0f;
        RankingPanel.anchoredPosition = new Vector2(0, 0);
        MoveStart(0, 1000.0f, 3.0f);
        StartCoroutine(RankTime());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator RankTime()
    {
        RankChange(Player.score);
        RankText[0].text = " " + nameRank[0] + "  " + scoreRank[0];
        RankText[1].text = " " + nameRank[1] + "  " + scoreRank[1];
        RankText[2].text = " " + nameRank[2] + "  " + scoreRank[2];
        RankText[3].text = " " + nameRank[3] + "  " + scoreRank[3];
        RankText[4].text = " " + nameRank[4] + "  " + scoreRank[4];
        RankText[5].text = " " + nameRank[5] + "  " + scoreRank[5];
        RankText[6].text = " " + nameRank[6] + "  " + scoreRank[6];
        RankText[7].text = " " + nameRank[7] + "  " + scoreRank[7];
        RankText[8].text = " " + nameRank[8] + "  " + scoreRank[8];
        RankText[9].text = " " + nameRank[9] + "  " + scoreRank[9];
        while (Fade > 0.0f)
        {
            yield return null;
            count += Time.deltaTime;
            num = (count % FadeTime) / FadeTime;
            Fade -= num;
            Debug.Log(Fade);
            if (Fade < 0.01f)
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
        while (y < 1000.0f)
        {
            if (SL)
            {
                audioSource.PlayOneShot(drumRoll2);
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
            if (Fade > 0.99f)
            {
                Fade = 1.0f;
            }
            fade.GetComponent<Image>().color = new Color(0, 0, 0, Fade);
        }
        yield return new WaitForSecondsRealtime(1.0f);
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
}
