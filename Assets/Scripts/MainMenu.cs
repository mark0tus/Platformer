using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        Debug.Log("OptionsPanel");
    }

    public void ExitGame()
    {
        Debug.Log("Shutdown");
        Application.Quit();
    }
}