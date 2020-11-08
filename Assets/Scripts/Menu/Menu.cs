using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.visible = !UnityEngine.Cursor.visible;
        }
    }
    public void StartGame()
    {
        UnityEngine.Cursor.visible = false;
        SceneManager.LoadScene("DeadZone", LoadSceneMode.Single);
    }
    public void ExitToMenu()
    {
        UnityEngine.Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

