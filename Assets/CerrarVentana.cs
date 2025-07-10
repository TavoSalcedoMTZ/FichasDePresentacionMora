using UnityEngine;

public class CerrarVentana : MonoBehaviour
{
    public void Cerrar()
    {
   
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
