using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public HUD hud;
    private int vidas = 3;
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
    }

    public void RecuperarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;        
    }
}
