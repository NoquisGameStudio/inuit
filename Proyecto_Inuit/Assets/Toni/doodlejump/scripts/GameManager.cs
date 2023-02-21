using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Camera cam;
    public GameObject apple;
    public GameObject player;
    public Text text;

    private int platformCount = 500;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        spawnPosition.y = Random.Range(.4f, .5f);
        spawnPosition.x = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x + 0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * -2 - 0.1f);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 1.5f);
            spawnPosition.x = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x+0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * - 2 - 0.1f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        int randNUM = Random.Range(0, 100);
        if (randNUM == 50)
        {
            int randNUM2 = Random.Range(0, 10);
            if(randNUM2 == 5)
            {
                float randx = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x + 0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * -2 - 0.1f);

                Instantiate(apple, new Vector2(randx, cam.ScreenToWorldPoint(Vector2.zero).y + 10f), apple.transform.rotation);
            }
        }
    }

    public void UpdateText()
    {
        score += 1;
        text.text = "Score: " + score;
    }
}
