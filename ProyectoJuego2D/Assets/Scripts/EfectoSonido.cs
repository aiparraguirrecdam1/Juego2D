using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip colectar1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(colectar1);
            Destroy(gameObject);
        }
    }
}
