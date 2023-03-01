using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager_AguasBravas : MonoBehaviour
{
    public GameObject sc;
    //private TextMeshPro scoreText;
    private int score;

    public HorizontalController player;

    private void Start()
    {
        //scoreText = sc.GetComponentInChildren<TextMeshPro>();
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        player.enabled = true;
        score = 0;
        sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
        
        Time.timeScale = 1f;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        
        Pause();
    }
    
    public void IncreaseScore()
    {
        score++;
        sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
    }
}
