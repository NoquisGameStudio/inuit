using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(gameObject.transform.position.y < cam.ScreenToWorldPoint(Vector2.zero).y - 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
