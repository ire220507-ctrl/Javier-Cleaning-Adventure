using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoProtagonista : MonoBehaviour
{


    public float velocidad = 5f;
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    public bool isGrounded = true;
    bool dashing = true;
    public float startDashTime;
    public float dashTime;
    public float dashSpeed;
    public float airFrictionForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        movement();
        if (isGrounded)
        {
            jump();
        }

        Vector2 inputDash = InputSystem.actions["Move"].ReadValue<Vector2>();


    }

    private void movement()
    {
        Vector2 input = InputSystem.actions["Move"].ReadValue<Vector2>();
        Vector3 direccion = new Vector3(input.x, 0, 0);
        transform.position += direccion * velocidad * Time.deltaTime;

       if (direccion.x < 0)
        {
            sr.flipX = true;
        } else if(direccion.x > 0)
        {
            sr.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(input.x));

        if (InputSystem.actions["Dash"].WasPressedThisFrame())
        {
            transform.position += direccion * velocidad * Time.deltaTime * 30;
            // animator.SetTrigger("Jump");

        }


    }

    private void jump()
    {
        if (InputSystem.actions["Jump"].WasPressedThisFrame() & isGrounded)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetTrigger("Ground");
        }


    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
