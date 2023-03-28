using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlechaMisiones : MonoBehaviour
{
    public Transform target;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) 
        {  
            Vector2 dif = transform.position - target.position;
            float ang=Mathf.Atan2(dif.y, dif.x)*Mathf.Rad2Deg;
            transform.rotation=Quaternion.Euler(0,0,ang+offset);
        }
    }
}
