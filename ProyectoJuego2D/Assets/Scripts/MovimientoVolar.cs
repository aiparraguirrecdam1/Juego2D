using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVolar : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

        // Mover la plataforma hacia adelante
        transform.Translate(Vector3.right * velocidad * Time.fixedDeltaTime);

        if (!informacionSuelo)
        {
            // Girar si no hay suelo
            Girar();
        }
    }

    private void Girar()
    {
        // Girar la plataforma y cambiar la dirección de movimiento
        transform.Rotate(Vector3.up, 180f);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        // Dibujar un Gizmo para visualizar el controlador de suelo
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
    }
}
