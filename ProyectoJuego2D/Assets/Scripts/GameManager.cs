using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public HUD hud;
    private int vidas = 3;
    public Jugador Jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sumarPuntos(int puntosASumar)
    {
        puntosTotales = puntosTotales + puntosASumar; 
        hud.ActualizarPuntos(puntosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);
        if (vidas == 0)
        {
            Jugador.transform.position = new Vector3(-13.8f, -2.81f, 0f);
        }
    }

    public void RecuperarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;        
    }
}
