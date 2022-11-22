using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int gridWidth = 16;
    [SerializeField] int gridHeight = 8;
    [SerializeField] int minPathLength = 30;

    [SerializeField] GridCellObject[] pathCellObjects;
    [SerializeField] GridCellObject[] sceneryCellObjects;

    PathGenerator pathGenerator;

    private void Start()
    {
        pathGenerator = new PathGenerator(gridWidth, gridHeight);
        List<Vector2Int> pathCells = pathGenerator.GeneratePath();
        int pathLenth = pathCells.Count;
        while (pathLenth < minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            pathGenerator.GenerateCrossroads();
            pathLenth = pathCells.Count;
        }
        StartCoroutine(LayPathCells(pathCells));
        StartCoroutine(LaySceneryCells());
    }

    private IEnumerator LayPathCells(List<Vector2Int> pathCells)
    {
        foreach (Vector2Int pathCell in pathCells)
        {
            int neighbourValue = pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);
            GameObject pathTile = pathCellObjects[neighbourValue].cellPrefab;
            Quaternion quaternionTile = Quaternion.Euler(new Vector3(0f, pathCellObjects[neighbourValue].yRotation, 0f));
            Instantiate(pathTile, new Vector3(pathCell.x, 0f, pathCell.y), quaternionTile, transform);
            yield return new WaitForSeconds(.2f);
        }
        yield return null;
    }

    IEnumerator LaySceneryCells()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (pathGenerator.CellIsEmpty(x, y))
                {
                    int randomSceneryCellIndex = Random.Range(0, sceneryCellObjects.Length);
                    Instantiate(sceneryCellObjects[randomSceneryCellIndex].cellPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    yield return new WaitForSeconds(.1f);
                }
            }
        }
        yield return null;
    }
}
