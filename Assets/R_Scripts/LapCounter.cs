using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public int totalLaps = 3;
    private int currentLap = 0;
    public TMP_Text lapCounterText;
    public GameObject winPanel; // Add reference to the win panel
    public GameObject losePanel; // Add reference to the lose panel
    private RaceManager raceManager; // Reference to RaceManager script

    private void Start()
    {
        raceManager = FindObjectOfType<RaceManager>(); // Find RaceManager script in scene
        UpdateLapCounterUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentLap++;

            if (currentLap >= totalLaps)
            {
                // Check player position from RaceManager
                int playerPosition = raceManager.GetPlayerPosition();
                if (playerPosition == 1)
                {
                    winPanel.SetActive(true); // Activate win panel
                }
                else
                {
                    losePanel.SetActive(true); // Activate lose panel
                }
            }

            UpdateLapCounterUI();
        }
    }

    void UpdateLapCounterUI()
    {
        lapCounterText.text = "Lap: " + currentLap.ToString() + " / " + totalLaps.ToString();
    }
}
