using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;

    [Range(0, 360)]
    public float viewAngle;

    public LayerMask playerMask;

    public void findPlayer() 
    {
        Transform player;
        Collider[] playerInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        if (playerInViewRadius == null) 
        {
            return;
        }
        else 
        {
            player = playerInViewRadius[0].transform;
        }

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2) 
        { 
            
        }
    }

    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal) 
    {
        if (!angleIsGlobal) 
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
