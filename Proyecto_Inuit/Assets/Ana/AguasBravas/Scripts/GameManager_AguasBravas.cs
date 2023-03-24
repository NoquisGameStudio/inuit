using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager_AguasBravas : MonoBehaviour
{
    public GameObject sc;
    //private TextMeshPro scoreText;
    private int score;
    private double scale;

    public GameObject level;
    public HorizontalController player;

    private void Start()
    {
        scale = 0.1;
        
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        //Pause();
        Play();
    }

    public void Play()
    {
        player.enabled = true;
        score = 0;
        sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
        
        Time.timeScale = 1f;
        
        Spawner[] objetos = FindObjectsOfType<Spawner>();

        for (int i = 0; i < objetos.Length; i++)
        {
            Destroy(objetos[i].gameObject);
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
        
        PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") - 1 );
        SceneManager.LoadScene("lobby_tiles");
    }

    public void Win()
    {
        Pause();
        
        PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + 5);
        SceneManager.LoadScene("lobby_tiles");
    }
    
    public void IncreaseScore()
    {
        score++;
        scale += 0.1;
        level.transform.localScale = new Vector3(1.0f, (float)scale, 1.0f);
        sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
        if (scale >= 2.15)
        {
            Win();
        }
    }
}
