using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{

    private float giro = 0.0f;
    void Update()
    {
        giro -= 0.25f;
        transform.Rotate(0, 0, giro, Space.Self);
    }
}
