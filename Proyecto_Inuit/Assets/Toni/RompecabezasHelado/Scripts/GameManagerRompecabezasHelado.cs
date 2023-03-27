using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerRompecabezasHelado : MonoBehaviour
{
    public List<GameObject> startPosition;
    public List<GameObject> endPosition;
    public GameObject player;
    public GameObject canvas;

    public MovementRompecabezas MovementRompecabezas;
    private int index = 0;

    // Update is called once per frame

    private void Awake()
    {
        player.transform.position = new Vector3(startPosition[index].transform.position.x, startPosition[index].transform.position.y, startPosition[index].transform.position.z);
        canvas.SetActive(true);
        Time.timeScale = 0;
    }
    void Update()
    {
        if(startPosition.Count > 0 && player.transform.position.ToString("F1") == endPosition[index].transform.position.ToString("F1"))
        {
            MovementRompecabezas.start = false;

            startPosition.RemoveAt(index);
            endPosition.RemoveAt(index);

            index = Random.Range(0, startPosition.Count);
            if(index < 0)
            {
                PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + 15);
                SceneManager.LoadScene("lobby_tiles");
            }
            else 
            {
                player.transform.position = new Vector3(startPosition[index].transform.position.x, startPosition[index].transform.position.y, startPosition[index].transform.position.z);
            }
        }
        else if(startPosition.Count <= 0)
        {
            PlayerPrefs.SetFloat("DañoPlayer", PlayerPrefs.GetFloat("DañoPlayer") + 15);
            SceneManager.LoadScene("lobby_tiles");
        }

        if (index >= 0 && player.transform.position.ToString("F1") == startPosition[index].transform.position.ToString("F1"))
        {
            MovementRompecabezas.start = true;
            MovementRompecabezas.setRay(0);
            MovementRompecabezas.setMoving(false);
        }

        if(Input.GetKeyDown("space"))
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
