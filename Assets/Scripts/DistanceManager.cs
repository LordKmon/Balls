using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    [SerializeField] private Rigidbody FirstCube;
    [SerializeField] private Rigidbody OtherCube;
    [SerializeField] private TextMeshProUGUI TextObj;
    [SerializeField] private SceneManager SceneManager;
    [SerializeField] private BallsManager BallsManager;

    private const float DISTANCE_NEW_SCENE = 30;
    private const float DISTANCE_SHOW_BALLS = 100;
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6);
        Physics.IgnoreLayerCollision(6, 7);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = CalcDistance();
        if (distance == -1)
            return;

        UpdateDistanceTest(distance);
        CheckDistance(distance);
    }

    private void UpdateDistanceTest(float distance)
    {
        string newText = "Дистанция: " + Math.Round(distance, 0).ToString();
        TextObj.text = newText;
    }

    private float CalcDistance()
    {
        if (OtherCube == null)
            return -1;

        if (FirstCube == null)
            return -1;

        if (TextObj == null)
            return -1;

        Vector3 heading = OtherCube.position - FirstCube.position;
        return heading.magnitude;
    }

    private void CheckDistance(float distance)
    {
        if (distance < DISTANCE_NEW_SCENE)
        {
            SceneManager.LoadSecondScene();
            return;
        }

        if (distance < DISTANCE_SHOW_BALLS)
        {
            BallsManager.ChangeVisible(true);
            
            return;
        }

        BallsManager.ChangeVisible(false);
    }
}
