using UnityEngine;
using UnityEngine.Events;

public class Starter : MonoBehaviour
{
   
    public UnityEvent OnStart;

    void Start()
    {
     OnStart?.Invoke();
    }


}
