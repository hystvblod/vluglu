using UnityEngine;

/// <summary>
/// Represents a single cell in the game grid.
/// Each cell can hold at most one Drop.
/// </summary>
public class Cell : MonoBehaviour
{
    /// <summary>
    /// Grid coordinates of this cell (X = column, Y = row).
    /// </summary>
    public Vector2Int Coordinates { get; set; }

    /// <summary>
    /// The drop currently placed on this cell. Null if the cell is empty.
    /// </summary>
    public Drop CurrentDrop { get; private set; }

    /// <summary>
    /// True when a drop occupies the cell.
    /// </summary>
    public bool IsOccupied => CurrentDrop != null;

    /// <summary>
    /// Assigns a drop to the cell.
    /// </summary>
    public void SetDrop(Drop drop)
    {
        CurrentDrop = drop;
    }

    /// <summary>
    /// Clears the reference to the drop.
    /// </summary>
    public void Clear()
    {
        CurrentDrop = null;
    }
}
