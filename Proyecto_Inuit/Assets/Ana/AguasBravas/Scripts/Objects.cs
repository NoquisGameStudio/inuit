using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public float speed = 5f;
    private float bottom;

    private void Start()
    {
        bottom = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f;
    }

    private void Update()
    {
        transform.position -= Vector3.up * speed * Time.deltaTime;

        if (transform.position.y < bottom)
        {
            Destroy(gameObject);
        }
    }
}
