﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour
{
   public static bool GameIsPaused = false;

   public GameObject pauseMenuUI;
    public GameObject playerUI;
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
   
        playerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
        
        if((SceneManager.GetActiveScene().name=="PlayerScene")){
            Debug.Log((SceneManager.GetActiveScene().name=="PlayerScene"));
                AudioManager.instance.Play("BgMusic");

        }
        else{
                     AudioManager.instance.StopPlaying("BgMusic");
        }
      
    }
    void Pause(){
        playerUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;

    }
    public void QuitGame(){
        Debug.Log("going to menu");
        SceneManager.LoadScene("MainMenu");
        GameIsPaused=false;
        Resume();
  
    }
}
