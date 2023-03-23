using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_FlappyChaman : MonoBehaviour
{
    public GameObject sc;
    //private TextMeshPro scoreText;
    public GameObject gameOver;
    public GameObject playbutton;
    private int score;

    public Player player;

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
        gameOver.SetActive(false);
        playbutton.SetActive(false);
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
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        
        Pause();
        //en lugar de "GAME OVER" mostrar mensaje "has conseguido x ptos"
        gameOver.SetActive(true);

        if (score > 10)
        {
            PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + (score/5));
            SceneManager.LoadScene("lobby_tiles");
        }
        else
        {
            PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") - 1 );
            SceneManager.LoadScene("lobby_tiles");
        }
        
    }
    
    public void IncreaseScore()
    {
        score++;
        sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
    }
}
