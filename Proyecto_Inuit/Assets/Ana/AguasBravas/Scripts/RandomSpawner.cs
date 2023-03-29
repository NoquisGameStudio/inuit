using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public GameObject score;
    public GameObject score2;
    public GameObject score3;
    public GameObject obstacle;
    
    public float sRate = 1f;
    public float min = -1f;
    public float max = 1f;

    private int rango = 4;
    
    private void OnEnable()
    {
       // sRate = Random.Range(0.5f, 2f);
        
        InvokeRepeating(nameof(Spawn), Random.Range(0.5f, 2f), Random.Range(0.5f, 1.5f));
        InvokeRepeating(nameof(AumentoRango), 10, 5);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void AumentoRango()
    {
        rango += 1;
    }

    private void Spawn()
    {
        int obj = Random.Range(1, rango);

        if (obj == 1)
        {
            GameObject sc = Instantiate(score, transform.position, Quaternion.identity);
            sc.transform.position += Vector3.left * Random.Range(min, max);
        }
        else if (obj == 2)
        {
            if (score2 != null)
            {
                GameObject sc2 = Instantiate(score2, transform.position, Quaternion.identity);
                sc2.transform.position += Vector3.left * Random.Range(min, max);
            }
        }
        else if(obj == 3)
        {
            if (score3 != null)
            {
                GameObject sc3 = Instantiate(score3, transform.position, Quaternion.identity);
                sc3.transform.position += Vector3.left * Random.Range(min, max);
            }
        }
        else
        {
            GameObject obs = Instantiate(obstacle, transform.position, Quaternion.identity);
            obs.transform.position += Vector3.left * Random.Range(min, max);
        }
        
    }
    
    
}
