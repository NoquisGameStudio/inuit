using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estalactitas_horizontales : MonoBehaviour
{
    public GameObject mang;
    private float ancho;
    private float max;
    private float min;

    public GameObject stalactita;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ancho = mang.GetComponent<lvl_plataformas>().levelWidth;
        max = ancho ;
        min = -(ancho );

        
            int randNUM=Random.Range(0, 100);
            if (randNUM==50)
            {
                Instantiate(stalactita, new Vector2(player.position.x+10, player.position.y),stalactita.transform.rotation);
            }
        

    }
    
}
