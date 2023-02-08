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

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputValue input)
    {
        mov = input.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("x", mov.x);
        anim.SetFloat("y", mov.y);

        transform.Translate(Vector2.up * speed * mov.y * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * speed * mov.x * Time.fixedDeltaTime);
    }
}
