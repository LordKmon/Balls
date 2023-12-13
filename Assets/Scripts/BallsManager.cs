using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Balls = new List<GameObject>();
    [SerializeField] private GameObject PatternBall;

    private bool currentVisible = true;

    private const int MAX_BALLS = 20;
    private const float BALL_RADIUS = 10;

    void Start()
    {
        CreateBalls();
        ChangeVisible(false);
    }

    private void CreateBalls()
    {        
        List<float> xCords = new List<float>();
        List<float> zCoords = new List<float>();

        for (int i = 0; i < MAX_BALLS; i++)
        {
            xCords.Add(Random.Range(0, 59));
            zCoords.Add(Random.Range(0, 59));
        }

        for (int i = 0; i < MAX_BALLS; i++)
        {
            float xCoord = xCords[i] * BALL_RADIUS - (300 - BALL_RADIUS);
            float zCoord = zCoords[i] * BALL_RADIUS - (300 - BALL_RADIUS);
            GameObject newBall = Instantiate(PatternBall, new Vector3(xCoord, 0, zCoord), Quaternion.identity);
            newBall.layer = 7;
            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.SetColor("_Color", Random.ColorHSV());
            MeshRenderer render = newBall.GetComponent<MeshRenderer>();
            render.material = newMaterial;
            Balls.Add(newBall);
        }
    }

    public void ChangeVisible(bool visible)
    {
        if (currentVisible == visible)
            return;

        currentVisible = visible;

        if (currentVisible == false)
            Camera.main.cullingMask &= ~(1 << 7);

        if (currentVisible == true)
            Camera.main.cullingMask |= (1 << 7); ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
