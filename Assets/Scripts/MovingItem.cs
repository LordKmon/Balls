using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.GridBrushBase;
using static UnityEngine.ParticleSystem;

public class MovingItem : MonoBehaviour
{
    public Rigidbody m_Cube;
    public Rigidbody m_OtherCube;
    public ParticleSystem m_Particles;

    public string m_HorizontalAxisName;
    public string m_VerticalAxisName;
    private float m_Speed = 10;

    void Start()
    {
        UpdateParticalsDirection();
    }

    void Update()
    {
        if (m_Cube == null)
            return;

        UpdateMovement();
        UpdateParticalsDirection();
    }

    private void UpdateParticalsDirection()
    {
        if (m_OtherCube == null)
            return;
        
        Vector3 heading = m_OtherCube.position - m_Cube.position;
        Vector3 direction = heading.normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);

        m_Particles.transform.rotation = Quaternion.Slerp(m_Particles.transform.rotation, rotation, Time.deltaTime * m_Speed);
    }

    private void UpdateMovement()
    {
        if (m_HorizontalAxisName == string.Empty || m_VerticalAxisName == string.Empty)
            return;

        float h = Input.GetAxis(m_HorizontalAxisName);
        float v = Input.GetAxis(m_VerticalAxisName);
        Vector3 movement = new Vector3(h * m_Speed, m_Cube.velocity.y, v * m_Speed);
        m_Cube.AddForce(movement);
    }
}
