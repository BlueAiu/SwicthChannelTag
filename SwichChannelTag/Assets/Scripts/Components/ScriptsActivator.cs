using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptsActivator : MonoBehaviour
{
    [SerializeField] SerializableDictionary<string, List<MonoBehaviour>> 
        activeScriptsInScene;


    private void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach(var scene in activeScriptsInScene.Keys)
        {
            ScriptsEnable(activeScriptsInScene[scene], scene == currentScene);
        }
    }

    void OnSceneUnloaded(Scene scene)
    {
        var prevName = scene.name;
        if (prevName != null &&
            activeScriptsInScene.ContainsKey(prevName))
            ScriptsEnable(activeScriptsInScene[prevName], false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var newName = scene.name;
        if (newName != null &&
            activeScriptsInScene.ContainsKey(newName))
            ScriptsEnable(activeScriptsInScene[newName], true);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void ScriptsEnable(List<MonoBehaviour> scripts, bool value)
    {
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = value;
        }
    }
}
