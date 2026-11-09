using UnityEngine;

public class Script_enemigo_basico : MonoBehaviour
{
    public Transform target;
    public float valocidad = 1;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        float paso = valocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, paso);
    }
}
