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
    private bool isGrounded = true;

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
        Vector2 input = InputSystem.actions["Move"].ReadValue<Vector2>();
        if (input.x >= 0)
        {
            sr.flipX = false;

        }
        else
        {
            sr.flipX = true;
        }
        Vector3 direccion = new Vector3(input.x, 0, input.y);
        transform.position += direccion * velocidad * Time.deltaTime;

        animator.SetFloat("Speed", Mathf.Abs(input.x));
    }
}
