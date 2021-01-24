using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool playerHasDied = false;
    bool demoHasEnded = false;
    public float gameOverWaitTime = 2f;
    public float demoOverWaitTime = 10f;
    public void EndGame()
    {
        if(playerHasDied == false)
        {
            playerHasDied = true;
            Debug.Log("GAME OVER");
            Invoke("GameOver", gameOverWaitTime);
        }
        
    }
    public void EndDemo()
    {
        if(demoHasEnded == false)
        {
            demoHasEnded = true;
            Debug.Log("Demo Over");
            Invoke("DemoOver", demoOverWaitTime);
        }
    }

    void DemoOver()
    {
        SceneManager.LoadScene("ThankYou");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
