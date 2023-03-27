using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager_FlappyChaman : MonoBehaviour
{
    public GameObject sc;
    //private TextMeshPro scoreText;
    private int score;
    public GameObject pantallaCarga;
    public Player player;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        pantallaCarga.SetActive(true);
        Pause();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pantallaCarga.SetActive(false);
            Play();
        }
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
