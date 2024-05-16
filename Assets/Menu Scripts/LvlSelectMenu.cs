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
    }
    public void lvl2select()
    {
        Debug.Log("Loading Lvl 2");
        SceneManager.LoadScene(2);
    }
    public void lvl3select()
    {
        Debug.Log("Loading Lvl 3");
        SceneManager.LoadScene(3);
    }
    public void qutigame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
