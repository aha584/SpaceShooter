using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;
    private void Reset()
    {
        waypoints = GetComponentsInChildren<Waypoint>();
    }
    private void OnDrawGizmos()
    {
        if (waypoints.Length <= 0) return;
        Gizmos.color = Color.green;
        for(int i = 0; i < waypoints.Length; i++)
        {
            if (i == waypoints.Length - 1) break;
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }
}
