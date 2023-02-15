using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoodleJumpMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Vector2 mov;
    Animator anim;
    private Rigidbody2D rb;
    private bool jump = false;

    private PlayerInput input;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        input = GetComponent<PlayerInput>();

        input.actions["Player/Move"].performed += OnMove;
        input.actions["Player/Move"].canceled += OnMove;

        input.actions["Player/Jump"].performed += OnJump;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        mov = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = true;
    }

    private void FixedUpdate()
    {

        if(mov != null)
        {
            anim.SetFloat("x", mov.x);
            transform.Translate(Vector2.right * speed * mov.x * Time.fixedDeltaTime);
        }

        if (jump)
        {
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
