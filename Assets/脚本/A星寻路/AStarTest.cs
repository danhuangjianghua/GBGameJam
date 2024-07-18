using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AStarTest : MonoBehaviour
{
    public List<Vector3Int> list = new List<Vector3Int>();
    public Vector3Int start;
    public Vector3Int end;
    // Start is called before the first frame update
    void Start()
    {
        AStarPathFinding aStarPath = new AStarPathFinding();
        list= aStarPath.FindPath(start, end);
    }

}
