using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public int valor = 1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.CompareTag("Player"))
        {
            gameManager.sumarPuntos(valor);
        }
    }
}
