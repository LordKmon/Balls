using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.GridBrushBase;
using static UnityEngine.ParticleSystem;

public class MovingItem : MonoBehaviour
{
    [SerializeField] private Rigidbody CurrentCube;
    [SerializeField] private Rigidbody OtherCube;
    [SerializeField] private ParticleSystem Particles;

    [SerializeField] private string HorizontalAxisName;
    [SerializeField] private string VerticalAxisName;

    private const float SPEED = 10;

    void Start()
    {
        UpdateParticalsDirection();
    }

    void Update()
    {
        if (CurrentCube == null)
            return;

        UpdateMovement();
        UpdateParticalsDirection();
    }

    private void UpdateParticalsDirection()
    {
        if (OtherCube == null)
            return;
        
        Vector3 heading = OtherCube.position - CurrentCube.position;
        Vector3 direction = heading.normalized;

        Quaternion rotation = Quaternion.LookRotation(direction);

        Particles.transform.rotation = Quaternion.Slerp(Particles.transform.rotation, rotation, Time.deltaTime * SPEED);
    }

    private void UpdateMovement()
    {
        if (HorizontalAxisName == string.Empty || VerticalAxisName == string.Empty)
            return;

        float h = Input.GetAxis(HorizontalAxisName);
        float v = Input.GetAxis(VerticalAxisName);
        Vector3 movement = new Vector3(h * SPEED, CurrentCube.velocity.y, v * SPEED);
        CurrentCube.AddForce(movement);
    }
}
