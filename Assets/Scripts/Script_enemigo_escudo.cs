using UnityEngine;

public class Script_enemigo_escudo : MonoBehaviour
{
    public float distancia = 3f;
    public float valocidad = 1;

    public string tagJugador = "Player";
    public float reboteJugador = 8f;

    public Transform escudo;                          // el objeto hijo del escudo
    public Vector3 posicionArriba = new Vector3(0f, 1f, 0f); // posición local del escudo sobre la cabeza
    public float rotacionArriba = 90f;                // giro del escudo cuando está arriba (ajustarlo cuando se hagan pruebas)
    public float rangoReaccion = 4f;                  // a qué distancia reacciona al salto del jugador

    private Vector3 posicionFrente;
    private Quaternion rotacionFrente;
    private Transform jugador;
    private Rigidbody2D rbJugador;

    private float limiteIzq;
    private float limiteDer;
    private float destinoX;
    private float mirando = 1f;   // 1 = derecha, -1 = izquierda

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        limiteIzq = transform.position.x - distancia;
        limiteDer = transform.position.x + distancia;
        destinoX = limiteDer;
        Girar(1f);
        
        // Guarda la posición inicial del escudo (delante)
        posicionFrente = escudo.localPosition;
        rotacionFrente = escudo.localRotation;

        // Busca al jugador
        GameObject obj = GameObject.FindGameObjectWithTag(tagJugador);
        if (obj != null)
        {
            jugador = obj.transform;
            rbJugador = obj.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        movimiento();
        ActualizarEscudo();
    }

    void movimiento()
    {
        float paso = valocidad * Time.deltaTime;
        Vector3 destino = new Vector3(destinoX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);

        if (Mathf.Approximately(transform.position.x, destinoX))
        {
            if (destinoX == limiteDer)
            {
                destinoX = limiteIzq;
                Girar(-1f);
            }
            else
            {
                destinoX = limiteDer;
                Girar(1f);
            }
        }
    }

    void ActualizarEscudo()
    {
        if (jugador == null || rbJugador == null) return;

        // El jugador está en el aire si se mueve en vertical
        bool jugadorEnAire = Mathf.Abs(rbJugador.linearVelocity.y) > 0.1f;
        bool cerca = Vector2.Distance(jugador.position, transform.position) < rangoReaccion;

        if (jugadorEnAire && cerca)
        {
            escudo.localPosition = posicionArriba;
            escudo.localRotation = Quaternion.Euler(0f, 0f, rotacionArriba);
        }
        else
        {
            escudo.localPosition = posicionFrente;
            escudo.localRotation = rotacionFrente;
        }
    }


    void Girar(float lado)
    {
        mirando = lado;
        // Voltea el objeto entero (sprite + escudo) con la escala
        transform.localScale = new Vector3(lado * Mathf.Abs(transform.localScale.x),
                                           transform.localScale.y,
                                           transform.localScale.z);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(tagJugador)) return;

        // Posición del jugador respecto al enemigo (positivo = a su derecha)
        float posRelativa = col.transform.position.x - transform.position.x;

        // Si el jugador está en el lado contrario al que mira, está a su espalda
        bool porDetras = posRelativa * mirando < 0;

        if (porDetras)
            Morir(col.rigidbody);
        // else: aquí iría el daño al jugador (el escudo lo bloquea)
    }

    void Morir(Rigidbody2D rbJugador)
    {
        if (rbJugador != null)
            rbJugador.linearVelocity = new Vector2(rbJugador.linearVelocity.x, reboteJugador);

        animator.SetTrigger("muerto");
        Destroy(gameObject);
    }
}
