using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameManager.vidas < 3)
            {
                gameManager.RecuperarVida();
            }
            Destroy(this.gameObject);
        }
    }
}
