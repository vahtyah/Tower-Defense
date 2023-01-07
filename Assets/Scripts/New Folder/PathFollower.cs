using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField]List<Vector2Int> pathCells;
    int nextPathCellIndex;
    bool enemyRunCompleted;
    private void OnEnable()
    {
        pathCells = GameObject.Find("GridManager").GetComponent<EnemyWayManager>().PathCells;
        enemyRunCompleted = false;
        nextPathCellIndex = 0;
        transform.position = new Vector3(pathCells[nextPathCellIndex].x, .2f, pathCells[nextPathCellIndex].y);
    }
    private void FixedUpdate()
    {
        if (pathCells != null && pathCells.Count > 1 && !enemyRunCompleted)
        {
            Vector3 currentPos = transform.position;
            Vector3 nextPos = new Vector3(pathCells[nextPathCellIndex].x, .2f, pathCells[nextPathCellIndex].y);
            transform.position = Vector3.MoveTowards(currentPos, nextPos, Time.deltaTime * 2);
            if (Vector3.Distance(currentPos, nextPos) < 0.02f)
                nextPathCellIndex++;
            if (nextPathCellIndex >= pathCells.Count)
                enemyRunCompleted = true;
        }
    }
}
