using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    [Header("Movimiento")]
    public GameObject objetoAMover;
    public Vector3 direccionMovimiento = new Vector3(0, 0, 5);
    public float duracionMovimiento;
    public GameObject objetoAactivar;

    private bool enMovimiento = false;
    public Vector3 posicionInicial;
    public Vector3 posicionFinal;
    private float tiempoInicio;

    // Esta función se puede enlazar al botón
    public void MoverObjeto()
    {
        if (!enMovimiento)
        {
            tiempoInicio = Time.time;
            enMovimiento = true;
            objetoAactivar.SetActive(true);
        }
    }

    void Update()
    {
        if (enMovimiento)
        {
            float t = (Time.time - tiempoInicio) / duracionMovimiento;
            objetoAMover.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);

            if (t >= 1f)
            {
                objetoAMover.transform.position = posicionFinal; // Asegura la posición final exacta
                enMovimiento = false;
                objetoAactivar.SetActive(true);
                tiempoInicio = 0f;
            }
        }
    }
}
