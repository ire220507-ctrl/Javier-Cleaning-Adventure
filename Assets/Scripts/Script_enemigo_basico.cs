using UnityEngine;

public class Script_enemigo_basico : MonoBehaviour
{
    public float distancia = 3f;   // recorrido hacia cada lado desde el punto inicial
    public float valocidad = 1;

    public string tagJugador = "Player";
    public float reboteJugador = 8f;   // pequeño salto del jugador al pisar
    public float margenPisada = 0.5f;  // cuánto debe venir "de arriba" el contacto

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    private float limiteIzq;
    private float limiteDer;
    private float destinoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Los límites salen de donde colocas el enemigo en la escena
        limiteIzq = transform.position.x - distancia;
        limiteDer = transform.position.x + distancia;
        destinoX = limiteDer;
    }

    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        float paso = valocidad * Time.deltaTime;
        Vector3 destino = new Vector3(destinoX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);

        // Al llegar al límite, cambia de lado
        if (Mathf.Approximately(transform.position.x, destinoX))
        {
            destinoX = (destinoX == limiteDer) ? limiteIzq : limiteDer;
            sr.flipX = destinoX < transform.position.x; // gira el sprite
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(tagJugador)) return;

        foreach (ContactPoint2D punto in col.contacts)
        {
            // La normal apunta hacia el enemigo desde el jugador: si es negativa en Y, el jugador está encima
            if (punto.normal.y < -margenPisada)
            {
                Morir(col.rigidbody);
                return;
            }
        }

        // Aquí iría el daño al jugador si lo toca de lado
    }

    void Morir(Rigidbody2D rbJugador)
    {
        if (rbJugador != null)
            rbJugador.linearVelocity = new Vector2(rbJugador.linearVelocity.x, reboteJugador);

        animator.SetTrigger("muerto");
        Destroy(gameObject);
    }
}
