using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallsManager : MonoBehaviour
{
    public List<GameObject> m_Balls = new List<GameObject>();
    public GameObject m_PatternBall;

    private bool m_CurrentVisible = true;
    void Start()
    {
        CreateBalls();
        ChangeVisible(false);
    }

    private void CreateBalls()
    {
        int count = 20;
        float ball_radius = 10;
        List<float> x_coords = new List<float>();
        List<float> z_coords = new List<float>();

        for (int i = 0; i < count; i++)
        {
            x_coords.Add(Random.Range(0, 59));
            z_coords.Add(Random.Range(0, 59));
        }

        //x_coords.Sort();
        //z_coords.Sort();

        for (int i = 0; i < count; i++)
        {
            float x_coord = x_coords[i] * ball_radius - (300 - ball_radius);
            float z_coord = z_coords[i] * ball_radius - (300 - ball_radius);
            GameObject new_ball = Instantiate(m_PatternBall, new Vector3(x_coord, 0, z_coord), Quaternion.identity);
            new_ball.layer = 7;
            Material new_material = new Material(Shader.Find("Standard"));
            new_material.SetColor("_Color", Random.ColorHSV());
            MeshRenderer render = new_ball.GetComponent<MeshRenderer>();
            render.material = new_material;
            m_Balls.Add(new_ball);
        }
    }

    public void ChangeVisible(bool a_Visible)
    {
        if (m_CurrentVisible == a_Visible)
            return;
        m_CurrentVisible = a_Visible;

        if (m_CurrentVisible == false)
            Camera.main.cullingMask &= ~(1 << 7);

        if (m_CurrentVisible == true)
            Camera.main.cullingMask |= (1 << 7); ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
