using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerza_estalactita : MonoBehaviour
{
        
    private Rigidbody2D rb;
    public Vector3 velocidad;
    bool va = true;
    private Animator anima;
    private Collider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (va)
        {
            transform.position += velocidad * Time.deltaTime;
        }
        

    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {

            va = false;
            anima.Play("estalactita rota");
            col.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(anim());
        }
        if (collision.gameObject.tag == "Player")
        {
            print("menos vida");
            //quitar vida
        }
    }
    IEnumerator anim()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
