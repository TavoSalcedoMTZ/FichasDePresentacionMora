using UnityEngine;

[System.Serializable]
public class PosicionCamara
{
    public Transform destino;
    public GameObject panelRelacionado;
}

public class TransicionCamara : MonoBehaviour
{
    public Transform camara;
    public float velocidad = 2f;
    public GameObject botonVolver;
    public GameObject[] botonesIr;
    public PosicionCamara[] posiciones;

    private Vector3 posicionOriginal;
    private Quaternion rotacionOriginal;
    private Vector3 destinoPosicion;
    private Quaternion destinoRotacion;
    private GameObject panelActivo;
    private bool enTransicion = false;

    void Start()
    {
        posicionOriginal = camara.position;
        rotacionOriginal = camara.rotation;
        if (botonVolver != null) botonVolver.SetActive(false);
    }

    void Update()
    {
        if (enTransicion)
        {
            camara.position = Vector3.Lerp(camara.position, destinoPosicion, Time.deltaTime * velocidad);
            camara.rotation = Quaternion.Lerp(camara.rotation, destinoRotacion, Time.deltaTime * velocidad);

            if (Vector3.Distance(camara.position, destinoPosicion) < 0.05f &&
                Quaternion.Angle(camara.rotation, destinoRotacion) < 1f)
            {
                camara.position = destinoPosicion;
                camara.rotation = destinoRotacion;
                enTransicion = false;
            }
        }
    }

    public void IrAPosicion(int index)
    {
        if (index < 0 || index >= posiciones.Length) return;

        destinoPosicion = posiciones[index].destino.position;
        destinoRotacion = posiciones[index].destino.rotation;
        enTransicion = true;

        foreach (var b in botonesIr) b.SetActive(false);
        if (botonVolver != null) botonVolver.SetActive(true);

        if (panelActivo != null) panelActivo.SetActive(false);
        panelActivo = posiciones[index].panelRelacionado;
        if (panelActivo != null) panelActivo.SetActive(true);
    }

    public void VolverAPosicionOriginal()
    {
        destinoPosicion = posicionOriginal;
        destinoRotacion = rotacionOriginal;
        enTransicion = true;

        foreach (var b in botonesIr) b.SetActive(true);
        if (botonVolver != null) botonVolver.SetActive(false);

        if (panelActivo != null)
        {
            panelActivo.SetActive(false);
            panelActivo = null;
        }
    }
}
