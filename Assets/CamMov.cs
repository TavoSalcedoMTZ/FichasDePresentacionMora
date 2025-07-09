using UnityEngine;
using System.Collections;

public class CamMov : MonoBehaviour
{
    public Transform[] positionsCamera;
    public float moveDuration = 1.5f;

    private int currentIndex = 1;
    private Coroutine currentMovement;

    void Start()
    {
       
        transform.position = positionsCamera[currentIndex].position;
    }

    public void MoveToNext()
    {
        if (currentIndex < positionsCamera.Length - 1)
        {
            currentIndex++;
            MoveToCurrentIndex();
        }
    }

    public void MoveToPrevious()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            MoveToCurrentIndex();
        }
    }

    public void MoveToIndex(int index)
    {
        if (index >= 0 && index < positionsCamera.Length)
        {
            currentIndex = index;
            MoveToCurrentIndex();
        }
    }

    private void MoveToCurrentIndex()
    {
        if (currentMovement != null) StopCoroutine(currentMovement);
        currentMovement = StartCoroutine(MoveCamera(positionsCamera[currentIndex]));
    }

    IEnumerator MoveCamera(Transform target)
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        Vector3 endPosition = target.position;
        Quaternion endRotation = target.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        transform.rotation = endRotation;
    }
}
