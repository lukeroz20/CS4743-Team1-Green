using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseRenderer : MonoBehaviour
{
    LineRenderer lr;

    [Range(3, 200)]
    private int segments = 200;
    public Ellipse ellipse;

    //public float xAxis;
    //public float zAxis;
    //public GameObject planet;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector3 position2D = ellipse.Evaluate((float)i / (float)segments);

            //float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            //float x = Mathf.Sin(angle) * xAxis;
            //float z = Mathf.Cos(angle) * zAxis;
            points[i] = new Vector3(position2D.x, 1, position2D.z);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);

    }
    void OnValidate()
    {
        if (Application.isPlaying && lr != null)
            CalculateEllipse();
    }
}
