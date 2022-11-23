using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] List<Vector2Int> pathCells;

    GameObject enemyInstance;
    int nextPathCellIndex;
    bool enemyRunCompleted;

    private void Start()
    {
        enemyRunCompleted = false;
        nextPathCellIndex = 0;
        enemyInstance = Instantiate(enemyPrefab, new Vector3(pathCells[nextPathCellIndex].x, .2f, pathCells[nextPathCellIndex].y), Quaternion.identity);
    }

    private void Update()
    {
        if (pathCells != null && pathCells.Count > 1 && !enemyRunCompleted)
        {
            Vector3 currentPos = enemyInstance.transform.position;
            Vector3 nextPos = new Vector3(pathCells[nextPathCellIndex].x, .2f, pathCells[nextPathCellIndex].y);
            enemyInstance.transform.position = Vector3.MoveTowards(currentPos, nextPos, Time.deltaTime * 2);
            if (Vector3.Distance(currentPos, nextPos) < 0.02f)
            {
                if (nextPathCellIndex >= pathCells.Count)
                {
                    enemyRunCompleted = true;
                    print("Tuan");
                }
                else nextPathCellIndex++;
            }
        }
    }

    public void setPathCells(List<Vector2Int> pathCells)
    {
        this.pathCells = pathCells;
    }
}
