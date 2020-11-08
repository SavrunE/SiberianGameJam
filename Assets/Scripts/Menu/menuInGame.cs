using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menuInGame : MonoBehaviour
{
    public GameObject PauseMenu;
    void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.visible = true;
            Pause();
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        UnityEngine.Cursor.visible = false;
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        UnityEngine.Cursor.visible = false;
        SceneManager.LoadScene("DeadZone");
    }
    public void ExitToMenu()
    {
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

