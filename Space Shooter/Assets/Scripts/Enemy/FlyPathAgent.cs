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
    private int nextIndex = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flyPath = flyPathObject.GetComponent<FlyPath>();
        foreach(var waypointGO in flyPath.waypoints)
        {
            waypointsList.Add(waypointGO.transform.position);
        }
        transform.DOPath(waypointsList.ToArray(), duration, PathType.Linear).SetEase(Ease.Linear);
    }
    private void Update()
    {
        Destroy(gameObject, duration + 0.5f);
        if (nextIndex >= waypointsList.Count)
        {
            return;
        }
        Vector3 newDistance = transform.position - flyPath.waypoints[nextIndex].transform.position;
        if (newDistance.magnitude <= minDistance)
        {
            nextIndex++;
        }
        else
        {
            transform.up = newDistance;
        }
    }
}
 