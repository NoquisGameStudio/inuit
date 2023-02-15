using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerza_estalactita : MonoBehaviour
{
        
    private Rigidbody2D rb;
    public Vector3 velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocidad * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            print("menos vida");
            //quitar vida
        }
    }
}
