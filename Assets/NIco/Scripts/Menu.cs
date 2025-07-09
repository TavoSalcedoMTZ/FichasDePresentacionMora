using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GameObject menuPrincipal;
    public float segundos;

    public GameObject menuCambiable;

    public void desactivarMenuPrincipal()
    {
        menuPrincipal.SetActive(false);
    }

    public void activarMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
    }

    public void activarMenuPrincipalConDelay()
    {
        StartCoroutine(ActivarMenuConDelayCoroutine());
    }

    public void activarMenuCambiale()
    {
        menuCambiable.SetActive(true);
    }

    public void activarMenuCambiableConDelay()
    {
        StartCoroutine(ActivarMenuCambiableConDelayCoroutine());
    }

    public void desactivarMenuCambiable()
    {
        menuCambiable.SetActive(false);
    }

    private IEnumerator ActivarMenuConDelayCoroutine()
    {
        yield return new WaitForSeconds(segundos);
        activarMenuPrincipal();
    }

    private IEnumerator ActivarMenuCambiableConDelayCoroutine()
    {
        yield return new WaitForSeconds(segundos);
        activarMenuCambiale();
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}
