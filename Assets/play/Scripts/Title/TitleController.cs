using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public AudioClip select;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartGame(int num)
    {
        audioSource.PlayOneShot(select);
        if (num == 1)
        {
            SceneManager.LoadScene("CharaSelect");
        }
        else if (num == 2)
        {
            SceneManager.LoadScene("Ranking");
        }
        
    }
}
