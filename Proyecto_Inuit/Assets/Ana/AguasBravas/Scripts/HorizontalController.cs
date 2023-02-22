using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalController : MonoBehaviour
{
    public float speed;

    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position = position;
    }
}
