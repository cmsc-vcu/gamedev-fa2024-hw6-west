using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject winMenu;
    public GameObject loseMenu;

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    public void StartGame()
    {
        // Load the game scene
        mainMenu.SetActive(false);
        // Optionally, you can activate the Game UI if you keep it in the same scene
        gameUI.SetActive(true);
    }

    public void PlayerWon()
    {
        gameUI.SetActive(false);
        winMenu.SetActive(true);
    }

    public void PlayerLost()
    {
        gameUI.SetActive(false);
        loseMenu.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
