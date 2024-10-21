using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        // Load the main menu scene (replace "MainMenu" with your main menu scene name)
        SceneManager.LoadScene("Main_Menu");
    }
}
