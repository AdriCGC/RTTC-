using JetBrains.Annotations;
using UnityEngine;

public class lucky : MonoBehaviour
{
    public static lucky instance;

    public float forcaDoPulo = 10f;
    public float forcaSegurando = 10f;
    public float tempoMaxSegurando = 0.2f;

    public Rigidbody2D rb;
    public float forcaTras = 8f;
    public float forcaCima = 6f;
    public float giro = 400f;



    private bool estaNoSolo;

    public Transform checarSolo;
    public float checarRadius = 0.2f;
    public LayerMask camadaSolo;
    public bool gameOver = false;
    public bool Morte = false;

    private bool estaPulando;
    private float tempoSegurando;
 void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    if (!CountdownStart.jogoIniciado)
        return;

        estaNoSolo = Physics2D.OverlapCircle(checarSolo.position, checarRadius, camadaSolo);

        if (Input.GetKeyDown(KeyCode.Space) && estaNoSolo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaDoPulo * 1.8f);
            estaPulando = true;
            tempoSegurando = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && estaPulando)
        {
            if (tempoSegurando < tempoMaxSegurando)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    rb.linearVelocity.y + forcaSegurando * Time.deltaTime
                );

                tempoSegurando += Time.deltaTime;
            }
        }

        // 🔥 Gravidade inteligente (corrigida)
        if (rb.linearVelocity.y > 0)
        {
            // Subindo → puxa mais forte pra não subir demais
            rb.gravityScale = 2f;
        }
        else if (rb.linearVelocity.y < 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.gravityScale = 0.25f; // flutua
            }
            else
            {
                rb.gravityScale = 2.5f; // cai rápido
            }
        }

        // Soltou o botão (corta o pulo)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            estaPulando = false;

            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    rb.linearVelocity.y * 0.5f
                );
            }
        }

        // Reset corrigido
        if (estaNoSolo && rb.linearVelocity.y <= 0)
        {
            estaPulando = false;
        }
    }

void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Obstacle"))
    {
        gameOver = true;
        GameOver();
    }
}
     public void GameOver()
{
    if (Morte) return;


    Morte = true;

    rb.linearVelocity = Vector2.zero;

    rb.AddForce(new Vector2(-forcaTras, forcaCima), ForceMode2D.Impulse);

    rb.angularVelocity = giro;
}
}

