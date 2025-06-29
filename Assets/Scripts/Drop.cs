using UnityEngine;

/// <summary>
/// Component that stores the numeric value of a drop and handles fusion.
/// </summary>
public class Drop : MonoBehaviour
{
    [SerializeField] private Animator animator; // Plays fusion animation

    /// <summary>
    /// Current numeric value of the drop.
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// The cell the drop is currently occupying.
    /// </summary>
    public Cell CurrentCell { get; private set; }

    /// <summary>
    /// Initializes the drop with a starting value and parent cell.
    /// </summary>
    public void Initialize(int value, Cell cell)
    {
        Value = value;
        MoveTo(cell);
    }

    /// <summary>
    /// Moves the drop to another cell.
    /// </summary>
    public void MoveTo(Cell cell)
    {
        if (CurrentCell != null)
            CurrentCell.Clear();

        CurrentCell = cell;
        if (cell != null)
        {
            cell.SetDrop(this);
            transform.position = cell.transform.position;
        }
    }

    /// <summary>
    /// Fuses this drop with another, increasing the value and destroying the other.
    /// </summary>
    public void FuseWith(Drop other)
    {
        if (other == null || other == this)
            return;

        Value += other.Value;
        if (animator != null)
            animator.SetTrigger("Fuse");

        Destroy(other.gameObject);
        GameManager.Instance.RegisterFusion(Value);
    }
}
