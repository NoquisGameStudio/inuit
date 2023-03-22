using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DoodleJumpMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    public Camera cam;
    public UnityEvent Events;

    private Vector2 mov;
    private Animator anim;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool canJump = false;
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
        if(canJump)
        {
            jump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Floor"))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (collision.CompareTag("Score"))
        {
            collision.enabled = false;
            Events.Invoke();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(gameObject.transform.position.x < cam.ScreenToWorldPoint(Vector2.zero).x)
        {
            transform.Translate(new Vector2(cam.ScreenToWorldPoint(Vector2.zero).x * -2, 0));
        }
        else if(gameObject.transform.position.x > cam.ScreenToWorldPoint(Vector2.zero).x * -1)
        {
            transform.Translate(new Vector2(cam.ScreenToWorldPoint(Vector2.zero).x * 2, 0));
        }
        else if(gameObject.transform.position.y < cam.ScreenToWorldPoint(Vector2.zero).y)
        {
            cam.transform.Translate(new Vector2(0, -0.01f));
        }
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
