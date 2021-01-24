using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class backtomenu : MonoBehaviour
{
    public void NextScene(){
    
        SceneManager.LoadScene("MainMenu");
    }
}