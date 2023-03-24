using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Camera cam;
    public GameObject apple;
    public GameObject player;
    public Text Score;
    public Text timer;

    private int platformCount = 500;
    private int score = 0;
    private float Tiempo = 60.0f;
    private bool DebeAumentar = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        spawnPosition.y = Random.Range(.3f, .4f);
        spawnPosition.x = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x + 0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * -2 - 0.1f);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 1.2f);
            spawnPosition.x = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x+0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * - 2 - 0.1f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }  
    }

    private void Update()
    {
        int randNUM = Random.Range(0, 100);
        if (randNUM == 50)
        {
            float randx = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x + 0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * -2 - 0.1f);
            Instantiate(apple, new Vector2(randx, cam.ScreenToWorldPoint(Vector2.zero).y + 10f), apple.transform.rotation);
        }

        if(Tiempo >= 0.0f && Tiempo <= 60.0f)
        {
            setTime();
        }
        else if(Tiempo <= 0.0f)
        {
            PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + score);
            SceneManager.LoadScene("lobby_tiles");
        }
    }

    public void setTime()
    {
        // Se comprueba si debe aumentar el valor primero
        DebeAumentar = (Tiempo <= 0.0f) ? true : false;

        // Luego se efectua el aumento.
        if (DebeAumentar) Tiempo += Time.deltaTime;
        else Tiempo -= Time.deltaTime;

        // Se asigna el color dependiendo del tiempo restante.
        timer.color = (Tiempo <= 10.0f) ? Color.red : Color.green;

        timer.text = "Tiempo:" + " " + Tiempo.ToString("f0");
    }

    public void UpdateText()
    {
        GetComponent<AudioSource>().Play();
        score += 1;
        Score.text = "Score: " + score;
    }
}
