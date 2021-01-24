using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;
   public GameObject pauseMenuUI;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;
    }
    public void QuitGame(){
        Debug.Log("quitting game");
        Application.Quit();
    }
}
