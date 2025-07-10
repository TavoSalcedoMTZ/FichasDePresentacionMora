using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FadeInImage : MonoBehaviour
{
    public Image panelImage;      
    public float duracion = 1f;   
    public UnityEvent onFadeInComplete;
    public void IniciarRutina()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color colorOriginal = panelImage.color;
        float alphaInicial = 0f;
        float alphaFinal = 1f;


        panelImage.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alphaInicial);

        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alphaActual = Mathf.Lerp(alphaInicial, alphaFinal, tiempo / duracion);
            panelImage.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alphaActual);
            yield return null;
        }


        panelImage.color = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, alphaFinal);

   
        yield return new WaitForSeconds(0.5f); // Espera un poco antes de invocar el evento
        onFadeInComplete?.Invoke();
    }
}
