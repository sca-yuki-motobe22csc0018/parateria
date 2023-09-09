using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public AudioClip select;

    AudioSource audioSource;

    public GameObject asobikata;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        asobikata.SetActive(false);
    }

    public void SE()
    {
        audioSource.PlayOneShot(select);
    }

    public void StartGame(int num)
    {
        SE();
        if (num == 1)
        {
            SceneManager.LoadScene("CharaSelect");
        }
        else if (num == 2)
        {
            Name._rank = false;
            SceneManager.LoadScene("Ranking");
        }
        else if (num == 3)
        {
            asobikata.SetActive(true);
        }
    }
}
