using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light light1;
    public Light light2;
    public Light light3;

    public float intensityRange1;
    public float intensityRange2;
    public float intensityRange3;

    float lightIntensity1;
    float lightIntensity2;
    float lightIntensity3;

    int upOrDown;
    float a;
    private void Awake()
    {
        lightIntensity1 = light1.intensity;
        lightIntensity2 = light2.intensity;
        lightIntensity3 = light3.intensity;

        upOrDown = 1;
    }
    private void Start()
    {

    }

    private void Update()
    {

        ChangeIntensity(light1, lightIntensity1, intensityRange1);
        ChangeIntensity(light2, lightIntensity2, intensityRange2);
        ChangeIntensity(light3, lightIntensity3, intensityRange3);
    }

    public void ChangeIntensity(Light light,float lightIntensity,float intensityRange)
    {
        light.intensity = Mathf.Lerp(light.intensity, lightIntensity + intensityRange * upOrDown, Time.deltaTime);
        
        if (light.intensity == a)
        {
            upOrDown = -upOrDown;
        }

        a = light.intensity;
    }
}
