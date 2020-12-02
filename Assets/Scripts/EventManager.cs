using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance => _instance;
    public string levelToLoad;

    private void Awake()
    {
        _instance = this;
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
