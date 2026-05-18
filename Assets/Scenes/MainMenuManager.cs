using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Loadscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
