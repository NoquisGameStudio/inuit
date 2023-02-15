using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    //variables para sprites
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    
    //variables para mecánica
    private Vector3 dir;
    public float gravity = -9.8f;
    public float strength = 5;
    public GameManager_FlappyChaman gameManager;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            dir = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                dir = Vector3.up * strength;
            }
        }

        dir.y += gravity * Time.deltaTime;
        
        //actualiza la posicion del Player
        transform.position += dir * Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
        }
        else if(other.gameObject.tag == "Score")
        {
            gameManager.IncreaseScore();
        }
    }
}
