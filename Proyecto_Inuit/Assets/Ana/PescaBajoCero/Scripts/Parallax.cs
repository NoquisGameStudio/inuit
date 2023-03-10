using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animSpeed = 0.5f;

    public bool horizontal = true;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (horizontal)
        {
            meshRenderer.material.mainTextureOffset += new Vector2(animSpeed * Time.deltaTime, 0.0f);
        }
        else
        {
            meshRenderer.material.mainTextureOffset += new Vector2(0.0f, animSpeed * Time.deltaTime);
        }
        
    }
}
