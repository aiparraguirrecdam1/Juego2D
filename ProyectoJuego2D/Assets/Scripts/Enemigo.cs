using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool reboto = false;

            foreach (ContactPoint2D punto in other.contacts)
            {
                if (punto.normal.y <= -0.9)
                {
                    other.gameObject.GetComponent<Jugador>().Rebote();
                    Destroy(this.gameObject);
                    reboto = true;
                    break;
                }
            }

            if (!reboto)
            {
                gameManager.PerderVida();
            }
        }
    }
}
