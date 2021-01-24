using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour
{
    public void newgame(){
    
        SceneManager.LoadScene("PlayerScene");
    }
}
