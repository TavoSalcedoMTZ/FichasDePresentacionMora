using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    public static CanvasManager Instance { get; private set; }

    public Button buttonMain;

    public UnityEvent CambioScene;
    public UnityEvent SceneCambiadaYa;
    private string currentScene;
    public bool main = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public void setCurrentScene(string sceneName)
    {
        currentScene = sceneName;
    }


    public void setMain(bool isMain)
    {
        main = isMain;
    }
    public void GoToScene()
    {
        if (!main)
        {

            SceneManager.LoadSceneAsync(currentScene);
        }
        else
        {
            SceneManager.LoadSceneAsync("MainScene");
        }
        SceneCambiadaYa.Invoke();


    }


    public void ViajarScene()
    {
        if (!main)
        {
            buttonMain.gameObject.SetActive(true);
        }
        else
        {
            buttonMain.gameObject.SetActive(false);
        }


            CambioScene.Invoke();
    }

    

}
