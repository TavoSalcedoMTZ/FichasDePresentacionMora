using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Animacion: MonoBehaviour
{
    public Animator animator;          // Asigna tu Animator en el Inspector
    public GameObject panel;           // El panel que quieres mostrar
    public float retrasoPanel = 1f;    // Tiempo de espera antes de mostrar el panel

    public void AlPresionarBoton()
    {
        animator.SetTrigger("Activar");   // Asegúrate de tener un parámetro "Activar" en el Animator
        StartCoroutine(MostrarPanelConRetraso());
    }

    IEnumerator MostrarPanelConRetraso()
    {
        yield return new WaitForSeconds(retrasoPanel);
        panel.SetActive(true);
    }
}
