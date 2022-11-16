using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Node node;
    [SerializeField] Transform point;
    Path path;

    private void Start()
    {
        path = FindObjectOfType<Path>();
        if (path)
        {
            node = path.GetNode(point.position);
        }
    }


}
