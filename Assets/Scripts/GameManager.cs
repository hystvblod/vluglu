using UnityEngine;

/// <summary>
/// Central controller for basic game state and score handling.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Managers")]
    [SerializeField] private GridManager gridManager;
    [SerializeField] private InterstitialAds interstitialAds;
    [SerializeField] private AudioManager audioManager;

    [Header("Settings")]
    [SerializeField, Range(4, 5)] private int gridSize = 4;
    [SerializeField] private AudioClip fusionClip;

    private int score;
    private int fusions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if (gridManager != null)
            gridManager.CreateGrid(gridSize);
    }

    /// <summary>
    /// Called by a drop when a fusion occurs.
    /// Adds to the score and optionally plays audio/ads.
    /// </summary>
    public void RegisterFusion(int valueGained)
    {
        score += valueGained;
        fusions++;
        if (audioManager != null && fusionClip != null)
            audioManager.PlaySFX(fusionClip);

        // Show an interstitial every 10 fusions as an example.
        if (fusions % 10 == 0 && interstitialAds != null)
            interstitialAds.ShowAd();
    }

    /// <summary>
    /// Returns the current score.
    /// </summary>
    public int GetScore() => score;

    /// <summary>
    /// Restarts the game by clearing and recreating the grid and resetting score.
    /// </summary>
    public void RestartGame()
    {
        score = 0;
        fusions = 0;
        if (gridManager != null)
            gridManager.CreateGrid(gridSize);
    }
}
