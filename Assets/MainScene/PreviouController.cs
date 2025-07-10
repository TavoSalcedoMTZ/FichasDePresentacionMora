using UnityEngine;
using UnityEngine.UI;
using TMPro; // ← Importante para usar TMP_Text
using UnityEngine.SceneManagement;

public class PreviouController : MonoBehaviour
{
    public PresentacionData[] presentacionDatas;
    public Image CuadroPreview;
    public TextMeshProUGUI NombrePresentacion; // ← Aquí cambiamos de Text a TMP_Text
    

    private int currentIndex = 0;

    void Start()
    {
        MostrarPresentacion(currentIndex);
    }

    public void Siguiente()
    {
        currentIndex++;
        if (currentIndex >= presentacionDatas.Length)
            currentIndex = 0;

        MostrarPresentacion(currentIndex);
    }

    public void Anterior()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = presentacionDatas.Length - 1;

        MostrarPresentacion(currentIndex);
    }

    private void MostrarPresentacion(int index)
    {
        if (presentacionDatas.Length == 0 || index < 0 || index >= presentacionDatas.Length)
        {
            Debug.LogWarning("No hay presentaciones para mostrar o el índice está fuera de rango.");
            return;
        }

        CuadroPreview.sprite = presentacionDatas[index].Preview;
        NombrePresentacion.text = presentacionDatas[index].Name;
    }

    public void ChangeScene()
    {
        CanvasManager.Instance.setMain(false);
        CanvasManager.Instance.ViajarScene();
        CanvasManager.Instance.setCurrentScene(presentacionDatas[currentIndex].SceneName);
  
    }
}
