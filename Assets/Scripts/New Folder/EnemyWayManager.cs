using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayManager : MonoBehaviour
{

    [SerializeField] List<Vector2Int> pathCells;
    public List<Vector2Int> PathCells { get { return pathCells; } }
    public void setPathCells(List<Vector2Int> pathCells)
    {
        this.pathCells = pathCells;
    }
}
