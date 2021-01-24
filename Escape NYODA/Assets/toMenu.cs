using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class toMenu : MonoBehaviour
{
    public void NextScene(){
    
        SceneManager.LoadScene("MainMenu");
    }
}