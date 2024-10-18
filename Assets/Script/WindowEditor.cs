using UnityEngine;
using UnityEditor;

public class WindowEditor : EditorWindow
{
    [MenuItem("Window/PRJ.1 Custom Plugin")]
    public static void ShowWindow()
    {
        GetWindow<WindowEditor>("PRJ.1 Custom Plugin");
    }

    //public float RainVolume = 1f;
    public ParticleSystem rainParticleSystem;
    //public Texture rainTexture;
    //public float rainIntensity = 0.5f;

    void OnGUI()
    {
        GUILayout.Label("Tools", EditorStyles.boldLabel);

        // Window Setting Section
        if (GUILayout.Button("Close Window"))
        {
            this.Close();
        }

        if (GUILayout.Button("Move To Origin"))
        {
            var objs = GameObject.FindGameObjectsWithTag("Player");
            foreach (var obj in objs)
            {
                obj.transform.position = Vector3.zero;
            }
        }

        // Rain Editor Section
        EditorGUILayout.LabelField("Rain Settings");
        rainParticleSystem = (ParticleSystem)EditorGUILayout.ObjectField("Rain Partical", rainParticleSystem, typeof(ParticleSystem), true);
        //rainTexture = (Texture)EditorGUILayout.ObjectField("Rain Texture", rainTexture, typeof(Texture), true);
        //rainIntensity = EditorGUILayout.Slider("Rain Intensity", rainIntensity, 0f, 1f);

        if (GUILayout.Button("Rain On/Off"))
        {
            ToggleRain();
        }
    }

    void ToggleRain()
    {
        if (rainParticleSystem != null)
        {
            var emissionModule = rainParticleSystem.emission;
            emissionModule.enabled = !emissionModule.enabled;
        }
    }
}
