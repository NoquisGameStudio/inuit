using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingu : MonoBehaviour
{
    //variables para sprites
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
