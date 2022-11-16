using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Dictionary<Vector3, Node> pathDic = new Dictionary<Vector3, Node>();

    public Node GetNode(Vector3 position)
    {
        if (pathDic.ContainsKey(position))
        {
            return pathDic[position];
        }
        return null;
    }
}
