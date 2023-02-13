using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PC_plataformas2d : MonoBehaviour
{

    public float speed = 5.0f;
    Vector2 mov;
    public float jumpForce = 400f;
    private bool isGrounded;

    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetFloat("x", mov.x);
        //anim.SetFloat("y", mov.y);

       // transform.Translate(Vector2.up * speed * mov.y);
        transform.Translate(Vector2.right * speed * mov.x);
    }

    void Update()
    {
        Vector2 boxSize = new Vector2(bc.size.x * 0.9f, 0.1f);
        Vector2 boxCenter = new Vector2(bc.bounds.center.x, bc.bounds.min.y);

        isGrounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, LayerMask.GetMask("Floor"));
    }

    public void OnMove(InputValue input)
    {
        mov = input.Get<Vector2>();

    }

    public void OnJump(InputValue input)
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isGrounded = false;
        }
    }
}
