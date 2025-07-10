using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events; 

public class EscribirTexto : MonoBehaviour
{
    [Header("Componentes")]
    public TextMeshProUGUI textoUI;

    [Header("Texto y tiempos")]
    public string textoCompleto = "Hola, mundo.";
    public float tiempoInicio = 2f;
    public float intervaloEntreLetras = 0.05f;

    [Header("Evento al terminar")]
    public UnityEvent onTextoFinalizado;
    public UnityEvent onEndScene;

    void Start()
    {
        StartCoroutine(EscribirLetraPorLetra());
    }
    public void ClearText()
    {
        textoUI.text = "";
    }

    IEnumerator EscribirLetraPorLetra()
    {
        yield return new WaitForSeconds(tiempoInicio);

        textoUI.text = "";

        foreach (char letra in textoCompleto)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(intervaloEntreLetras);
        }

       
        onTextoFinalizado?.Invoke();
        yield return new WaitForSeconds(13f);
        onEndScene?.Invoke();

    }
}
