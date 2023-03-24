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


    private void OnEnable()
    {
        sRate = Random.Range(0.5f, 2f);
        
        InvokeRepeating(nameof(Spawn), Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    
    private void Spawn()
    {
        int obj = Random.Range(1, 5);

        switch (obj)
        {
            case 1:
                GameObject sc = Instantiate(score, transform.position, Quaternion.identity);
                sc.transform.position += Vector3.left * Random.Range(min, max);
                break;
            case 2:
                if (score2 != null)
                {
                    GameObject sc2 = Instantiate(score2, transform.position, Quaternion.identity);
                    sc2.transform.position += Vector3.left * Random.Range(min, max);
                }
                else
                {
                    sc = Instantiate(score, transform.position, Quaternion.identity);
                    sc.transform.position += Vector3.left * Random.Range(min, max);
                }
                
                break;
            case 3:
                if (score3 != null)
                {
                    GameObject sc3 = Instantiate(score3, transform.position, Quaternion.identity);
                    sc3.transform.position += Vector3.left * Random.Range(min, max);
                }
                else
                {
                    sc = Instantiate(score, transform.position, Quaternion.identity);
                    sc.transform.position += Vector3.left * Random.Range(min, max);
                }
                break;
            case 4:
                GameObject obs = Instantiate(obstacle, transform.position, Quaternion.identity);
                obs.transform.position += Vector3.left * Random.Range(min, max);
                break;
            default:
                break;
        }
        
    }
    
    
}
