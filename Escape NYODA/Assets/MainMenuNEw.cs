using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuNEw : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame(string level)
    {
        // SceneManager.LoadScene(""); //Scene Name eg: level 1
        SceneManager.LoadScene(level); //for continuation
        //Menu Index = 0, Game Index = 1

    }
}
