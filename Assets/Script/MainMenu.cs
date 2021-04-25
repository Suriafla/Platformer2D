using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void PlayGame()
    {      
        SceneManager.LoadScene("Level 1");
    }

    private void ExitGame()
    {        
        Application.Quit();
    }

    private void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Оживляет время, которое останавливается при паузе
        Time.timeScale = 1f;
        GlobalKey.EscKeyEnable = true;
    }

}
