using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl_plataformas : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numOfPlatforms = 20; // Número de plataformas
    //public GameObject[] array=new GameObject[20];
    public float levelWidth = 50f; // Ancho del nivel

    public float minY = .2f; // Altura mínima de la plataforma
    public float maxY = 1.5f; // Altura máxima de la plataforma

    GameObject jumper;
    void Start()
    {
        
        Vector3 spawnPosition = new Vector3();
        GameObject[] array = new GameObject[numOfPlatforms];

        // Generar plataformas aleatorias
        for (int i = 0; i < numOfPlatforms; i++)
        {
            spawnPosition.x += Random.Range(minY, maxY)+2;
            spawnPosition.y = Random.Range(-levelWidth, levelWidth);

            GameObject inst=Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            array[i] = inst;
        }

        GameObject primera = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            GameObject segunda = array[i];
            jumper = primera.transform.GetChild(0).gameObject;

            if (primera.transform.position.y+1 < segunda.transform.position.y )
            {
                jumper.SetActive(true);
                
            }
            else
            {
                jumper.SetActive(false);
            }
            primera = segunda;
        }

    }
}
