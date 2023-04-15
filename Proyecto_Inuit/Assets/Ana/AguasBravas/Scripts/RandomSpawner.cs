using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Diagnostics;

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
    private float reprate = 1.0f;

    private Stopwatch stopwatch;
    private bool rapido = false, masrapido = false;
    private void OnEnable()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        InvokeRepeating(nameof(Spawn), 0.5f, reprate);
    }

    private void Update()
    {
        float tiempoTranscurrido = (float)stopwatch.Elapsed.TotalSeconds;
        if (!rapido && !masrapido)
        {
            if (tiempoTranscurrido > 5.0f)
            {
                reprate = 0.5f;
                CancelInvoke(nameof(Spawn));
                InvokeRepeating(nameof(Spawn), 0f, reprate);
                rapido = true;
            }
        }
        else if(rapido && !masrapido)
        {
            if (tiempoTranscurrido > 15.0f)
            {
                reprate = 0.2f;
                CancelInvoke(nameof(Spawn));
                InvokeRepeating(nameof(Spawn), 0f, reprate);
                masrapido = true;
            }
        }
        
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        int obj = Random.Range(1, 5);

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
            else
            {
                GameObject sc = Instantiate(score, transform.position, Quaternion.identity);
                sc.transform.position += Vector3.left * Random.Range(min, max);
            }
        }
        else if(obj == 3)
        {
            if (score3 != null)
            {
                GameObject sc3 = Instantiate(score3, transform.position, Quaternion.identity);
                sc3.transform.position += Vector3.left * Random.Range(min, max);
            }
            else
            {
                GameObject obs = Instantiate(obstacle, transform.position, Quaternion.identity);
                obs.transform.position += Vector3.left * Random.Range(min, max);
            }
        }
        else
        {
            GameObject obs = Instantiate(obstacle, transform.position, Quaternion.identity);
            obs.transform.position += Vector3.left * Random.Range(min, max);
        }
        
    }
    
    
}
