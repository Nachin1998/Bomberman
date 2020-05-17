using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Bomberman");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}