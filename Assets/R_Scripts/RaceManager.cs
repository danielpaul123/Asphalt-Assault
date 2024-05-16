using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public Transform playerCar;
    public List<Transform> cars;
    public TMP_Text positionText;

    private List<int> positions;

    void Start()
    {
        positions = new List<int>();
        for (int i = 0; i < cars.Count; i++)
        {
            positions.Add(0);
        }
    }

    void Update()
    {
        UpdatePositions();
        DisplayPlayerPosition();
    }

    void UpdatePositions()
    {
        cars.Sort((a, b) => b.position.z.CompareTo(a.position.z));

        for (int i = 0; i < cars.Count; i++)
        {
            int index = cars.IndexOf(cars[i]);
            positions[index] = i + 1;
        }
    }

    public int GetPlayerPosition()
    {
        int playerIndex = cars.IndexOf(playerCar);
        return positions[playerIndex];
    }

    void DisplayPlayerPosition()
    {
        int playerPosition = GetPlayerPosition();
        positionText.text = "Position: " + playerPosition + "/" + cars.Count;
    }
}
