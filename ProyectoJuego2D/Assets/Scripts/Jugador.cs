using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrog : MonoBehaviour
{
    Rigidbody2D rb2d;
    float horizontal;
    float speed = 5f;
    public float fuerzaSalto;
    bool isRunning = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
            isRunning = true;
        else
            isRunning = false;
        animator.SetBool("isRunning", isRunning);
        Vector2 velocity = rb2d.velocity;
        velocity.x = horizontal * speed;
        rb2d.velocity = velocity;

        /*salto = Input.GetAxis("Jump");
        Debug.Log("Salto " + salto);
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0, 20));
        }*/

        ProcesarSalto();
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
}

