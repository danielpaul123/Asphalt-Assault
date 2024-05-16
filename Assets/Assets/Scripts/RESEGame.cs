using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESEGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject losePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            losePanel.SetActive(true);
        }
    }
}
