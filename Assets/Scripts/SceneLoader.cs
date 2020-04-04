using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{

    public void LoadSceneOnClick(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}