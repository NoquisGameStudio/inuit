using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=5.0f;
    public Vector2 mov;
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue input)
    {
        mov = input.Get<Vector2>();
        

    }
    public bool jump = false;
    public void OnJump(InputValue input)
    {

        jump = true;
    }

    private void FixedUpdate()
    {
        anim.SetFloat("x", mov.x);
        anim.SetFloat("y", mov.y);

        
        transform.Translate(Vector2.up * speed * mov.y);
        transform.Translate(Vector2.right * speed * mov.x);


        if (jump)
        {
            Vector2 jum = new Vector2(0, 5);
            //transform.Translate(Vector2.up * 100f * Time.fixedDeltaTime);
            //rb.AddForce(Physics.gravity * (5 - 1) * rb.mass);
            transform.Translate(Vector3.up * 100 * Time.deltaTime, Space.World);
            jump =false;
        }


    }

}
