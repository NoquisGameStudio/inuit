using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl_plataformas : MonoBehaviour
{
    public GameObject platformPrefab; 
    public int numOfPlatforms = 20; // N�mero de plataformas
    public float levelWidth = 50f; // Ancho del nivel

    public float minY = .2f; // Altura m�nima de la plataforma
    public float maxY = 1.5f; // Altura m�xima de la plataforma


    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        // Generar plataformas aleatorias
        for (int i = 0; i < numOfPlatforms; i++)
        {
            spawnPosition.x += Random.Range(minY, maxY)+2;
            spawnPosition.y = Random.Range(-levelWidth, levelWidth);

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
