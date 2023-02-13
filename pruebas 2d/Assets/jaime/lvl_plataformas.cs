using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl_plataformas : MonoBehaviour
{
    public GameObject platformPrefab; 
    public int numOfPlatforms = 20; // Número de plataformas
    public float levelWidth = 50f; // Ancho del nivel

    public float minY = .2f; // Altura mínima de la plataforma
    public float maxY = 1.5f; // Altura máxima de la plataforma


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
