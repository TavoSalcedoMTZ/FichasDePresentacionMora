using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class locurion : MonoBehaviour
{
    public void TriggerSceneChange()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}