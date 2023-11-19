using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runas : MonoBehaviour
{
    public int valor = 3;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.sumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}
