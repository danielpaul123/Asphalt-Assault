using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelButtons : MonoBehaviour
{
   public void lvlrestart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Debug.Log("Lvl Restart");
        Time.timeScale = 1f;
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Loading Main Menu");
        Time.timeScale = 1f;
    }
}
