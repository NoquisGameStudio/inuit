using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Camera cam;
    public GameObject apple;
    public GameObject player;

    public int platformCount = 100;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        spawnPosition.y += Random.Range(.5f, 1f);
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
        if (randNUM == 75)
        {
            float randx = Random.Range(cam.ScreenToWorldPoint(Vector2.zero).x + 0.1f, cam.ScreenToWorldPoint(Vector2.zero).x * -2 - 0.1f);

            Instantiate(apple, new Vector2(randx, cam.ScreenToWorldPoint(Vector2.zero).y + 10f), apple.transform.rotation);
        }
    }
}