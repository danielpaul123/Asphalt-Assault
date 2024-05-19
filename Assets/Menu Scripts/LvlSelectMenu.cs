using EdyCommonTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectMenu : MonoBehaviour
{
    public void lvl1select()
    {
        Debug.Log("Loading Lvl 1");
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void lvl2select()
    {
        Debug.Log("Loading Lvl 2");
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void lvl3select()
    {
        Debug.Log("Loading Lvl 3");
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
    public void qutigame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
