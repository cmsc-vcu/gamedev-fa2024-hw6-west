using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI Menus
    public GameObject mainMenu;  // Main Menu UI
    public GameObject winMenu;   // Win Menu UI
    public GameObject loseMenu;  // Lose Menu UI

    private bool gameIsOver = false;

    void Start()
    {
        // Show the main menu at the start and hide other menus
        ShowMainMenu();
    }

    void Update()
    {
        // Check if any menu is active to pause the game
        if (mainMenu.activeSelf || winMenu.activeSelf || loseMenu.activeSelf)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    // Show the Main Menu and hide other UI elements
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);  // Show the main menu
        winMenu.SetActive(false);   // Hide win menu
        loseMenu.SetActive(false);  // Hide lose menu
    }

    // Start the game (e.g., when Start button is clicked)
    public void StartGame()
    {
        mainMenu.SetActive(false);  // Hide the main menu
        winMenu.SetActive(false);    // Hide win menu
        loseMenu.SetActive(false);   // Hide lose menu

        // Load game scene or setup game state
        // SceneManager.LoadScene("GameScene");
    }

    // Triggered when the player reaches a win condition (e.g., reaching the target)
    public void PlayerWon()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            winMenu.SetActive(true);   // Show win menu
        }
    }

    // Triggered when the player hits an enemy or fails (e.g., losing condition)
    public void PlayerLost()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            loseMenu.SetActive(true);  // Show lose menu
        }
    }

    // Restart the current game scene (e.g., when restart button is clicked)
    public void RestartGame()
    {
        gameIsOver = false;
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // Return to the main menu (e.g., from the win or lose menu)
    public void LoadMainMenu()
    {
        gameIsOver = false;
        ShowMainMenu(); // Show the main menu within the same scene or load the main menu scene
        // If your main menu is in a separate scene, use:
        // SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Exiting the game.");
        Application.Quit();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game
    }

    private void ResumeGame()
    {
        if (!gameIsOver)
        {
            Time.timeScale = 1f; // Resume the game
        }
    }
}
