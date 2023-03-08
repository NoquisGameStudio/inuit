using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementRompecabezas : MonoBehaviour
{
    private Animator anim;
    private Vector2 move;
    private RaycastHit2D hit;
    private bool moving = false;
    private Vector2 oldmove;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        if(move != null)
        {
            if(!moving)
            {
                hit = Physics2D.Raycast(transform.position, move);
                oldmove = move;
                
            }

            if (hit.collider != null)
            {
                if (Mathf.Abs(hit.distance) > 0.25)
                {
                    moving = true;
                    Vector2 dest = hit.transform.position - new Vector3(oldmove.x, oldmove.y, 0);
                    transform.position = Vector2.Lerp(transform.position, dest, Time.deltaTime * 1.7f);

                    if (((float)transform.position.magnitude).ToString("F2") == ((float)(dest.magnitude)).ToString("F2"))
                    {
                        moving = false;
                    }
                }
            }
        }
    }

    public void OnMove(InputValue input)
    {
        move = input.Get<Vector2>();
    }
}
