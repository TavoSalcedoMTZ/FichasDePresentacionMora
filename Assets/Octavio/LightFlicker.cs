using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;
    public float flickerVariance = 0.05f;

    private Light spotLight;
    private float nextFlickerTime;

    void Start()
    {
        spotLight = GetComponent<Light>();
        if (spotLight.type != LightType.Spot)
        {
            Debug.LogWarning("Este script está diseñado para luces tipo Spot.");
        }

        nextFlickerTime = Time.time + flickerSpeed;
    }

    void Update()
    {
        if (Time.time >= nextFlickerTime)
        {
        
            spotLight.intensity = Random.Range(minIntensity, maxIntensity);

           
            nextFlickerTime = Time.time + flickerSpeed + Random.Range(-flickerVariance, flickerVariance);
        }
    }
}
