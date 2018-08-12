using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour {
    public GameObject PauseUI;
    private void Start()
    {
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
