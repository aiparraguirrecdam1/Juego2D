using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform personaje;
    private float tamanoCamara;
    private float alturaPantalla;
    void Start()
    {
        /*tamanoCamara = Camera.main.orthographicSize;
        alturaPantalla = tamanoCamara * 2;*/
    }

    // Update is called once per frame
    void Update()
    {
        //CalcularPosicionCamara();
    }

    /*void CalcularPosicionCamara()
    {
        int pantallaPersonaje = (int)(personaje.position.y / alturaPantalla);
        float alturaCamara = (pantallaPersonaje * alturaPantalla) + tamanoCamara;

        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }*/
}
