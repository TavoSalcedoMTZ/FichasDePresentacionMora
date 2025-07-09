using UnityEngine;

public class Presentacion1 : MonoBehaviour
{
    [Header("Configuración")]
    public float scrollSpeed;
    public float scrollDuration; // Duración del scroll en segundos
    public Quaternion initialRotation;
    public float scrollTimer = 0f;
    public GirarCamara rotacionDeVuelta;
    public Menu menu;

    private Vector3 initialPosition;
    private bool isScrolling = false;

    void Start()
    {
        initialPosition = transform.position;

        // Aplicar la rotación inicial (inclinación estilo Star Wars)
        transform.rotation = initialRotation;
    }

    void Update()
    {
        if (isScrolling)
        {
            scrollTimer += Time.deltaTime;

            if (scrollTimer < scrollDuration)
            {
                // Movimiento en espacio local
                transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.Self);
            }
            else
            {
                isScrolling = false;
                scrollTimer = 0f;
                ResetPosition();
            }
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
        scrollTimer = 0f; // Reinicia el temporizador
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rotacionDeVuelta.rotacion();
        menu.activarMenuPrincipalConDelay();
    }

    public void Detener()
    {
        isScrolling = false;
        scrollTimer = 0f; // Reinicia el temporizador
        ResetPosition();
    }

    public void Regresar()
    {
        Detener();
    }
}
