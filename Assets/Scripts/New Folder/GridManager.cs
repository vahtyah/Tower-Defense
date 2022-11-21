using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int gridWidth = 16;
    [SerializeField] int gridHeight = 8;
    [SerializeField] int minPathLength = 30;

    [SerializeField] GridCellObject[] gridCells;

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
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);
            GameObject pathTile = gridCells[neighbourValue].cellPrefab;
            Quaternion quaternionTile = Quaternion.Euler(new Vector3(0f, gridCells[neighbourValue].yRotation, 0f));
            Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), quaternionTile, transform);
            yield return new WaitForSeconds(.2f);
        }
        yield return null;
    }
}
