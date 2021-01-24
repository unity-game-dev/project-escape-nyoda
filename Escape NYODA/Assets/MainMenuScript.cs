using UnityEngine;
using UnityEngine.SceneManagement;  // Add scenemanagement package

public class PauseMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // SceneManager.LoadScene(""); //Scene Name eg: level 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //for continuation
        //Menu Index = 0, Game Index = 1

    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    //public void Credits()
    //{
       // SceneManager.LoadScene(""); //credit scene name

    //}
}