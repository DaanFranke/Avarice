using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public Vector3 DirectionFromAngle(float angleInDegrees) 
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
