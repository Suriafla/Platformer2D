using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Class to reload level
/// </summary>
public class ReloadLevel : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Method to reload current level
    /// </summary>
    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Reload level when button down
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Reload();
    }
}
