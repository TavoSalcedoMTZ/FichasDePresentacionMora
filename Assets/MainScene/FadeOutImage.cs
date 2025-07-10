using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeOutImage : MonoBehaviour
{
    public Image panelImage;
    public float duracion = 1f;
    public UnityEvent onFadeOutComplete;

    public void IniciarRutina()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color colorOriginal = panelImage.color;
        float alphaInicial = 1f;
        float alphaFinal = 0f;

        yield return new WaitForSeconds(2f); 
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

        yield return new WaitForSeconds(0.5f);
        onFadeOutComplete?.Invoke();
    }
}
