using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class FlyPathAgent : MonoBehaviour
{
    public GameObject flyPathObject;
    public float duration;

    private FlyPath flyPath;
    private List<Vector3> waypointsList = new();
    private float minDistance = 0.1f;
    public int nextIndex = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flyPath = flyPathObject.GetComponent<FlyPath>();
        foreach(var waypointGO in flyPath.waypoints)
        {
            waypointsList.Add(waypointGO.transform.position);
        }
        transform.position = flyPath.waypoints[0].transform.position;
        
        transform.DOPath(waypointsList.ToArray(), duration, PathType.Linear);
    }
    private void Update()
    {
        if (nextIndex >= waypointsList.Count) return;
        Vector3 newDistance = transform.position - flyPath.waypoints[nextIndex].transform.position;
        Debug.Log("Vector Distance: " + newDistance);
        Debug.Log("Distance: "+  newDistance.magnitude);
        if (newDistance.magnitude <= minDistance)
        {
            Debug.Log("true");
            nextIndex++;
        }
        else
        {
            Debug.Log("pos: " + flyPath.waypoints[nextIndex].transform.position);
            Debug.Log("localPos: " + flyPath.waypoints[nextIndex].transform.localPosition);
            transform.up = flyPath.waypoints[nextIndex].transform.position;
        }
    }
}
 