using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceManager : MonoBehaviour
{
    public Rigidbody m_Cube;
    public Rigidbody m_OtherCube;
    public TextMeshProUGUI m_Text;
    public SceneManager m_SceneManager;
    public BallsManager m_BallsManager;
    private float m_Distance;
    private float DISTANCE_TO_NEW_SCENE = 30;
    private float DISTANCE_TO_SHOW_BALLS = 100;
    void Start()
    {
        //Physics.IgnoreCollision(m_Cube.GetComponent<BoxCollider>(), m_OtherCube.GetComponent<BoxCollider>());
        Physics.IgnoreLayerCollision(6, 6);
        Physics.IgnoreLayerCollision(6, 7);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDistance();
        CheckDistance();
    }

    private void UpdateDistance()
    {
        if (m_OtherCube == null)
            return;

        if (m_Cube == null)
            return;

        if (m_Text == null)
            return;

        Vector3 heading = m_OtherCube.position - m_Cube.position;
        m_Distance = heading.magnitude;

        string new_text = "Дистанция: " + Math.Round(m_Distance, 0).ToString();
        m_Text.text = new_text;
    }

    private void CheckDistance()
    {
        if (m_Distance < DISTANCE_TO_NEW_SCENE)
        {
            m_SceneManager.LoadSecondScene();
            return;
        }

        if (m_Distance < DISTANCE_TO_SHOW_BALLS)
        {
            m_BallsManager.ChangeVisible(true);
            
            return;
        }

        m_BallsManager.ChangeVisible(false);
    }
}
