using UnityEngine;
public class SkyboxChanger : MonoBehaviour
{
    [SerializeField] private Material skyboxDay;
    [SerializeField] private Material skyboxNight;

    private void Start() => Invoke(nameof(ChangeSkyboxAfterDelay),6);

    private void ChangeSkyboxAfterDelay()
    {
        RenderSettings.skybox = skyboxNight;
        DynamicGI.UpdateEnvironment();
    }
}
