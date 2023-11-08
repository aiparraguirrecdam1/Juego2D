using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Rigidbody2D rb2d;
    private BoxCollider2D boxCollider;
    float horizontal;
    float speed = 5f;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    bool isRunning = false;
    bool isJumping = false;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
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
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, 
            new Vector2(boxCollider.bounds.size.x,
            boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycast.collider != null;
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
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
}

