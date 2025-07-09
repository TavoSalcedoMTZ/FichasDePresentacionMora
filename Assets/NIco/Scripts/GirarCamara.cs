using UnityEngine;

public class GirarCamara : MonoBehaviour
{
    [Header("Configuración de rotación")]
    public GameObject camara;
    public float smoothSpeed;
    public Quaternion targetRotation;
    public float cantidadARotar;
    private bool rotating = false;

    void Start()
    {
        // Rotación inicial como referencia
        targetRotation = camara.transform.rotation;
    }

    void Update()
    {
        // Si se presiona la tecla R (puedes cambiarla)
        if (Input.GetKeyDown(KeyCode.R) && !rotating)
        {
            // Aplica una rotación de 180 grados en el eje Y desde la posición actual
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + cantidadARotar, 0);
            rotating = true;
        }

        // Si está rotando, interpolar hacia la rotación deseada
        if (rotating)
        {
            camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);

            // Si ya está suficientemente cerca de la rotación objetivo, detener rotación
            if (Quaternion.Angle(camara.transform.rotation, targetRotation) < 0.1f)
            {
                camara.transform.rotation = targetRotation;
                rotating = false;
            }
        }
    }

    public void rotacion()
    {
        rotacionAplicada();

        camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);

        if (Quaternion.Angle(camara.transform.rotation, targetRotation) < 0.1f)
        {
            camara.transform.rotation = targetRotation;
            rotating = false;
        }
    }

    public void rotacionAplicada()
    {
        targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + cantidadARotar, 0);
        rotating = true;
    }
}
