using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    float horizontal;
    float speed = 5f;
    bool isRunning = false;
    bool isJumping = false;
    bool isAttacking = false;
    bool atacando = false;
    public GameManager GameManager;
    public Jugador jugador;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    public LayerMask capaPinchos;
    Animator animator;
    Rigidbody2D rb2d;
    [Header("Rebote")]
    [SerializeField] private float velocidadRebote;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isAttacking", isAttacking);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
            isRunning = true;
        else
            isRunning = false;
        
        animator.SetBool("isRunning", isRunning);
        Vector2 velocity = rb2d.velocity;
        velocity.x = horizontal * speed;
        rb2d.velocity = velocity;

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        ProcesarSalto();
        DetectarCaidaDelMapa();
        Atacar();
        //cambiarEscena();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, 
            new Vector2(boxCollider.bounds.size.x,
            boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycast.collider != null;
    }

    bool EstaEnPinchos()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center,
            new Vector2(boxCollider.bounds.size.x,
            boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaPinchos);
        return raycast.collider != null;
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (EstaEnSuelo() || EstaEnPinchos()))
        {
            rb2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", isJumping);
        }
        else
        {
            isJumping = false;
            animator.SetBool("isJumping", isJumping);
        }
    }

    void DetectarCaidaDelMapa()
    {
        Vector3 jugadorPosition = transform.position;
        float limiteInferior = -10f;

        if (jugadorPosition.y < limiteInferior && !EstaEnSuelo() && !isJumping) {
            RestablecerPosicion();
            GameManager.PerderVida();
        }
    }

    void Atacar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            animator.SetBool("isAttacking", isAttacking);
        }

        if (!Input.GetMouseButtonDown(0))
        {
            isAttacking = false;
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    public void RestablecerPosicion()
    {
        transform.position = new Vector3(-13.8f, -2.81f, 0f);
    }

    public void Rebote()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, velocidadRebote);
    }
}

