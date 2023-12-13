using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private const string SECOND_SCENE_NAME = "Scene_Two";

    void Start()
    {
    }

    void Update()
    {
    }

    public void LoadSecondScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SECOND_SCENE_NAME);
    }
}
