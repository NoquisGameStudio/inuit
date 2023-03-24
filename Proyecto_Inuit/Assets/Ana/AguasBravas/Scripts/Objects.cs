using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float speed = 5f;
    private float bottom;
    private float top;
    public bool objetosUp = true;

    private void Start()
    {
        bottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f;
        top = Camera.main.ScreenToWorldPoint(Vector3.zero).y + Screen.height;
    }

    private void Update()
    {
        if (!objetosUp)
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
         
            if (transform.position.y < bottom)
            {
             Destroy(gameObject);
            }
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
         
            if (transform.position.y > top)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
