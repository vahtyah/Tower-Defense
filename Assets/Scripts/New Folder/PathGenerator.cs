
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
    int width, height;
    List<Vector2Int> pathCells;

    public PathGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public List<Vector2Int> GeneratePath()
    {
        pathCells = new List<Vector2Int>();
        int y = (int)(height / 2);
        int x = 0;

        while (x < width)
        {
            pathCells.Add(new Vector2Int(x, y));
            bool validMove = false;
            while (!validMove)
            {
                int move = Random.Range(0, 4);
                if (move == 0 || x % 2 == 0 || x > width - 2)
                {
                    x++;
                    validMove = true;
                }
                else if (move == 1 && CellIsEmpty(x, y + 1) && y < height - 2)
                {
                    y++;
                    validMove = true;
                }
                else if (move == 2 && CellIsEmpty(x, y - 1) && y > 2)
                {
                    y--;
                    validMove = true;
                }
                //else if(move == 3 && CellIsEmpty(x-1,y) && x < width - 2)
                //{
                //    x--;
                //    validMove = true;
                //}

            }
        }
        return pathCells;
    }

    public bool GenerateCrossroads()
    {
        for (int i = 0; i < pathCells.Count; i++)
        {
            Vector2Int pathCell = pathCells[i];
            if (pathCell.x > 3 && pathCell.x < width - 3 && pathCell.y > 3 && pathCell.y < height - 3)
                if (CellIsEmpty(pathCell.x, pathCell.y + 3) && CellIsEmpty(pathCell.x + 1, pathCell.y + 3) && CellIsEmpty(pathCell.x + 2, pathCell.y + 3) &&
                    CellIsEmpty(pathCell.x - 1, pathCell.y + 2) && CellIsEmpty(pathCell.x, pathCell.y + 2) && CellIsEmpty(pathCell.x + 1, pathCell.y + 2) && CellIsEmpty(pathCell.x + 2, pathCell.y + 2) && CellIsEmpty(pathCell.x + 3, pathCell.y + 2) &&
                    CellIsEmpty(pathCell.x - 1, pathCell.y + 1) && CellIsEmpty(pathCell.x, pathCell.y + 1) && CellIsEmpty(pathCell.x + 1, pathCell.y + 1) && CellIsEmpty(pathCell.x + 2, pathCell.y + 1) && CellIsEmpty(pathCell.x + 3, pathCell.y + 1) &&
                    CellIsEmpty(pathCell.x + 1, pathCell.y) && CellIsEmpty(pathCell.x + 2, pathCell.y) && CellIsEmpty(pathCell.x + 3, pathCell.y) &&
                    CellIsEmpty(pathCell.x + 1, pathCell.y - 1) && CellIsEmpty(pathCell.x + 2, pathCell.y - 1))
                {
                    pathCells.InsertRange(i + 1, new List<Vector2Int> { new Vector2Int(pathCell.x + 1, pathCell.y), new Vector2Int(pathCell.x + 2, pathCell.y), new Vector2Int(pathCell.x + 2, pathCell.y + 1), new Vector2Int(pathCell.x + 2, pathCell.y + 2), new Vector2Int(pathCell.x + 1, pathCell.y + 2), new Vector2Int(pathCell.x, pathCell.y + 2), new Vector2Int(pathCell.x, pathCell.y + 1) });
                    return true;
                }
        }
        return false;
    }

    public bool CellIsEmpty(int x, int y)
    {
        return !pathCells.Contains(new Vector2Int(x, y));
    }
    public bool CellIsTaken(int x, int y)
    {
        return pathCells.Contains(new Vector2Int(x, y));
    }
    public int getCellNeighbourValue(int x, int y)
    {
        int resultValue = 0;
        if (CellIsTaken(x, y - 1)) resultValue += 1;
        if (CellIsTaken(x - 1, y)) resultValue += 2;
        if (CellIsTaken(x + 1, y)) resultValue += 4;
        if (CellIsTaken(x, y + 1)) resultValue += 8;
        return resultValue;
    }
}
