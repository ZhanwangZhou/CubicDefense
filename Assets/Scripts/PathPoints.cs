using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public static PathPoints Instance { get; private set; }
    public List<Transform> pathPointList;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Init()
    {
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();
        pathPointList = new List<Transform>(transforms);
        pathPointList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLength()
    {
        return pathPointList.Count;
    }

    public Vector3 GetPathPoint(int index)
    {
        return pathPointList[index].position;
    }
}
