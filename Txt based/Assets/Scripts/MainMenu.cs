using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void mainGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("QUIT");
    }
}
