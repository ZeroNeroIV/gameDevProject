using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SkyboxChanger : MonoBehaviour
{
    [SerializeField] private Material skyboxDay;
    [SerializeField] private Material skyboxNight;

    private void Start()
    {
        // if (skyboxDay == null || skyboxNight == null)
        // {
        //     Debug.LogError("Skybox materials are not assigned.");
        //     return;
        // }

        // Start the coroutine to change the skybox after 21 seconds
        Invoke("ChangeSkyboxAfterDelay",6);
    }

    private  void ChangeSkyboxAfterDelay()
    {
        // Wait for the specified delay

        // Change the skybox material
        RenderSettings.skybox = skyboxNight;

        // Optional: Update the lighting settings to reflect the new skybox
        DynamicGI.UpdateEnvironment();
    }
}