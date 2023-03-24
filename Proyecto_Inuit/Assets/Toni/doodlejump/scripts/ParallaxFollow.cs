using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFollow : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public GameObject player;

    public bool movimiento_horizontal = true;

    public float velocidad = 0.1f;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (movimiento_horizontal)
        {
            meshRenderer.material.mainTextureOffset = new Vector2(velocidad * player.transform.position.x, 0);
        }
        else
        {
            meshRenderer.material.mainTextureOffset = new Vector2(0, velocidad * player.transform.position.y);
        }

    }
}
