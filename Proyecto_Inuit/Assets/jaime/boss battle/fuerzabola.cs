using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerzabola : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody2D>().AddForce(transform.up * 50);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0.01f,0));
    }
}
