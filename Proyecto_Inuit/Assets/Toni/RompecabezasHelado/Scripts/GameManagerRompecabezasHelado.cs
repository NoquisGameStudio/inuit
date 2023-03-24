using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRompecabezasHelado : MonoBehaviour
{
    public List<GameObject> startPosition;
    public GameObject player;

    // Update is called once per frame

    private void Awake()
    {
        Debug.Log(startPosition[0].transform.position);
        Debug.Log(player.transform.position);
        player.transform.position = new Vector3(startPosition[0].transform.position.x, startPosition[0].transform.position.y, startPosition[0].transform.position.z);
    }
    void Update()
    {
        
    }
}
