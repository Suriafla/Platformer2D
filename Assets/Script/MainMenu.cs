using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class MainMenu works with methods for main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts Level 1
    /// </summary>
    private void PlayGame()
    {      
        SceneManager.LoadScene("Level 1");
    }

    /// <summary>
    /// Close application
    /// </summary>
    private void ExitGame()
    {        
        Application.Quit();
    }
    
    /// <summary>
    /// Goes to the main menu
    /// </summary>
    private void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // "Brings up" time that stops when paused
        Time.timeScale = 1f;                    
        GlobalKey.EscKeyEnable = true;          
    }

}
