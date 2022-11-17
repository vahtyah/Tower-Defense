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

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(position.x);
        coordinates.y = Mathf.RoundToInt(position.z);
        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x;
        position.z = coordinates.y;
        return position;
    }
}
