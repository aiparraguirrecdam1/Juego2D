using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public HUD hud;
    public int vidas = 3;
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
            cambiarEscena();
        }
    }

    public void RecuperarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;        
    }

    public void cambiarEscena()
    {
         SceneManager.LoadScene("Reinicio");
    }
}
