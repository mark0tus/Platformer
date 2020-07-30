using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioManager audioManager;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            source.mute = !source.mute;
        }
    }
}
