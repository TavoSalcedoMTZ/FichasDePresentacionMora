using UnityEngine;

public class GirarCamara : MonoBehaviour
{
    [Header("Configuraci�n de rotaci�n")]
    public GameObject camara;
    public float smoothSpeed;
    public Quaternion targetRotation;
    public float cantidadARotar;
    private bool rotating = false;

    void Start()
    {
        // Rotaci�n inicial como referencia
        targetRotation = camara.transform.rotation;
    }

    void Update()
    {
        // Si se presiona la tecla R (puedes cambiarla)
        if (Input.GetKeyDown(KeyCode.R) && !rotating)
        {
            // Aplica una rotaci�n de 180 grados en el eje Y desde la posici�n actual
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + cantidadARotar, 0);
            rotating = true;
        }

        // Si est� rotando, interpolar hacia la rotaci�n deseada
        if (rotating)
        {
            camara.transform.rotation = Quaternion.Slerp(camara.transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);

            // Si ya est� suficientemente cerca de la rotaci�n objetivo, detener rotaci�n
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
