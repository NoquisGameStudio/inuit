using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public GameObject score;
    public GameObject obstacle;
    
    public float sRate = 1f;
    public float min = -1f;
    public float max = 1f;

    private void OnEnable()
    {
        sRate = Random.Range(0.5f, 2f);
        
        InvokeRepeating(nameof(Spawn), sRate, sRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    
    private void Spawn()
    {
        int obj = Random.Range(1, 2);
        if (obj == 1)
        {
            GameObject sc = Instantiate(score, transform.position, Quaternion.identity);
            sc.transform.position += Vector3.left * Random.Range(min, max);
        }
        
    }
    
    
}
