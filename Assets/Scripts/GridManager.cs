using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for creating the grid of cells and spawning drops.
/// </summary>
public class GridManager : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Drop dropPrefab;
    [SerializeField] private Transform gridRoot;

    private int gridSize;
    private Cell[,] cells;

    /// <summary>
    /// Create a new grid. Old cells are destroyed.
    /// </summary>
    public void CreateGrid(int size)
    {
        ClearGrid();
        gridSize = size;
        cells = new Cell[size, size];

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Cell cell = Instantiate(cellPrefab, gridRoot);
                cell.Coordinates = new Vector2Int(x, y);
                cells[x, y] = cell;
            }
        }
    }

    /// <summary>
    /// Removes all existing cells.
    /// </summary>
    private void ClearGrid()
    {
        if (cells == null)
            return;

        foreach (Cell c in cells)
        {
            if (c != null)
                Destroy(c.gameObject);
        }
    }

    /// <summary>
    /// Returns a random empty cell, or null if none are available.
    /// </summary>
    public Cell GetRandomEmptyCell()
    {
        List<Cell> empty = new List<Cell>();
        foreach (Cell c in cells)
        {
            if (!c.IsOccupied)
                empty.Add(c);
        }

        if (empty.Count == 0)
            return null;
        int index = Random.Range(0, empty.Count);
        return empty[index];
    }

    /// <summary>
    /// Spawns a drop with the provided value on a random empty cell.
    /// </summary>
    public Drop SpawnDrop(int value)
    {
        Cell cell = GetRandomEmptyCell();
        if (cell == null)
            return null;

        Drop drop = Instantiate(dropPrefab, cell.transform.position, Quaternion.identity, gridRoot);
        drop.Initialize(value, cell);
        return drop;
    }
}
