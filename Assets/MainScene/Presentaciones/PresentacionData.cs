using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PresentacionData", menuName = "Scriptable Objects/PresentacionData")]
public class PresentacionData : ScriptableObject
{
    public Sprite Preview;
    public string Name;
    public string SceneName;


}
