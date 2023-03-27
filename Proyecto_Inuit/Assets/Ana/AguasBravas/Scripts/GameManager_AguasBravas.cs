using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager_AguasBravas : MonoBehaviour
{
    public GameObject sc = null;
    //private TextMeshPro scoreText;
    private int score;
    private double scale;
    public GameObject pantallaCarga;
    public GameObject level = null;
    public HorizontalController player;

    private void Start()
    {
        scale = 0.1;
        
    }

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
            Play();
            
        }
    }

    public void Play()
    {
        pantallaCarga.SetActive(false);
        player.enabled = true;
        score = 0;
        if (sc != null)
        {
            sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
        }
        
        
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
        PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") - 1 );
        SceneManager.LoadScene("lobby_tiles");
    }

    public void Win()
    {
        PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + 5);
        SceneManager.LoadScene("lobby_tiles");
    }
    
    public void IncreaseScore()
    {
        if (level != null)
        {
            scale += 0.1;
            level.transform.localScale = new Vector3(1.0f, (float)scale, 1.0f);
            
            if (scale >= 2.15)
            {
                Win();
            }
        }
        
        if (sc != null)
        {
            score++;
            sc.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
            
            if (score >= 10)
            {
            
                Win();
            }
        }
        
        

        
    }
}
