using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerzabola : MonoBehaviour
{
    public float velocidad;
    public int daño;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,velocidad,0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //quitar vida player
            GameObject.FindGameObjectWithTag("Player").GetComponent<vida_player>().vida--;
            

        }
            Destroy(gameObject);
    }

    
}
