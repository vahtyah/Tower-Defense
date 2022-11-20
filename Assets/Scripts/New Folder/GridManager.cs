using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int gridWidth = 16;
    [SerializeField] int gridHeight = 8;
    [SerializeField] int minPathLength = 30;

    [SerializeField] GameObject pathTile;

    PathGenerator pathGenerator;

    private void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        List<Vector2Int> pathCells = pathGenerator.GeneratePath();
        int pathLenth = pathCells.Count;
        while (pathLenth < minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            pathLenth = pathCells.Count;
        }
        StartCoroutine(LayPathCells(pathCells));
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
        yield return null;
    }
}
