using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMultiplication : MonoBehaviour
{

    public Vector3 translation;
    public Vector3 eulerAngles;
    public Vector3 scale = new Vector3(1, 1, 1);
    public float guidesMagnitude;

    public Vector3 point;
    private Vector3 _newPoint;
    public Transform c1, c2, c3;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        Matrix4x4 m = Matrix4x4.identity;
        m.SetTRS(translation, rotation, scale);
        _newPoint = m.MultiplyPoint(point);
        Vector3 nUp = m.MultiplyPoint(Vector3.up );
        Vector3 nRight = m.MultiplyPoint(Vector3.right );
        Vector3 zero = m.MultiplyPoint(Vector3.zero);
        c1.position = point;
        c2.position = _newPoint;
        c3.position = m.inverse.MultiplyPoint(_newPoint);
        Debug.DrawLine(Vector3.zero, point, Color.blue);
        Debug.DrawLine(zero, _newPoint, Color.cyan);
        Debug.DrawLine(zero, nUp*guidesMagnitude, Color.green);
        Debug.DrawLine(zero, nRight*guidesMagnitude, Color.red);
    }
}
