using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runas : MonoBehaviour
{
    // Start is called before the first frame update
    public int valor = 3;
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.sumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}