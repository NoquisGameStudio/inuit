using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerzaPlayerBola : MonoBehaviour
{
    public float velocidad;
    GameObject Player;
    // Start is called before the first frame update
        Vector3 shootDirection;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - Player.transform.position;

        //p.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * velocidad_proyectil, shootDirection.y * velocidad_proyectil);
    }

    // Update is called once per frame
    void Update()
    {
        float vel = velocidad;
        transform.Translate(new Vector3(shootDirection.x * velocidad, shootDirection.y * velocidad, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);

        }
        
    }
}
