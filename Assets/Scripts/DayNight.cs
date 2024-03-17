using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DayNight : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightningPreset preset;
    [SerializeField, Range(0,24)] private float timeOfDay;

    private void UpdateLightning(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }
    private void Update()
    {
        if(preset == null)
        {
            return;
        }
        if(Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            //UpdateLightning(timeOfDay / 24f);
        }
        else
        {
            //UpdateLightning(timeOfDay / 24f);
        }
    }

    private void OnValidate()
    {
        if(directionalLight != null)
        {
            return;
        }
        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }

}
